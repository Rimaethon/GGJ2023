using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSlidingGameSystem : MonoBehaviour
{
    Vector2Int currentPosition;
    GridStateRow[] grids;
    Sprite[] gridTypes;
    Transform gridHolder;

    int columnCount;
    public Transform _characterTransform;

    void Awake() 
    {
        SlidingBlockMap sbm =  FindObjectOfType<SlidingBlockMap>();
        grids = sbm.GetGrids();
        gridTypes = sbm.GetGridTypes();
        gridHolder = sbm.GetGridHolder();

        columnCount = grids[0].row.Length;

        for (int j = 0; j < grids.Length ; j++) 
        {
            for (int i = 0; i < grids[0].row.Length; i++)
            {
                if (grids[j].row[i] == SlidingBlockMap.GridState.Start)
                {
                    currentPosition = new Vector2Int(i,j);
                }
            }
        }
            
            // _characterTransform.position =
        //     new Vector2(Vector3.right * .5f * i * gridSize.x, Vector3.down * .5f * j * gridSize.y);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentPosition);
        
        if (GetGridState(currentPosition.x,currentPosition.y) == SlidingBlockMap.GridState.Goal)
            Debug.Log("Reached the goal!");
        
        Debug.Log("horizontal input " + Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Horizontal") < 0 && currentPosition.x > 0) 
        {
            //Debug.Log("left input and current x is greater than 0");
            SlidingBlockMap.GridState veryLeftState = GetGridState(currentPosition.x -1,currentPosition.y);

            Debug.Log("very left is " + veryLeftState);
            if (veryLeftState == SlidingBlockMap.GridState.Walkable)
            {
                SwapGrids(currentPosition, new Vector2Int(currentPosition.x - 1, currentPosition.y));
                currentPosition.x--;
            }
                
            else if (veryLeftState == SlidingBlockMap.GridState.Block) 
            {
                SlidingBlockMap.GridState verySecondLeft = GetGridState(currentPosition.x -2,currentPosition.y);

                if (currentPosition.x > 1 && verySecondLeft == SlidingBlockMap.GridState.Walkable) 
                {
                    SwapGrids(new Vector2Int (currentPosition.x -2,currentPosition.y),new Vector2Int (currentPosition.x -1,currentPosition.y));
                    SwapGrids(currentPosition,new Vector2Int (currentPosition.x -1,currentPosition.y));
                    currentPosition.x--;
                }
            }
        }

        else if (Input.GetAxis("Horizontal") > 0 && currentPosition.x < columnCount -1) 
        {
            SlidingBlockMap.GridState veryRightState = GetGridState(currentPosition.x +1,currentPosition.y);

            if (veryRightState == SlidingBlockMap.GridState.Walkable)
            {
                currentPosition.x++;
                SwapGrids(currentPosition,new Vector2Int (currentPosition.x +1,currentPosition.y));
            }
                

            else if (veryRightState == SlidingBlockMap.GridState.Block) 
            {
                SlidingBlockMap.GridState verySecondRight = GetGridState(currentPosition.x +2,currentPosition.y);

                if (currentPosition.x < columnCount -2 && verySecondRight == SlidingBlockMap.GridState.Walkable) 
                {
                    SwapGrids(new Vector2Int (currentPosition.x +2,currentPosition.y),new Vector2Int (currentPosition.x +1,currentPosition.y));
                    SwapGrids(currentPosition,new Vector2Int (currentPosition.x +1,currentPosition.y));
                    currentPosition.x++;
                }
            }
        }

        else if (Input.GetAxis("Vertical") > 0 && currentPosition.y > 0) 
        {
            SlidingBlockMap.GridState veryUpState = GetGridState(currentPosition.x,currentPosition.y-1);

            if (veryUpState == SlidingBlockMap.GridState.Walkable)
            {
                SwapGrids(currentPosition,new Vector2Int (currentPosition.x,currentPosition.y-1));
                currentPosition.y--;
            }
                

            else if (veryUpState == SlidingBlockMap.GridState.Block) 
            {
                SlidingBlockMap.GridState verySecondUp = GetGridState(currentPosition.x,currentPosition.y-2);

                if (currentPosition.y > 1 && verySecondUp == SlidingBlockMap.GridState.Walkable) 
                {
                    SwapGrids(new Vector2Int (currentPosition.x,currentPosition.y-2),new Vector2Int (currentPosition.x,currentPosition.y-1));
                    SwapGrids(currentPosition,new Vector2Int (currentPosition.x,currentPosition.y-1));
                    currentPosition.y--;
                }
            }
        }

        else if (Input.GetAxis("Vertical") < 0 && currentPosition.y < grids.Length-1) 
        {
            SlidingBlockMap.GridState veryDownState = GetGridState(currentPosition.x,currentPosition.y+1);

            if (veryDownState == SlidingBlockMap.GridState.Walkable)
            {
                SwapGrids(currentPosition, new Vector2Int(currentPosition.x, currentPosition.y + 1));
                currentPosition.y++;
            }

            else if (veryDownState == SlidingBlockMap.GridState.Block) 
            {
                SlidingBlockMap.GridState verySecondDown = GetGridState(currentPosition.x,currentPosition.y+2);

                if (currentPosition.y < grids.Length-2 && verySecondDown == SlidingBlockMap.GridState.Walkable) 
                {
                    SwapGrids(new Vector2Int (currentPosition.x,currentPosition.y+2),new Vector2Int (currentPosition.x,currentPosition.y+1));
                    SwapGrids(currentPosition,new Vector2Int (currentPosition.x,currentPosition.y+1));
                    currentPosition.y++;
                }
            }
        }
    }

    SlidingBlockMap.GridState GetGridState (int x, int y) 
    {
        return grids[y].row[x];
    }

    void SwapGrids (Vector2Int index0, Vector2Int index1) 
    {
        SlidingBlockMap.GridState index0GridType = grids[index0.y].row[index0.x];
        grids[index0.y].row[index0.x] = grids[index1.y].row[index1.x];
        grids[index1.y].row[index1.x] = index0GridType;

        gridHolder.GetChild(index0.y * columnCount + index0.x).GetComponent<SpriteRenderer>().sprite = gridTypes[(int)(grids[index0.y].row[index0.x])];
        gridHolder.GetChild(index1.y * columnCount + index1.x).GetComponent<SpriteRenderer>().sprite = gridTypes[(int)(grids[index1.y].row[index1.x])];

    }

}
