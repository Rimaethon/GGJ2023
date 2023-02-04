using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingBlockMap : MonoBehaviour
{
    [SerializeField] Vector3 startPosition;
    [SerializeField] Sprite[] gridTypes;
    [SerializeField] Vector2 gridSize;
    [SerializeField] GameObject genericGrid;
    public enum GridState {Empty, Walkable, Block, Start, Goal}

    [SerializeField] GridStateRow[] grids;
    [SerializeField] Transform gridHolder;

    // Start is called before the first frame update
    void Start()
    {

        int counter = 0;
        for (int j = 0; j < grids.Length ; j++) 
        {
            for (int i = 0; i < grids[0].row.Length  ; i++) 
            {
                GameObject newGrid = Instantiate(genericGrid);
                newGrid.transform.position = startPosition 
                                             + Vector3.right * .5f * i * gridSize.x 
                                             + Vector3.down * .5f * j * gridSize.y;

                //Debug.Log("current type is: " + grids[j,i]);
                newGrid.GetComponent<SpriteRenderer>().sprite = gridTypes[(int)(grids[j].row[i])];
                newGrid.transform.name += (counter++).ToString();
                newGrid.transform.parent = gridHolder;
            }
        }
    }

    public GridStateRow[] GetGrids() 
    {
        return grids;
    }

    public Sprite[] GetGridTypes() 
    {
        return gridTypes;
    }

    public Transform GetGridHolder() 
    {
        return gridHolder;
    }

}

 [System.Serializable]
  public class GridStateRow
  {
     public SlidingBlockMap.GridState[] row;
  }
