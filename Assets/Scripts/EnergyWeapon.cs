using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeapon : MonoBehaviour
{
    [SerializeField] GameObject energyPrefab;
    [SerializeField] Transform fireLocation;

    public enum WeaponMode
    {
        Energy,
        Missile
    }
    private WeaponMode currentMode;

    void Start()
    {
        GameManager.instance.inputHandler.FireEventSubscribe(FireWeapon);
        currentMode = WeaponMode.Energy;
    }

    void Update()
    {
        
    }

    void FireWeapon(bool buttonDown) // instantiate projectile, send its goal after firing a raycast
    {
        if (buttonDown)
        {
            //Debug.Log("Fire Gun");
            GameObject newProjectile = Instantiate(energyPrefab, fireLocation.position, fireLocation.rotation);
        }
        //else
        //    Debug.Log("Stop firing");
    }
}
