using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotter : MonoBehaviour
{
    int degrees = 90;
    playerMovemend playerMovemend;
    private void Start()
    {
        playerMovemend = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovemend>();
    }
    private void OnMouseDown()
    {
        
        Debug.Log("tiklandi");
        transform.eulerAngles += Vector3.forward * degrees;
        
    }
    
}
