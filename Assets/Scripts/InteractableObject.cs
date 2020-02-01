using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public void Interact(Transform interactedWithItem)
    {
        if (interactedWithItem)
        {
            Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
        }
        else
        {
            Debug.Log("Interact object: " + this.name);

        }
    }
}
