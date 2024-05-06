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

    //From The Tutorial 
    public float startWaitTime = 4;
    public float speedWalk = 160;

    //For the Enemy Detection / Attack
    public float viewRadius = 15;
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

    float m_WaitTime;
    float m_TimeToRotate;
    bool m_PlayerInRange;
    bool m_playerNear;
    bool m_IsPatrol;
    bool m_CaughtPlayer;

    void Start()
    {
        //Allows Enemy to Walk to it's destinations 
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();

        //For initalizing the attack
        m_PlayerPosition = Vector3.zero;
        m_IsPatrol = true;
        m_CaughtPlayer = false;
        m_PlayerInRange = false;
        m_WaitTime = startWaitTime;
        //m_TimeToRotate = timeToRotate;
        m_CurrentControlpointIndex = 0;
        agent.isStopped = false;
    }
    void Update()
    {
        //Allows enemy to walk to waypoints
        if (Vector3.Distance(transform.position, target) < 1)
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
    void CaughtPlayer()
    {
        m_CaughtPlayer = true;
    }
    void Move(float speed)
    {
        //When chasing the player, make sure the enemy doesn't stop
        agent.isStopped = false;
        agent.speed = speed;
    }
    void Stop()
    {
        //Just to stop the enemy movement
        agent.isStopped = true;
        agent.speed = 0;
    }
    public void NextPoint()
    {
        //Allows the enemy to go to the next waypoint after it stops chasing?
        m_CurrentControlpointIndex = (m_CurrentControlpointIndex + 1) % waypoints.Length;
        agent.SetDestination(waypoints[m_CurrentControlpointIndex].position);

    }
    void LookingPlayer(Vector3 player)
    {
        //Find and chase the player
        agent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (m_WaitTime <= 0)
            {
                m_playerNear = false;
                Move(speedWalk);
                agent.SetDestination(waypoints[waypointIndex].position);
                m_WaitTime = startWaitTime;
                //m_TimeToRotate = timeToRotate;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }
    void EnvironmentView()
    {
        //Adds a collider then allows the enemy to see the player
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToPlayer) < viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, obstacleMask))
                {
                    m_PlayerInRange = true;
                    m_IsPatrol = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > viewRadius)
            {
                m_PlayerInRange = false;
            }
            if (m_PlayerInRange)
            {
                m_PlayerPosition = player.transform.position;
            }
        }
    }
}
