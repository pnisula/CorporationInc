using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum Responses { Nothing, SpawnObject, GiveMarketingSignature, GiveAccountingSignature, GiveLegalSignature, PlayVinyl}

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
    private string itemNeededToProgress;

    [SerializeField]
    private string questFinishedResponse;

    private bool interactable = true;

    public void Interact(Transform interactedWithItem)
    {
        if (!interactable)
            return;

        if (interactedWithItem)
        {
            if (interactedWithItem.name == itemNeededToProgress)
            {
                Debug.Log("Interact object: " + this.name + " with item: " + interactedWithItem.gameObject.name);
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction("Thank you for the " + interactedWithItem.name + "." + questFinishedResponse, "Continue");

                switch(responseAfterObjectiveCompleted)
                {
                    case Responses.Nothing:
                        // do nothing (obviously)
                        break;
                    case Responses.SpawnObject:
                        Spawn(interactedWithItem.position);
                        break;
                    case Responses.GiveMarketingSignature:
                        SceneManager.Instance.SetMarketingGoalDone();
                        break;
                    case Responses.GiveAccountingSignature:
                        SceneManager.Instance.SetAccountingGoalDone();
                        break;
                    case Responses.GiveLegalSignature:
                        SceneManager.Instance.SetLegalGoalDone();
                        break;
                    case Responses.PlayVinyl:
                        SceneManager.Instance.PlayVinyl();
                        break;
                }

                Destroy(interactedWithItem.gameObject);

                if (nextPhases.Count != 0)
                {
                    responseAfterObjectiveCompleted = nextPhases[0].responseAfterObjectiveCompleted;
                    spawnObject = nextPhases[0].spawnObject;
                    dialogText = nextPhases[0].dialogText;
                    responseText = nextPhases[0].responseText;
                    itemNeededToProgress = nextPhases[0].itemNeededToProgress;
                    questFinishedResponse = nextPhases[0].questFinishedResponse;

                    nextPhases.RemoveAt(0);
                }
                else
                {
                    // it means it reached the end of the interaction and it has nothing else to say

                    print("Response queue is empty. Object is now set to non interactable");
                    interactable = false;
                }
            }
            else
            {
                if (canTalk)
                    InteractionPanelScript.Instance.ShowInteraction("I don't need your " + interactedWithItem.name + ". Leave me alone. I need " + itemNeededToProgress, "Ok.");
            }
        }
        else
        {
            Debug.Log("Interact object: " + this.name);

            if (canTalk)
                InteractionPanelScript.Instance.ShowInteraction(dialogText, responseText);
        }
    }

    void Spawn(Vector3 pos)
    {
        if (spawnObject)
        {
            var x = Instantiate(spawnObject, pos, Quaternion.identity);
            x.name = x.name.Replace("(Clone)", "");
        }
    }

    [System.Serializable]
    public class PhaseData
    {
        public Responses responseAfterObjectiveCompleted;
        public GameObject spawnObject;
        public string dialogText;
        public string responseText;
        public string itemNeededToProgress;
        public string questFinishedResponse;
    }
}
