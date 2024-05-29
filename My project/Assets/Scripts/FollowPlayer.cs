using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float patrolRange = 10f;
    public float chaseRange = 5f;

    private NavMeshAgent agent;
    private Vector3 patrolPosition;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else if (isChasing && distanceToPlayer > patrolRange)
        {
            StopChasing();
        }
        else if (!isChasing && distanceToPlayer > patrolRange)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 randomPoint = Random.insideUnitSphere * patrolRange;
            randomPoint += patrolPosition;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomPoint, out hit, patrolRange, 1);
            Vector3 targetPosition = hit.position;
            agent.SetDestination(targetPosition);
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
        isChasing = true;
    }

    void StopChasing()
    {
        agent.SetDestination(patrolPosition);
        isChasing = false;
    }
}
