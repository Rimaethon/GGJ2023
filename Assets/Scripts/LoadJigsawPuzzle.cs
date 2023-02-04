using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoadJigsawPuzzle : MonoBehaviour
{
    [SerializeField] GameObject jigsawUnit;

    float gridWidth, gridHeight;

    // Start is called before the first frame update
    void Awake()
    {
        JigsawPuzzleData jpd = FindObjectOfType<JigsawPuzzleData>();
        JigsawDragAndDrop jdd = FindObjectOfType<JigsawDragAndDrop>();
        
        Transform jigsawHolder = jpd.GetJigsawHolder();
        Sprite[] jigsawPuzzle = jpd.GetJigsawPuzzle();
        int columnCount = jpd.GetColumnCount();
        int rowCount = jpd.GetRowCount();


        gridWidth = (Screen.width * 1f) / columnCount;
        gridHeight = (Screen.height * 1f) / rowCount;


        List<int> aPermutation = new List<int>();
        
        for (int i = 0; i < jigsawPuzzle.Length; i++)
            aPermutation.Add(i);

        int counter = 0;
        for (int j = 0; j < rowCount; j++) 
        {
            for (int i = 0; i < columnCount; i++) 
            {
                GameObject newUnit = Instantiate(jigsawUnit);
                newUnit.transform.SetParent(jigsawHolder);
                newUnit.name += counter.ToString();
                counter++;
                RectTransform rectT = newUnit.GetComponent<RectTransform>();

                rectT.sizeDelta = new Vector2 (gridWidth,gridHeight);
                rectT.anchoredPosition = new Vector2 ((.5f + i) * gridWidth,-(.5f + j) * gridHeight);

                int anElement = aPermutation [Random.Range(0,aPermutation.Count)];
                aPermutation.Remove(anElement);
                newUnit.GetComponent<Image>().sprite = jigsawPuzzle [anElement];
            } 
            
        }

    }

    public Vector2 GetGridSize() 
    {
        return new Vector2 (gridWidth, gridHeight);
    }

}
