using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueText[] dialogueTexts;
    [SerializeField] GameObject leftChar,rightChar, narrator;

    int dialogueTextIndex = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextDialogueText() 
    {
        dialogueTextIndex++;
        DialogueText current = dialogueTexts[dialogueTextIndex];
        narrator.SetActive(current.isNarrator);
    
    } 


}

[System.Serializable]
class DialogueText 
{
    public string text;
    public bool isNarrator;

}
