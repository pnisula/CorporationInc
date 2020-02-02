using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] paths;
    private Animator walkAnimator;
    int pathIndex = 0;
    bool pathSelected = false;
    UnityEngine.AI.NavMeshAgent agent;
    bool shouldMove;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = paths[0].position;
        walkAnimator = GetComponentInChildren<Animator>();

        shouldMove = true;
        walkAnimator.SetFloat("Speed", 1.0f);
        walkAnimator.SetBool("TimeToDance", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove && agent != null && !agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    Debug.Log("STOP");
                    shouldMove = false;
                    SelectNewWaypoint();
                }
            }
        }
    }
    void SelectNewWaypoint()
    {
        pathIndex++;
        if(pathIndex > paths.Length-1)
        {
            pathIndex = 0;
        }
        agent.destination = paths[pathIndex].position;
        shouldMove = true;
    }
}
