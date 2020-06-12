using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public float blood;
    //public SoundSystem.SoundEffect DmgSound;

    //SoundSystem SoundSystem;

    void Awake()
    {
        // soundSystem = GameObject.FindWithTag("MainCamera").GetComponent<SoundSystem>();
    }

    public void DrawLife(float DMG)
    {
        blood = blood - DMG;
        //  soundSystem.turnOn(DmgSound);
    }
}