using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    Transform playerTransform;
    Transform playerCameraTransform;
    Transform sceneTransform;
    bool pickedUp = false;

    private Vector3 initialPos;

    void Start()
    {
        initialPos = transform.position;

        playerCameraTransform = Camera.main.transform;
        playerTransform = GameObject.Find("Player").transform;
        sceneTransform = GameObject.Find("PickableObjects").transform;
    }

    private void Update()
    {
        if (transform.position.y <= -100f)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = initialPos + new Vector3(0, 1, 0);
        }
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
        Vector3 forward = transform.parent.forward;

        Debug.Log("Release object: " + this.GetComponent<Collider>().name);
        this.transform.parent = sceneTransform;
        this.GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = forward * 5;
    }
}
