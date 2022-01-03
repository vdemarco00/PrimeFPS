using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] EnergyWeapon.WeaponMode projectileType;
    [SerializeField] float damageGiven;
    [SerializeField] float forceApplied;
    [SerializeField] float movementSpeed;
    [SerializeField] float maxDistance;
    private Vector3 goalPosition;

    bool moving;
    private void Awake()
    {
        moving = false;
    }

    void Update()
    {
        if (moving) // move gameobject towards its goal
        {
            //transform.position = Vector3.MoveTowards()
        }
    }

    public void SetGoal(Vector3 newGoal)
    {
        goalPosition = newGoal;
        moving = true;
    }

    private void OnTriggerEnter(Collider other) // apply damage and force
    {
        
    }

}
