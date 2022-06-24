using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class MinionAI : MonoBehaviour
{
   
    public NavMeshAgent agent;
    public GameObject[] waypoints;
    private int currWaypoint = 0;

    public GameObject[] moving_waypoints;
    private int moving_currWaypoint = 0;

    private Animator anim;
    
    public AIState aiState;
    public enum AIState {
        Patrol,
        GoToMovingWaypoint
    };

    void Start()
    {
        anim = GetComponent<Animator>();
        // aiState = AIState.GoToMovingWaypoint;
        aiState = AIState.Patrol;
        if (aiState == AIState.GoToMovingWaypoint)
        {
            setNextWaypoint_moving();
        }
        
    }


    void Update()
    {
        switch (aiState){
            case AIState.Patrol:
                anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
                if ((agent.remainingDistance - agent.stoppingDistance < 2) && !agent.pathPending)
                    {
                    setNextWaypoint_stationary();
                    }
            break;
            case AIState.GoToMovingWaypoint:
                anim.SetFloat("vely", agent.velocity.magnitude / agent.speed);
                if ((agent.remainingDistance < 1) && !agent.pathPending)
                    {
                    setNextWaypoint_moving();
                    }
            break;
            default:
            break;
        }     

    }

    void setNextWaypoint_stationary()
    {
        if (currWaypoint > waypoints.Length - 1)
        {
            currWaypoint = 0;
        }
        Vector3 destination = waypoints[currWaypoint].transform.position;
        // TODO Add error handling if the array is zero length.
        setDestination(destination);
        currWaypoint++;
        if(currWaypoint == 5)
        {
            aiState = AIState.GoToMovingWaypoint;
        }

    }

    void setNextWaypoint_moving()
    {
        if (moving_currWaypoint > moving_waypoints.Length - 1)
        {
            moving_currWaypoint = 0;
        }
        Vector3 destination = moving_waypoints[moving_currWaypoint].transform.position;
        float distance = (destination - agent.transform.position).magnitude;
        float targetPosition = distance / agent.speed;
        setDestination(destination);
        moving_currWaypoint++;
        aiState = AIState.Patrol;

    }

    void setDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void ExecuteFootstep()
    {

        EventManager.TriggerEvent<MinionFootstepEvent, Vector3>(transform.position);
    }


}