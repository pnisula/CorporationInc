using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloorNumberChanger : MonoBehaviour
{
    public Animator handAnimator;
    public TextMeshProUGUI floorNumberText;
    public GameObject doorLeft;
    public GameObject doorRight;
    public int maxNumberOfFloors = 5;
    float time = 0.0f;
    int floorNumber = 0;
    bool doorsOpen;
    // Update is called once per frame
    void Update()
    {
        if ((int)time < maxNumberOfFloors)
        { 
            time += Time.deltaTime;
            Mathf.Clamp(time, 0.0f, 12.0f);

            floorNumber = (int)time;
            floorNumberText.text = floorNumber.ToString();
            handAnimator.SetBool("HandInFront", true);
        }
        if(!doorsOpen && floorNumber == maxNumberOfFloors)
        {
            doorsOpen = true;
            handAnimator.SetBool("HandInFront", false);
            doorLeft.SetActive(false);
            doorRight.SetActive(false);
        }
    }
}
