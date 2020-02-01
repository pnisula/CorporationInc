using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectives : MonoBehaviour
{
    private Animator handAnimator;
    bool showObjectives = false;
    
    void Start()
    {        
        handAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Show Objectives");
            handAnimator.SetBool("HandInFront", true);

        }
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Hide Objectives");
            handAnimator.SetBool("HandInFront", false);
        }        
    }
}
