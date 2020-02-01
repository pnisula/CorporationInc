using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    enum ActionFunctions { TestPrintHelloThere, TestPrintABCDEFGH}

    [SerializeField]
    private bool canTalk = true;

    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private string dialogText;

    [SerializeField]
    private string firstChoiceText;

    [SerializeField]
    private string secondChoiceText;

    [SerializeField]
    private string thirdChoiceText;

    [SerializeField]
    private string itemNeededToProgress;

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
            if (interactedWithItem.name == itemNeededToProgress)
            {
                Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction(this, "Thank you for the " + interactedWithItem.name + ".", "Ok.", "", "");
                Spawn(interactedWithItem.position);

                Destroy(interactedWithItem.gameObject);
            }
            else
            {
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction(this, "I don't need your " + interactedWithItem.name + ". Leave me alone.", "Ok.", "", "");
            }
        }
        else
        {
            Debug.Log("Interact object: " + this.name);

            if (canTalk)
                InteractionPanelScript.Instance.ShowInteraction(this, dialogText, firstChoiceText, secondChoiceText, thirdChoiceText);
        }
    }

    void Spawn(Vector3 pos)
    {
        var x = Instantiate(spawnObject, pos, Quaternion.identity);
        x.name = x.name.Replace("(Clone)", "");
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
