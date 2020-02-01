using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    Transform playerTransform;
    Transform playerCameraTransform;
    Transform sceneTransform;
    bool pickedUp = false;

    void Start()
    {
        playerCameraTransform = Camera.main.transform;
        playerTransform = GameObject.Find("Player").transform;
        sceneTransform = GameObject.Find("PickableObjects").transform;
    }
    public void PickUp()
    {
        if (!pickedUp)
        {
            Debug.Log("PickUp object: " + this.GetComponent<Collider>().name);
            this.transform.parent = playerCameraTransform;
            this.GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    public void Drop()
    {
        Debug.Log("Release object: " + this.GetComponent<Collider>().name);
        this.transform.parent = sceneTransform;
        this.GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
