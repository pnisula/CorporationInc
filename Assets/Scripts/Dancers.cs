using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancers : MonoBehaviour
{
    private Animator danceAnimator;
    public Transform DancingLocation;    
    bool pathSelected = false;
    UnityEngine.AI.NavMeshAgent agent;
    bool shouldMove = false;
    // Start is called before the first frame update
    public void GoDancing()
    {
        Debug.Log("Go Dancing");
        danceAnimator = GetComponentInChildren<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = DancingLocation.position;        
        shouldMove = true;
        danceAnimator.SetBool("Walking", true);
        danceAnimator.SetBool("TimeToDance", false);
    }
    void Dance()
    {        
        danceAnimator.SetBool("TimeToDance", true);
        danceAnimator.SetBool("Walking", false);
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
                    Dance();                    
                }
            }
        }
    }    
}
