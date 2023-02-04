using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemsDestroyer : MonoBehaviour
{
    
    public Dialogue dialogue;
    [SerializeField]
    private Image keyImage;
    [SerializeField]
    private Image demirImage;
    [SerializeField]
    private Image obje2Image;
    [SerializeField]
    private Image obje3Image;
    [SerializeField]
    private Image obje4Image;

    private void Start()
    {
        dialogue = GameObject.FindGameObjectWithTag("panel").GetComponent<Dialogue>();
    }
    private void OnMouseDown()
    {

        if (gameObject.name == "key")
        {
            Debug.Log("key found");
            keyImage.gameObject.SetActive(true);

            
            gameObject.SetActive(false);

        }
        if (gameObject.name == "demir")
        {
            Debug.Log("demir found");
            demirImage.gameObject.SetActive(true);


            gameObject.SetActive(false);

        }
        if (gameObject.name == "obje2")
        {
            Debug.Log("demir found");
            obje2Image.gameObject.SetActive(true);


            gameObject.SetActive(false);

        }
        if (gameObject.name == "obje3")
        {
            Debug.Log("demir found");
            obje3Image.gameObject.SetActive(true);


            gameObject.SetActive(false);

        }
        if (gameObject.name == "obje4")
        {
            Debug.Log("demir found");
            obje4Image.gameObject.SetActive(true);


            gameObject.SetActive(false);

        }
        else if (gameObject.name == "door")
        {
            if (keyImage.gameObject.active==true)
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
