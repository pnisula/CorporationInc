using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private bool canTalk = true;

    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private string dialogText;

    [SerializeField]
    private string responseText;

    [SerializeField]
    private string itemNeededToProgress;

    public void Interact(Transform interactedWithItem)
    {
        if (interactedWithItem)
        {
            if (interactedWithItem.name == itemNeededToProgress)
            {
                Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction("Thank you for the " + interactedWithItem.name + ".", "Continue");
                Spawn(interactedWithItem.position);

                Destroy(interactedWithItem.gameObject);
            }
            else
            {
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction("I don't need your " + interactedWithItem.name + ". Leave me alone. I need " + itemNeededToProgress, "Ok.");
            }
        }
        else
        {
            Debug.Log("Interact object: " + this.name);

            if (canTalk)
                InteractionPanelScript.Instance.ShowInteraction(dialogText, "Ok");
        }
    }

    void Spawn(Vector3 pos)
    {
        if (spawnObject)
        {
            var x = Instantiate(spawnObject, pos, Quaternion.identity);
            x.name = x.name.Replace("(Clone)", "");
        }
    }
}
