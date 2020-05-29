using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public bool Destroywhentouch;
    public GameObject ExplosionEffect;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy") {
            Blood blood = col.gameObject.GetComponent<Blood>();
            blood.blood = blood.blood - 300;
        }

        {
            if (Destroywhentouch)
                Instantiate(ExplosionEffect);
            Destroy(gameObject);
        }

    }

}