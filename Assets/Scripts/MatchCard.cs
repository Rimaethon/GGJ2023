using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MatchCard : MonoBehaviour
{
    string cardId;
    public static MatchCard lastDrawn;
    static bool rejectInput;
    [SerializeField] Sprite cardBack;
    [SerializeField] AnimationCurve glowCurve;
    Image cardFrontImage;

    static WaitForSeconds oneSec = new WaitForSeconds(1);
    static WaitForSeconds oneQuarterSec = new WaitForSeconds(.25f);
    public void DrawCard() 
    {
        if (rejectInput)
            return;

        if ( lastDrawn == null)
        {
            lastDrawn = this;
            StartCoroutine(Glow(true));
        }

        else 
        {
            if (name != lastDrawn.name) 
            {
                if (cardFrontImage.sprite.name == lastDrawn.cardFrontImage.sprite.name)
                {
                    StartCoroutine(Glow(true));
                    GetComponent<Button>().interactable = false;
                    lastDrawn.GetComponent<Button>().interactable = false;
                    lastDrawn = null;
                }

                else 
                {

                    StartCoroutine(GlowAndFade());

                }

                

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lastDrawn = null;
        Image im = GetComponent<Image>();
        
        cardFrontImage = transform.GetChild(0).GetComponent<Image>();
        cardFrontImage.sprite = im.sprite;
        cardFrontImage.color = new Color(1,1,1,0);
        im.sprite = cardBack;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Glow(bool direction) 
    {
        float timePassed = 0;
        Color glowColor = cardFrontImage.color;
        while (timePassed < 1) 
        {
            cardFrontImage.color = glowColor;
            timePassed += Time.deltaTime;
            glowColor.a = direction ? glowCurve.Evaluate(timePassed) : glowCurve.Evaluate(1-timePassed);
            yield return null;

        }
    }

    IEnumerator GlowAndFade() 
    {
        rejectInput = true;
        StartCoroutine(Glow(true));
        yield return oneSec;
        yield return oneQuarterSec;
        StartCoroutine(Glow(false));
        StartCoroutine(lastDrawn.Glow(false));
        yield return oneSec;
        rejectInput = false;
        lastDrawn = null;
    }
}
