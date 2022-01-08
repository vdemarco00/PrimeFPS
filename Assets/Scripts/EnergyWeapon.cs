using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyWeapon : MonoBehaviour
{
    [SerializeField] GameObject energyPrefab;
    [SerializeField] Transform fireLocation;
    [SerializeField] float chargeTime;
    float chargeThreshold;
    bool firing;
    Animator animator;

    GameObject chargeProjectile;

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
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (currentMode == WeaponMode.Energy)
        {
            if (firing)
            {
                if (Time.time > chargeThreshold && chargeProjectile == null && chargeThreshold != 0)
                {
                    chargeProjectile = Instantiate(energyPrefab, fireLocation.position, fireLocation.rotation, fireLocation);
                }
            }
            else
            {
                if (chargeProjectile != null)
                {
                    chargeProjectile.transform.parent = null;
                    chargeProjectile.GetComponent<Projectile>().moving = true;
                }
            }
        }
    }

    void FireWeapon(bool buttonDown) // instantiate projectile, send its goal after firing a raycast
    {
        firing = buttonDown;
        if (firing)
        {
            animator.SetTrigger("fire");
            GameObject newProjectile = Instantiate(energyPrefab, fireLocation.position, fireLocation.rotation);
            newProjectile.GetComponent<Projectile>().moving = true;
            chargeThreshold = Time.time + chargeTime;
        }
        else
        {
            chargeThreshold = 0;
        }
    }
}
