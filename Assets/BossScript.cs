using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public enum Responses { Nothing, SpawnObject, GiveMarketingSignature, GiveAccountingSignature, GiveLegalSignature, PlayVinyl }

    public List<PhaseData> nextPhases = new List<PhaseData>();

    [SerializeField]
    private Responses responseAfterObjectiveCompleted = Responses.Nothing;

    [SerializeField]
    private bool canTalk = true;

    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private string dialogText;

    [SerializeField]
    private string responseText;

    [SerializeField]
    private string questFinishedResponse;
    

    public void Interact(Transform interactedWithItem)
    {        
        if (SceneManager.Instance.CheckWinningCondition())
        {
            InteractionPanelScript.Instance.ShowInteraction(questFinishedResponse, responseText);
            SceneManager.Instance.GameWonCondition = true;
        }        
        else
        {
            InteractionPanelScript.Instance.ShowInteraction(dialogText, responseText);
        }
    }

    [System.Serializable]
    public class PhaseData
    {
        public Responses responseAfterObjectiveCompleted;
        public GameObject spawnObject;
        public string dialogText;
        public string responseText;
        public string questFinishedResponse;
    }
}
