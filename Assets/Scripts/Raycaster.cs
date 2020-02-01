﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{    
    public float interactionDistance = 3f;
    Transform holdingItem;

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * interactionDistance);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance))
            {
                if (hit.collider.tag == "Interactable")
                {
                    Debug.Log("Interactable Object clicked");
                    if (hit.transform.gameObject.GetComponent<InteractableObject>() != null)
                        hit.transform.gameObject.GetComponent<InteractableObject>().Interact(holdingItem);

                }
                else if (hit.collider.tag == "Pickable")
                {
                    Debug.Log("Pickable Object clicked");
                    if (hit.transform.gameObject.GetComponent<PickableObject>() != null)
                    {
                        hit.transform.gameObject.GetComponent<PickableObject>().PickUp();
                        holdingItem = hit.transform;
                    }
                }                
            }
            else
            {
                Debug.Log("Nothing clicked");
                if (holdingItem != null)
                {
                    Debug.Log("Drop Item: " + holdingItem.GetComponent<Collider>().name);
                    if (holdingItem.gameObject.GetComponent<PickableObject>() != null)
                        holdingItem.gameObject.GetComponent<PickableObject>().Drop();
                    holdingItem = null;
                }

            }
        }         
    }
}
