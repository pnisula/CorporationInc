using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUIManager : MonoBehaviour
{
    public Toggle marketingToggle;
    public Toggle legalToggle;
    public Toggle accountingToggle;

    public void UpdateToggles()
    {
        marketingToggle.isOn = SceneManager.Instance.marketingGoalDone;
        legalToggle.isOn = SceneManager.Instance.legalGoalDone;
        accountingToggle.isOn = SceneManager.Instance.accountingGoalDone;
    }
}
