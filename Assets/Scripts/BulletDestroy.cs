using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public bool Destroywhentouch;
    public GameObject ExplosionEffect;

    void OnCollisionEnter(Collision col) {
        if (Destroywhentouch)
            Instantiate(ExplosionEffect);
            Destroy(gameObject);

	}
}
