using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public enum IAState
    {
        Attacking,
        Walking,
    }

    public IAState State;
    public float damage;
    public Animator AnimationControl;
    Blood bloodPlayer;
    NavMeshAgent agenteNM;
    Blood blood;

    void Awake()
    {
        agenteNM = GetComponent<NavMeshAgent>();
        blood = GetComponent<Blood>();
        bloodPlayer = GameObject.FindWithTag ("Player"). GetComponent<Blood>();
    }

    void Update()
    {


        if (agenteNM.isStopped)
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

        AnimationControl.SetFloat("velocidade", agenteNM.velocity.magnitude);


        if (blood.blood <= 0)
        {
            {
                Destroy(gameObject);

            }
        }
    }
}
