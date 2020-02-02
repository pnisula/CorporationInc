using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public float interactionDistance = 3f;
    Transform holdingItem;

    public GameObject interactText;

    public GameObject pickupText;

    void Update()
    {
        RaycastHit hitForInteractPopup;
        if (Physics.Raycast(transform.position, transform.forward, out hitForInteractPopup, interactionDistance, ~(1 << 8)))
        {
            // print("Raycast hit: " + hitForInteractPopup.collider.gameObject.name);

            if (hitForInteractPopup.collider.CompareTag("Interactable"))
            {
                interactText.SetActive(true);
                pickupText.SetActive(false);
            }

            if (hitForInteractPopup.collider.CompareTag("Pickable"))
            {
                pickupText.SetActive(true);
                interactText.SetActive(false);
            }
            if (hitForInteractPopup.collider.CompareTag("VIP"))
            {
                pickupText.SetActive(true);
                interactText.SetActive(false);
            }
        }
        else
        {
            interactText.SetActive(false);
            pickupText.SetActive(false);
        }

        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * interactionDistance);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, ~(1 << 8)))
            {
                print("Raycast hit: " + hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Interactable"))
                {
                    Debug.Log("Interactable Object clicked");
                    if (hit.transform.gameObject.GetComponent<InteractableObject>() != null)
                        hit.transform.gameObject.GetComponent<InteractableObject>().Interact(holdingItem);

                }
                else if (hit.collider.CompareTag("Pickable"))
                {
                    Debug.Log("Pickable Object clicked");
                    if (hit.transform.gameObject.GetComponent<PickableObject>() != null)
                    {
                        hit.transform.gameObject.GetComponent<PickableObject>().PickUp();
                        holdingItem = hit.transform;
                    }
                }
                else if (hit.collider.CompareTag("VIP"))
                {
                    if (hit.transform.gameObject.GetComponent<VIPCustomScript>() != null)
                        hit.transform.gameObject.GetComponent<VIPCustomScript>().Interact(holdingItem);
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


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.Instance.SetMarketingGoalDone();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.Instance.SetLegalGoalDone();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.Instance.SetAccountingGoalDone();
        }
    }
}
