using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{    
    public float interactionDistance = 3f;
    public bool imnear;

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
                    Debug.Log(hit.collider.name);
                }
                
            }
        
        }         
    }
}
