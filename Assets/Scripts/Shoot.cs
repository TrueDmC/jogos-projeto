using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   public GameObject disparo;
   public Transform localdisparo;
   public float Forcadodisparo, pausa;
   public bool auto;

   float timerone, timertwo;

   void Start() {
   
    timerone = Time.time;
    timertwo = timerone;

   }

   void Update() {

        timertwo = Time.time;

        if (timertwo - timerone <= pausa)
        
        {

            return;
        }

        bool startShoot = false;

        if (auto) {
        startShoot = Input.GetMouseButton(0);
      } else {
        startShoot = Input.GetMouseButtonDown(0);
        }
       if (startShoot) {
       timerone = timertwo;

        Disparar();
       }
           
   }

    void Disparar() {
       GameObject disparando = Instantiate<GameObject>(disparo, localdisparo.position, transform.rotation);
       
       Rigidbody disparando_rb = disparando.GetComponent<Rigidbody>();

       disparando_rb.AddForce(transform.forward * Forcadodisparo, ForceMode.Impulse);
}

  
   }
