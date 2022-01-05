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
    [SerializeField] float destructTime;
    private Vector3 goalPosition;

    bool moving;
    private void Awake()
    {
        moving = true;
        destructTime = destructTime + Time.time;
    }

    void Update()
    {
        if (moving) // move gameobject towards its goal
        {
            //transform.position = Vector3.MoveTowards()
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Time.time > destructTime)
            Destroy(gameObject);
    }

    public void SetGoal(Vector3 newGoal)
    {
        goalPosition = newGoal;
        moving = true;
    }

    private void OnTriggerEnter(Collider other) // apply damage and force
    {
        if (other.tag != "Player")
            Destroy(gameObject);
    }

}
