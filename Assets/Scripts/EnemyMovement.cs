using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrol
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Suspicion
    public float searchRange = 4.0f, aggroRange = 1.0f;
    public bool playerInSearchRange, playerInAggroRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObject").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        agent.isStopped = false;
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3 (transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void Suspicion()
    {

        agent.isStopped = true;

    }

    private void Aggro()
    {
        agent.isStopped = false;
        transform.LookAt(player);
        agent.SetDestination(player.position);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSearchRange = Physics.CheckSphere(transform.position, searchRange, whatIsPlayer);
        playerInAggroRange = Physics.CheckSphere(transform.position, aggroRange, whatIsPlayer);

        if (!playerInSearchRange && !playerInAggroRange) Patrolling();
        if (playerInSearchRange && !playerInAggroRange) Suspicion();
        if (playerInSearchRange && playerInAggroRange) Aggro();
    }
}
