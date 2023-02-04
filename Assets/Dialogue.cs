using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    destroyer destroyer;
    public TextMeshProUGUI textComonent;
    public TextMeshProUGUI timer;
    public string[] lines;
    public float textSpeed;

    private int index;
    private void Start()
    {
        
        textComonent.text = string.Empty;
        

    }
    public void StartDialogue(int index1)
    {
        index = index1;
        
        StartCoroutine(TypeLine());
        
    }
    public float timeRemaining = 10;

    void Update()

    {

        if (timeRemaining > 0)

        {

            timeRemaining -= Time.deltaTime;
            timer.text = " :" + ((int)timeRemaining);
                

        }
    }



        IEnumerator TypeLine()
    {
        textComonent.gameObject.SetActive(true);
        //gameObject.SetActive(true);
        foreach (var item in lines[index].ToCharArray())
        {
            textComonent.text += item;
            yield return new WaitForSeconds(textSpeed);
        }
        textComonent.text = string.Empty;
        textComonent.gameObject.SetActive(false);
        // gameObject.SetActive(false);
    }
}
