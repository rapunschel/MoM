using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] players;

    [SerializeField] LayerMask groundLayer, playerLayer;

    // Patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    // State change
    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerInAttackRange;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        // Check if any player is in sight or in attack range
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInSight = false;
        playerInAttackRange = false;

        foreach (GameObject player in players)
        {
            if (player == null) continue;

            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= sightRange)
            {
                playerInSight = true;
                break;
            }
            if (distanceToPlayer <= attackRange)
            {
                playerInAttackRange = true;
                break;
            }
        }

        if (!playerInSight && !playerInAttackRange)
        {
            Patrol();
        }
        if (playerInSight && !playerInAttackRange)
        {
            Chase();
        }
    }

    void Chase()
    {
        GameObject nearestPlayer = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            if (player == null) continue;

            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null)
        {
            NavMeshPath path = new NavMeshPath();
            if (agent.CalculatePath(nearestPlayer.transform.position, path) && path.status == NavMeshPathStatus.PathComplete)
            {
                agent.SetDestination(nearestPlayer.transform.position);
                Debug.Log("Chasing player at position: " + nearestPlayer.transform.position);
            }
            else
            {
                Debug.LogWarning("Path to player is not complete or invalid");
            }
        }
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet)
        {
            NavMeshPath path = new NavMeshPath();
            if (agent.CalculatePath(destPoint, path) && path.status == NavMeshPathStatus.PathComplete)
            {
                agent.SetDestination(destPoint);
                Debug.Log("Patrolling to point: " + destPoint);
            }
            else
            {
                walkpointSet = false;
                Debug.LogWarning("Path to patrol point is not complete or invalid");
            }
        }

        if (Vector3.Distance(transform.position, destPoint) < 2f)
        {
            walkpointSet = false;
        }
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        Vector3 randomPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            destPoint = hit.position;
            walkpointSet = true;
            Debug.Log("New patrol destination set: " + destPoint);
        }
        else
        {
            walkpointSet = false;
            Debug.LogWarning("Invalid patrol destination: " + randomPoint);
        }
    }
}
