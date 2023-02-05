using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTextChanger : MonoBehaviour
{
    [SerializeField] string buttonChangeText;
    TMP_Text buttonText;
    
    void Awake() 
    {
        buttonText = transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void ChangeText() 
    {
         buttonText.text = buttonChangeText;
    }
    
}
