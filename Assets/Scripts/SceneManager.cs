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
    private bool playRecord;
    public bool marketingGoalDone = false;
    public bool legalGoalDone = false;
    public bool accountingGoalDone = false;
    public GameObject GameWon;
    public GameObject Player;
    public GameObject DJCamera;
    public GameObject Teller;
    public float timePlayed;
    public float maxTimeForPlaying = 10f;
    public bool VIPGuyIsHappy = false;

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

    public void PlayVinyl()
    {
        Debug.Log("Play Vinyl");

        Player.SetActive(false);
        DJCamera.SetActive(true);
        Teller.SetActive(true);
        playRecord = true;
        GameObject[] Dancers = GameObject.FindGameObjectsWithTag("Dancers");
        foreach (GameObject dancer in Dancers)
        {
            dancer.GetComponentInChildren<Dancers>().GoDancing();
        }
    }
    public void BookStolen()
    {
        GameObject[] crowd = GameObject.FindGameObjectsWithTag("Crowd");
        foreach (GameObject person in crowd)
        {            
            person.GetComponentInChildren<Animator>().SetBool("BookLost",true);            
        }
        GameObject comedian = GameObject.FindGameObjectWithTag("Comedian");
        comedian.GetComponentInChildren<Animator>().SetBool("BookLost", true);
    }
    void Update()
    {
        if(playRecord)
        {
            timePlayed += Time.deltaTime;
            if(timePlayed>maxTimeForPlaying)
            {
                StopVinyl();
                VIPGuyIsHappy = true;
            }
        }
    }
    public void StopVinyl()
    {
        playRecord = false;
        Player.SetActive(true);
        DJCamera.SetActive(false);
        Teller.SetActive(false);
    }
}
