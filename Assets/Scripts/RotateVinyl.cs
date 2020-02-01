using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateVinyl : MonoBehaviour
{    
    // Update is called once per frame
    void Update()
    {        
        this.transform.Rotate(0.0f, 10*Time.deltaTime, 0.0f, Space.World);
    }
}
