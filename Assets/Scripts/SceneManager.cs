using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{    
    private static SceneManager _instance;

    public static SceneManager Instance {  get { return _instance; } }
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public bool marketingGoalDone = false;
    public bool legalGoalDone = false;
    public bool accountingGoalDone = false;
    public GameObject GameWon;


    public void SetMarketingGoalDone()
    {
        marketingGoalDone = true;
        FindObjectsOfType<ObjectiveUIManager>()[0].UpdateToggles();
        CheckWinningCondition();
    }
    public void SetLegalGoalDone()
    {
        legalGoalDone = true;
        FindObjectsOfType<ObjectiveUIManager>()[0].UpdateToggles();
        CheckWinningCondition();
    }
    public void SetAccountingGoalDone()
    {
        accountingGoalDone = true;
        FindObjectsOfType<ObjectiveUIManager>()[0].UpdateToggles();
        CheckWinningCondition();
    }         

    public void CheckWinningCondition()
    {
        if(accountingGoalDone && marketingGoalDone && legalGoalDone)
        {
            GameWon.SetActive(true);
        }
    }
}
