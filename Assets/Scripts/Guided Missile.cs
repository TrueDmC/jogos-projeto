using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissile : MonoBehaviour
{

    public float propulsionIntensity;
    Transform gmPlayer;

    Vector3 Targetposition;

    Rigidbody rb;
    void Start() {

    gmPlayer = GameObject.FindWithTag("Player").GetComponent<Transform>();{
    rb = GetComponent<Rigidbody>();
	}
        
        
    void Update() {
            RaycastHit hit;
            if (Physics.Raycast(gmPlayer.position, gmPlayer.forward, out hit, Mathf.Infinity))
            {
                Targetposition = hit.point;
            }

            if (Targetposition.magnitude > 0.01f)
            transform.LookAt(Targetposition);

            rb.AddForce(transform.forward * propulsionIntensity, ForceMode.Force);
	}
    }
}



    