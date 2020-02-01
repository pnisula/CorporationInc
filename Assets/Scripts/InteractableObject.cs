using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    enum ActionFunctions { TestPrintHelloThere, TestPrintABCDEFGH}

    [SerializeField]
    private string dialogText;

    [SerializeField]
    private string firstChoiceText;

    [SerializeField]
    private string secondChoiceText;

    [SerializeField]
    private string thirdChoiceText;

    [SerializeField]
    private bool canInteractWithItem;

    [SerializeField]
    private ActionFunctions action1Function;

    [SerializeField]
    private ActionFunctions action2Function;

    [SerializeField]
    private ActionFunctions action3Function;

    public void Interact(Transform interactedWithItem)
    {
        if (interactedWithItem)
        {
            if (canInteractWithItem)
            {
                Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
            }
            else
            {
                InteractionPanelScript.Instance.ShowInteraction(this, "I don't need your " + interactedWithItem.name + ". Leave me alone.", "Ok.", "", "");
            }
        }
        else
        {
            Debug.Log("Interact object: " + this.name);
            InteractionPanelScript.Instance.ShowInteraction(this, dialogText, firstChoiceText, secondChoiceText, thirdChoiceText);
        }
    }

    public void SetChoice(int choiceChosen)
    {
        switch(choiceChosen)
        {
            case 1:
                switch(action1Function)
                {
                    case ActionFunctions.TestPrintABCDEFGH:

                        break;

                    case ActionFunctions.TestPrintHelloThere:

                        break;
                }
                break;

            case 2:

                break;

            case 3:

                break;

            default:

                break;
        }
    }

}
