using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCard : MonoBehaviour
{
    int id;
    public static MatchCard lastDrawn;

    public void DrawCard() 
    {
        if ( lastDrawn == null) 
        {
            lastDrawn = this;
        }

        else 
        {
            if (id == lastDrawn.id)
            {
                Debug.Log("Match!");
            }

            else
                Debug.Log("Not Match!");

            lastDrawn = null;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lastDrawn = null;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
