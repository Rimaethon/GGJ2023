using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public bool keyfound = false;
    public Dialogue dialogue;
    private void Start()
    {
        dialogue = GameObject.FindGameObjectWithTag("panel").GetComponent<Dialogue>();
    }
    private void OnMouseDown()
    {
        
        if (gameObject.name=="key")
        {
            Debug.Log("key found");
            keyfound = true;
            Destroy(gameObject);

        }
        if (gameObject.name=="demir")
        {

        }
       else  if (gameObject.name=="door")
        {
            if (keyfound==true)
            {
                Debug.Log("door opened");
                
                dialogue.StartDialogue(1);
            }
            else
            {
                Debug.Log("key not found");
                dialogue.StartDialogue(0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
