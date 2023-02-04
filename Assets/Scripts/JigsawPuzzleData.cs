using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawPuzzleData : MonoBehaviour
{
    [SerializeField] Transform jigsawHolder;
    [SerializeField] int columnCount;
    [SerializeField] Sprite[] jigsawPuzzle;
    
    public Transform GetJigsawHolder() 
    {
        return jigsawHolder;
    }

    public int GetColumnCount() 
    {
        return columnCount;
    }

    public int GetRowCount() 
    {
        return jigsawPuzzle.Length / columnCount;
    }

    public Sprite[] GetJigsawPuzzle() 
    {
        return jigsawPuzzle;
    }

}
