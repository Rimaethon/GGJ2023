using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovemend : MonoBehaviour
{
    Vector3 destination = new Vector3(0.6f, -3.9f);
    //Vector3 asd =new Vector3(transform.position.x, transform.position.y+180,0);
    private void Start()
    {

        StartCoroutine(waitforstart());
    }
   public  int vectorNumber=1;
    bool isStart =false;
    private void Update()
    {
        if (isStart)
        {
            switch (vectorNumber)
            {
                case 1: transform.position += Vector3.right * Time.deltaTime; break;
                case 2: transform.position += Vector3.up * Time.deltaTime; break;
                case 3: transform.position += -Vector3.up * Time.deltaTime; break;
                case 4: transform.position += Vector3.left * Time.deltaTime; break;
                default:Debug.Log("carpti");break;
            }
        }
        if (vectorNumber!=0)
        {
            if (Input.GetKeyDown(KeyCode.D))
                vectorNumber = 1;

            else if (Input.GetKeyDown(KeyCode.W))
                vectorNumber = 2;
            else if (Input.GetKeyDown(KeyCode.S))
                vectorNumber = 3;
            else if (Input.GetKeyDown(KeyCode.A))
                vectorNumber = 4;
        }
        


    }
    IEnumerator waitforstart()
    {
       yield return new WaitForSeconds(30);
        isStart = true;
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        transform.position = Vector2.Lerp(transform.position, destinationfounder(), Time.deltaTime);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        transform.position = Vector2.Lerp(transform.position, destinationfounder(), Time.deltaTime*-1);
    //    }

    //    //transform.position += Vector3.up  * Time.deltaTime;
    //    // playermove();   
    //    //Moves the GameObject from it's current position to destination over time

    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //Debug.Log(collision.)
    //}
    //public Vector3 destinationfounder()
    //{

    //    return new Vector3(transform.position.x,transform.position.y*3);
    //}


}
