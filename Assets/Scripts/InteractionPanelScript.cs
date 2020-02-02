using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractionPanelScript : MonoBehaviour
{
    public Raycaster raycaster;
    public GameObject GameWonCanvas;
    public FirstPersonController controller;

    public static InteractionPanelScript Instance { get; private set; }

    public TextMeshProUGUI dialogTextBox;

    public Button action1Button;

    public Button action2Button;

    public Button action3Button;

    public Text action1TextBox;

    public Text action2TextBox;

    public Text action3TextBox;

    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowInteraction(string dialogText, string responseText)
    {
        action1TextBox.text = responseText;

        DialogBoxEnabled(true);

        StopAllCoroutines();
        StartCoroutine(WriteTextWithDelay(dialogText));
    }

    IEnumerator WriteTextWithDelay(string text)
    {
        dialogTextBox.text = "";
        foreach(char c in text.ToCharArray())
        {
            dialogTextBox.text += c;
            yield return null;
        }

        yield return null;
    }

    private void DialogBoxEnabled(bool inDialog)
    {
        raycaster.enabled = !inDialog;
        controller.enabled = !inDialog;
        Cursor.lockState = inDialog ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = inDialog;
        gameObject.SetActive(inDialog);
    }

    public void OKClicked()
    {
        // print("Action 1 chosen");
        DialogBoxEnabled(false);
        if(SceneManager.Instance.GameWonCondition)
        {
            GameWonCanvas.SetActive(true);
            /*controller.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            raycaster.enabled = false;
            */
        }
    }
}
