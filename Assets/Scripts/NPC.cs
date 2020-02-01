using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] paths;

    int pathIndex = 0;
    bool pathSelected = false;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = paths[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    pathIndex++;
                    if(pathIndex>paths.Length-1)
                    {
                        pathIndex = 0;
                    }
                    if(!pathSelected)
                    {
                        pathSelected = true;
                        StartCoroutine("SelectNextWaypoint");
                    }                    
                }
            }
        }
    }
    IEnumerator SelectNextWaypoint()
    {
        float waitTime = Random.Range(1.0f, 10.0f);
        Debug.Log("NPC waiting "+waitTime);        
        yield return new WaitForSeconds(waitTime);

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = paths[pathIndex].position;
        pathSelected = false;
    }
}
