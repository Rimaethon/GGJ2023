using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] 
    private float tileSpacing = 1.5f;
    [SerializeField] 
    private int noTiles=6;
    [SerializeField] 
    private float start = -3f;
    [SerializeField] 
    private GameObject[] tiles;
    private void Start()
    {
        float y = start;
        for (int i = 0; i < noTiles; i++)
        {
            float x = start;
            for (int j = 0; j < noTiles; j++)
            {
                int tilenumber = Random.Range(0, tiles.Length);
                int rotatenumber = Random.Range(0, 4);

                Instantiate(tiles[tilenumber], new Vector3(x, y), transform.rotation = Quaternion.AngleAxis(90 * rotatenumber, Vector3.forward));
                x += tileSpacing;
            }
            y += tileSpacing;
        }
    }
    


}
