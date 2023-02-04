using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleDeath : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<playerMovemend>().vectorNumber = 0;
        Debug.Log("girdi");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("dead");
        }
        Destroy(collision.gameObject);

    }
}
