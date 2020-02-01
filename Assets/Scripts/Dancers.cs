using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancers : MonoBehaviour
{
    private Animator danceAnimator;
    public Transform DancingLocation;    
    bool pathSelected = false;
    UnityEngine.AI.NavMeshAgent agent;
    
    // Start is called before the first frame update
    void GoDancing()
    {
        danceAnimator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = DancingLocation.position;
    }
    void Dance()
    {
        danceAnimator.SetBool("Dance", true);
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
                    Dance();           
                }
            }
        }
    }    
}
