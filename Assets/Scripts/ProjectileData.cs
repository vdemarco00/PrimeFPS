using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ProjectileData : ScriptableObject
{
    public float damageGiven;
    public float forceApplied;
    public float movementSpeed;
    public float destructTime;
}
