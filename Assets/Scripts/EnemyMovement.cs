using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    public float minimumDistance;
    NavMeshAgent player;

    void Awake()
    {
        player = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 PlayerLocal = FPSMove.Floorpoint;
        player.SetDestination(PlayerLocal);

        float minimumDistanceBetweenPlayerandEnemy = Vector3.Distance(transform.position, PlayerLocal);
        if(minimumDistanceBetweenPlayerandEnemy <= minimumDistance) {
            player.isStopped = true;
        } else {
            player.isStopped = false;
        }
    }
}
