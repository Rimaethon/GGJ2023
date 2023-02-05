using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScroller : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform cardsHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cardsHolder.Translate(Vector3.forward * speed * Time.deltaTime * Input.GetAxis("Vertical"));
    }
}
