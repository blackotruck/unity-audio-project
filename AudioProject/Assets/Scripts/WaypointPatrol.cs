using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int _CurrentWaypointIndex;
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
        }
    }
}
