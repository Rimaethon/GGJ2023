using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActivator : MonoBehaviour
{
    
    [SerializeField] Transform cardHolder;
    [SerializeField] Sprite[] cardSprites = new Sprite[26];
    bool[] cardActivationChart = new bool[26];
    bool jigsawPuzzle, roadbuildingPuzzle, prisonPuzzle, cardMatchingPuzzle;
    bool isaCalled, fatherAlive;

    public void SetPuzzle(int puzzleCode) 
    {
        switch(puzzleCode) 
        {
            case 1:
                jigsawPuzzle = true;
                break;
            case 2:
                roadbuildingPuzzle = true;
                break;
            case 3:
                prisonPuzzle = true;
                break;
            case 4:
                cardMatchingPuzzle = true;
                break;
        }
    }

    public void SetIsaCalled() 
    {
        isaCalled = true;
    }

    public void SetFatherAlive() 
    {
        fatherAlive = true;
    }


    void Start()
    {
        for(int i = 1; i < 26; i++) 
        {
            cardHolder.Find("Card " + i).GetChild(1).GetComponent<SpriteRenderer>().sprite = cardSprites[0];
        }

        ActivateCard(1);
    }

    void ActivateCard(int index) 
    {
        cardActivationChart[index] = true;
        cardHolder.Find("Card " + index).GetChild(1).GetComponent<SpriteRenderer>().sprite = cardSprites[index];
    }

    public void ActivateNeighboursOf (int index) 
    {
        if(index <5)
        {
            ActivateCard(index+1); 
        }

        else if (index == 5) 
        {
            if (isaCalled && jigsawPuzzle)
                ActivateCard(6);
            else if (!isaCalled && !jigsawPuzzle)
                ActivateCard(8);
            else
                ActivateCard(7);
        }

        else if (index == 9) 
        {
            if(roadbuildingPuzzle)
                ActivateCard(10);
            else
                ActivateCard(11);
        }

        else if (index == 10)
            ActivateCard(12);

        else if (index == 11)
            ActivateCard(13);
        
        else if (index == 14) 
        {
            if (prisonPuzzle)
            {
                if (isaCalled)
                    ActivateCard(15);
                else
                    ActivateCard(16);
            }

            else
                 ActivateCard(17);
        }

        else if (index == 18) 
        {
            if (cardActivationChart[6]) 
            {
                if(cardActivationChart[10])
                    ActivateCard(19);
                else if (cardActivationChart[11])
                    ActivateCard(20);
                
                if (cardActivationChart[7] || cardActivationChart[8])
                    ActivateCard(21);
            }
                
        }

        else if(index == 22)
        {
            if (cardMatchingPuzzle)
                ActivateCard(25);
            
            else 
            {
                if (fatherAlive)
                    ActivateCard(23);
                else
                    ActivateCard(24);
            }
            
        }
        
    }

    public bool isIndexActive (int index) 
    {
        return cardActivationChart[index];
    }


    

}
