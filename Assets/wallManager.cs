using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallManager : MonoBehaviour
{
    public int wallNumber = 0;
    public int beforeNumber ;
    
    public GameObject[] walls;
    public Button button_right;
    public Button button_left;
    public void wall_btn_right()
    {
        beforeNumber=wallNumber;
        if (wallNumber != 3)
        {
            //button_left.gameObject.SetActive(true);
            wallNumber++;
            wall_show();
        }
    }
    public void wall_btn_left()
    {
        beforeNumber = wallNumber;
        if (wallNumber!=0)
        {
            //button_right.gameObject.SetActive(true);
            wallNumber--;
            wall_show();
        }  
    }
    public void wall_show()
    {
        walls[wallNumber].gameObject.SetActive(true);
        walls[beforeNumber].gameObject.SetActive(false);
        if (wallNumber==3)
        {
            button_right.gameObject.SetActive(false);
        }
        else
        {
            button_right.gameObject.SetActive(true);
        }
        if (wallNumber==0)
        {
            button_left.gameObject.SetActive(false);
        }
        else
        {
            button_left.gameObject.SetActive(true);
        }
        
    }
}
