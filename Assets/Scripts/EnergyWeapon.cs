using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeapon : MonoBehaviour
{
    private enum WeaponMode
    {
        Energy
    }
    void Start()
    {
        GameManager.instance.inputHandler.FireEventSubscribe(FireWeapon);
    }

    void Update()
    {
        
    }

    void FireWeapon()
    {
        Debug.Log("Fire Gun");
    }
}
