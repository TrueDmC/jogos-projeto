using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class IA : MonoBehaviour
{

    public GameObject player;
    public enum IAState
    {
        Attacking,
        Walking,
    }


    private NavMeshAgent navMesh;
    public IAState State;
    public float damage;
    public Animator AnimationControl;
    Blood bloodPlayer;
    Blood blood;

    SistemaSom sistemaSom;

    void Start ()
    {

        player = GameObject.FindWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
    }
    void Awake()
    {
       // player = GetComponent<NavMeshAgent>();
        blood = GetComponent<Blood>();
        bloodPlayer = GameObject.FindWithTag ("Player"). GetComponent<Blood>();
    

    }

    void Update()
    {

        navMesh.destination = player.transform.position;
      
    
        if (navMesh.isStopped)
        {
            State = IAState.Attacking;
        }
        else
        {
            State = IAState.Walking;
        }

        if (State == IAState.Attacking) {
            bloodPlayer.blood = bloodPlayer.blood - damage * Time.deltaTime;
        }

        AnimationControl.SetFloat("velocidade", navMesh.velocity.magnitude);


        if (blood.blood <= 0)
        {
            {
                Destroy(gameObject);

            }
        }
    }
}
