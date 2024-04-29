using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AikoNEWEnemyAIScript : MonoBehaviour
{
    //For the waypoints
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    //For the Enemy Detection / Attack
    public float viewRaadius = 15;
    public float viewAngle = 90;
    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public float meshResolution = 1f;
    public int edgeIterations = 4;
    public float edgeDistance = 0.5f;

    public Transform[] controlPoint;
    int m_CurrentControlpointIndex;

    Vector3 playerLastPosisiton = Vector3.zero;
    Vector3 m_PlayerPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
 }
