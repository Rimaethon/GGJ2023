using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    private Vector3 mouseStart;
    private Vector3 planeStart;
    private Transform childObject;
    
    void Start()
    {
        childObject = transform.GetChild(0);
    }

    void OnMouseDown()
    {
        mouseStart = Input.mousePosition;
        planeStart = transform.position;
    }

    void OnMouseDrag()
    {
        Vector3 mouseDelta = Input.mousePosition - mouseStart;
        
        childObject.position = new Vector3(childObject.position.x, childObject.position.y, childObject.position.z - mouseDelta.z * Time.deltaTime);
    }
}
