using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanelScript : MonoBehaviour
{
    private TextMeshProUGUI dialogText;

    private Button action1;

    private Button action2;

    private Button action3;

    private Text action1Text;

    private Text action2Text;

    private Text action3Text;

    void Start()
    {
        dialogText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }
}
