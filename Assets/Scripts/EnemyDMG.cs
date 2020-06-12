
using UnityEngine;
using System.Collections;


public class EnemyDMG : MonoBehaviour


{

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            float damage = Mathf.Round(Random.Range(10f, 20f));
        other.gameObject.GetComponent<PlayerHealth>().TakeDMG(damage);



        }
    }
}
   