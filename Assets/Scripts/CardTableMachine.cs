using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTableMachine : MonoBehaviour
{
    /*
    0 = wait for pick
    1 = item pick op
    2 = wait for release
    3 = item release & auto scroll op
    */

    CardTableState[] states;
    CardTableState currentState;

    byte animationState = 0; //0 none, 1 not completed, 2 completed
    byte oldStateIndex = 0;

    [SerializeField] Vector3 cardInspectionPosition;
    [SerializeField] Vector3 cardInspectionRotation;

    Vector3 cardPreviousPosition, cardPreviousRotation; 

    Transform inspectedCard;

    bool animationPickingDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        states = new CardTableState[4];
        states[0] = new WaitForPick();
        states[1] = new ItemPickOp();
        states[2] = new WaitForRelease();
        states[3] = new AutoScrollCardRelease();
        currentState = states[0];
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("old index is 0: " + (oldStateIndex== 0));
        bool clickPerform = oldStateIndex == 0 ? AnyCardSelected(out inspectedCard) : (oldStateIndex == 2 ? Input.GetMouseButtonDown(0) : false);
        byte currentStateIndex = currentState.Perform(clickPerform, animationState == 2);
        
        if (animationState == 2) animationState = 0;

        if (oldStateIndex == 0 && currentStateIndex == 1) //Fire -> picking animation
        {
            animationState = 1;
            cardPreviousPosition = inspectedCard.position;
            cardPreviousRotation = inspectedCard.eulerAngles;
            animationPickingDirection = true; 

        }

        if (oldStateIndex == 2 && currentStateIndex == 3) //Fire -> releasing animation
        {
            animationState = 1;
            animationPickingDirection = false;
        }

        currentState = states[currentStateIndex];
        oldStateIndex = currentStateIndex;

        if(animationState == 1) 
        {
            if (animationPickingDirection) 
            {
                inspectedCard.position = Vector3.Lerp(inspectedCard.position, cardInspectionPosition, 5 * Time.deltaTime);
                inspectedCard.eulerAngles = Vector3.Lerp(inspectedCard.eulerAngles, cardInspectionRotation, 5 * Time.deltaTime);

                if ((inspectedCard.position-cardInspectionPosition).sqrMagnitude < .001f) 
                {
                    animationState = 2;
                }
            }

            else 
            {
                inspectedCard.position = Vector3.Lerp(inspectedCard.position,cardPreviousPosition , 5 * Time.deltaTime);
                inspectedCard.eulerAngles = Vector3.Lerp(inspectedCard.eulerAngles, cardPreviousRotation, 5 * Time.deltaTime);

                if ((inspectedCard.position-cardPreviousPosition).sqrMagnitude < .001f) 
                {
                    animationState = 2;
                    inspectedCard = null;
                }

            }
        }
        

    }



    bool AnyCardSelected(out Transform hitCard) 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        if (hit.transform != null && hit.transform.CompareTag("Card") && Input.GetMouseButtonDown(0))
        {
            hitCard = hit.transform;
            return true;
        }

        hitCard = null;
        return false;
    }

}

abstract class CardTableState 
{
    public abstract byte Perform(bool clickPerfomed, bool animationHasEnded);
}

class WaitForPick: CardTableState 
{
    public override byte Perform(bool clickPerfomed, bool animationHasEnded)
    {
        if (clickPerfomed) 
        {
            return 1;
        }

        return 0;
    }
}


class ItemPickOp: CardTableState 
{
    public override byte Perform(bool clickPerfomed, bool animationHasEnded)
    {
        if (animationHasEnded) 
        {
            return 2;
        }

        return 1;
    }
}

class WaitForRelease: CardTableState 
{
    public override byte Perform(bool clickPerfomed, bool animationHasEnded)
    {
        if (clickPerfomed) 
        {
            return 3;
        }

        return 2;
    }
}

class AutoScrollCardRelease: CardTableState 
{
    public override byte Perform(bool clickPerfomed, bool animationHasEnded)
    {
        if (animationHasEnded) 
        {
            return 0;
        }

        return 3;
    }
}



