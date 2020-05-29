using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    
    public float minimumDistance;
    NavMeshAgent agenteNM;

    void Awake()
    {
        agenteNM = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 PlayerLocal = FPSMove.Floorpoint;
        agenteNM.SetDestination(PlayerLocal);

        float minimumDistanceBetweenPlayerandEnemy = Vector3.Distance(transform.position, PlayerLocal);
        if(minimumDistanceBetweenPlayerandEnemy <= minimumDistance) {
            agenteNM.isStopped = true;
        } else {
            agenteNM.isStopped = false;
        }
    }
}
