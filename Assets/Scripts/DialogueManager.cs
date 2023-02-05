using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] DialogueText[] dialogueTexts;
    [SerializeField] GameObject leftChar, leftCharBW,rightChar, rightCharBW, narrator;
    
    [SerializeField] int endCode; //0 is None, 1 is textualChoice, 2 is variableChoice, 3 is minigame
    [SerializeField] string endOperation;

    string variableChoice;
    int dialogueTextIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftButton() 
    {
        //end ui session
    }

    public void RightButton() 
    {
        //end ui session
        //set var
    }

    public void End() 
    {
        if (endCode == 0) 
        {
            // decision -> endOp
        }
        
        else if(endCode == 1)
        {
            //decision0 -> endOp left of /
            //decision1 -> endOp right of /
        }

        else if(endCode == 2)
        {
            
            //decision0 -> endOp false of /
            //decision1 -> endOp true of /
            //variable -> endOp end of
        }

        else if(endCode == 3) 
        {
            SceneManager.LoadScene(endOperation);
        }
    }
    public void NextDialogueText() 
    {
        dialogueTextIndex++;
        DialogueText current = dialogueTexts[dialogueTextIndex];
        narrator.SetActive(current.isNarrator);

        if (!current.isNarrator) 
        {
            leftChar.SetActive(current.leftIsTalking);
            rightChar.SetActive(!current.leftIsTalking);

            leftCharBW.SetActive(rightChar.activeInHierarchy);
            rightCharBW.SetActive(leftChar.activeInHierarchy);
        }
        

    } 


}

[System.Serializable]
class DialogueText 
{
    public string text;
    public bool isNarrator;
    public bool leftIsTalking;

}
