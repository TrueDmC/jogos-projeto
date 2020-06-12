using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    
    public float Healthfull = 1000f;
    public float currentHealth = 0f;
    public bool alive = true;

     void Start()
    {
        alive = true;
        currentHealth = Healthfull;
        InvokeRepeating("DoDMG", 1f, 6f);
    }


    void DoDMG()
    {
        TakeDMG(20f);
    }


    public void TakeDMG(float amount)



    {
        if (!alive)
        {
            return;
        }


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            alive = false;
            gameObject.SetActive(false);
        }

        {
            currentHealth -= amount;
        }

       
    }
}

