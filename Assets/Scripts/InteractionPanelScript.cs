using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractionPanelScript : MonoBehaviour
{
    public Raycaster raycaster;

    public FirstPersonController controller;

    public static InteractionPanelScript Instance { get; private set; }

    public TextMeshProUGUI dialogTextBox;

    public Button action1Button;

    public Button action2Button;

    public Button action3Button;

    public Text action1TextBox;

    public Text action2TextBox;

    public Text action3TextBox;

    private InteractableObject interactableObjectSendingTheDialog;

    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowInteraction(InteractableObject dialogSender, string dialogText, string action1Text, string action2Text, string action3Text)
    {
        dialogTextBox.SetText(dialogText);
        action1TextBox.text = action1Text;
        action2TextBox.text = action2Text;
        action3TextBox.text = action3Text;

        interactableObjectSendingTheDialog = dialogSender;

        DialogBoxEnabled(true);
    }

    private void DialogBoxEnabled(bool inDialog)
    {
        raycaster.enabled = !inDialog;
        controller.enabled = !inDialog;
        Cursor.lockState = inDialog ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = inDialog;
        gameObject.SetActive(inDialog);
    }

    public void Action1Clicked()
    {
        // print("Action 1 chosen");
        DialogBoxEnabled(false);
        interactableObjectSendingTheDialog.SetChoice(1);
        interactableObjectSendingTheDialog = null;
    }
    public void Action2Clicked()
    {
        // print("Action 2 chosen");
        DialogBoxEnabled(false);
        interactableObjectSendingTheDialog.SetChoice(2);
        interactableObjectSendingTheDialog = null;
    }
    public void Action3Clicked()
    {
        // print("Action 3 chosen");
        DialogBoxEnabled(false);
        interactableObjectSendingTheDialog.SetChoice(3);
        interactableObjectSendingTheDialog = null;
    }
}
