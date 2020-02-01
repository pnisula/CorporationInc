using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private string dialogText;

    [SerializeField]
    private string firstChoiceText;

    [SerializeField]
    private string secondChoiceText;

    [SerializeField]
    private string thirdChoiceText;

    public void Interact(Transform interactedWithItem)
    {
        if (interactedWithItem)
        {
            Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
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
