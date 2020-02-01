using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectives : MonoBehaviour
{
    bool showObjectives = false;
    float time = 0.0f;

    Quaternion startRotation;
    Quaternion endRotation;

    // Update is called once per frame
    void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(-90.0f,0.0f,0.0f);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Show Objectives");
            showObjectives = true;            
        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Hide Objectives");
            showObjectives = false;
        }

        if(showObjectives)
        {
            time += Time.deltaTime;
            time = Mathf.Clamp(time, 0, 1.0f);            
        }
        else
        {
            time -= Time.deltaTime;
            time = Mathf.Clamp(time, 0, 1.0f);            
        }
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, time);
    }
}
