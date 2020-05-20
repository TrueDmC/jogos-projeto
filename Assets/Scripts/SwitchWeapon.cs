using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
  public GameObject[] AllWeapons;
  int WeaponinUse;

  void Update() {
        if (Input.GetMouseButtonDown(1)) {
        Switch();

        }
      }

        void Switch() {
        WeaponinUse = (WeaponinUse + 1) % 8;

        for (int i = 0; i < AllWeapons.Length; i++) {
        if (i !=WeaponinUse) {
        AllWeapons[i].SetActive(false); 
        } else {
            AllWeapons[i].SetActive(true);
        }
     }
    }
}
