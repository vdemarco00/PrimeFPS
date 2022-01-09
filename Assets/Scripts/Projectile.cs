using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] EnergyWeapon.WeaponMode projectileType;
    [SerializeField] float damageGiven;
    [SerializeField] float forceApplied;
    [SerializeField] float movementSpeed;
    [SerializeField] float destructTime;

    public bool moving;

    private void Awake()
    {
        moving = false;
        destructTime = destructTime + Time.time;
    }

    void Update()
    {
        if (moving) // move gameobject towards its goal
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        if (Time.time > destructTime)
            Destroy(gameObject);
    }

    public void SetData(ProjectileData newData)
    {
        damageGiven = newData.damageGiven;
        movementSpeed = newData.movementSpeed;
        forceApplied = newData.forceApplied;
        destructTime = newData.destructTime;
    }

    private void OnTriggerEnter(Collider other) // apply damage and force
    {
        if (other.tag != "Player")
        {
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceApplied, ForceMode.Impulse);
            }
            if (other.gameObject.GetComponent<DestructibleObject>() != null)
            {
                other.gameObject.GetComponent<DestructibleObject>().ApplyDamage(damageGiven);
            }
            Destroy(gameObject);
        }
    }

}
