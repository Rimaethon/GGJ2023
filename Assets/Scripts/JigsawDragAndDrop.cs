using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawDragAndDrop : MonoBehaviour
{
    [SerializeField] Transform jigsawHolder;

    Sprite[] jigsawPuzzle;
    GameObject draggingUnit;
    Vector2 sizeVector;
    
    int columnCount;
    int rowCount;

    int lastDraggedUnitIndex = -1;

    
    public void JigsawUnitBeginDrag() 
    {
        lastDraggedUnitIndex = GridIndexAtPosition(Input.mousePosition);
        Transform lastDraggedChild = jigsawHolder.GetChild(lastDraggedUnitIndex);

        draggingUnit = Instantiate(lastDraggedChild.gameObject);
        lastDraggedChild.gameObject.SetActive(false);
        draggingUnit.transform.SetParent(jigsawHolder);
    }

    public void JigsawUnitEndDrag() 
    {
        if (lastDraggedUnitIndex == -1)
            return;
            
        int draggedOntoUnitIndex = GridIndexAtPosition(Input.mousePosition);
        Image lastDraggedUnitImage = jigsawHolder.GetChild(lastDraggedUnitIndex).GetComponent<Image>();
        Image ontoUnitImage = jigsawHolder.GetChild(draggedOntoUnitIndex).GetComponent<Image>();

        lastDraggedUnitImage.sprite = ontoUnitImage.sprite;
        ontoUnitImage.sprite = draggingUnit.GetComponent<Image>().sprite;

        lastDraggedUnitImage.gameObject.SetActive(true);

        lastDraggedUnitIndex = -1;
        Destroy(draggingUnit);
        draggingUnit = null;

    }

    private int GridIndexAtPosition (Vector2 position) 
    {
        return (rowCount - (int)((position.y/sizeVector.y)) - 1) * columnCount + (int)(position.x/sizeVector.x);
    }

    void Start()
    {
        LoadJigsawPuzzle ljp = FindObjectOfType<LoadJigsawPuzzle>();
        JigsawPuzzleData jpd = FindObjectOfType<JigsawPuzzleData>();

        sizeVector = ljp.GetGridSize();

        columnCount = jpd.GetColumnCount();
        rowCount = jpd.GetRowCount();
        jigsawPuzzle = jpd.GetJigsawPuzzle();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (draggingUnit == null) 
        {
            if (Input.GetMouseButtonDown(0)) JigsawUnitBeginDrag();
        }

        else 
        {
            draggingUnit.GetComponent<RectTransform>().position  = Input.mousePosition;
            if (Input.GetMouseButtonUp(0)) JigsawUnitEndDrag();
        }
    }
}
