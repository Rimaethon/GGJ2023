using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShuffler : MonoBehaviour
{
    [SerializeField] GameObject cardUnit;

    [SerializeField] Vector2 paddingOutside, paddingBetween;
    [SerializeField] Vector2Int cardDisturbution;
    [SerializeField] Transform cardHolder;
    [SerializeField] Sprite[] cards;

    float unitWidth, unitHeight;
    // Start is called before the first frame update
    void Start()
    {
        unitWidth = (Screen.width*1f)  / (2*paddingOutside.x + cardDisturbution.x + (cardDisturbution.x-1)*paddingBetween.x);
        unitHeight = (Screen.height*1f)  / (2*paddingOutside.y + cardDisturbution.y + (cardDisturbution.y-1)*paddingBetween.y);

        Debug.Log("unit width: " + unitWidth + " unity height: " + unitHeight + "with ratio: " + unitWidth/unitHeight);
        
        List<int> aPermutation = new List<int>();

        for (int i = 0; i < cards.Length; i++)
            aPermutation.Add(i);
        
        int counter = 0;
        for (int j = 0; j < cardDisturbution.y; j++) 
        {
            for (int i = 0; i < cardDisturbution.x; i++) 
            {
                GameObject newUnit = Instantiate(cardUnit);
                newUnit.transform.SetParent(cardHolder);
                newUnit.name += counter.ToString();
                counter++;
                RectTransform rectT = newUnit.GetComponent<RectTransform>();

                rectT.sizeDelta = new Vector2 (unitWidth,unitHeight);
                rectT.anchoredPosition = new Vector2 ((0.5f +paddingOutside.x+i* (1+paddingBetween.x) ) * unitWidth,-(0.5f +paddingOutside.y+ j* (1+paddingBetween.y) )* unitHeight);

                int anElement = aPermutation [Random.Range(0,aPermutation.Count)];
                aPermutation.Remove(anElement);
                newUnit.GetComponent<Image>().sprite = cards [anElement];

                if (aPermutation.Count == 0) 
                {
                    for (int k = 0; k < cards.Length; k++)
                        aPermutation.Add(k);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
