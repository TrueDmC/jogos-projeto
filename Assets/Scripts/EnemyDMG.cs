using UnityEngine;
using System.Collections;

public class EnemyDMG : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            float damage = Mathf.Round(Random.Range(10f, 20f));
            Blood blood = other.gameObject.GetComponent<Blood>();
            blood.DrawLife(damage);

            if (other.CompareTag("Enemy"))
            {
                if (blood.blood <= 0)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}