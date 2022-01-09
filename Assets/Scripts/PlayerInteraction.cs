using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    bool holdingItem;
    [SerializeField] GameObject cam;
    [SerializeField] float interactionDistance;


    public delegate void MovementStateEvent(bool active);
    MovementStateEvent movementStateEvent;

    public delegate void WeaponStateEvent(bool active);
    WeaponStateEvent weaponStateEvent;

    void Start()
    {
        GameManager.instance.inputHandler.InteractEventSubscribe(Interact);
    }

    void Interact()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionDistance))
        {
            if (true)
            {
                Debug.Log("interact with " + hit.collider.name);

            }
        }
    }

    public void WeaponEventSubscribe(WeaponStateEvent newMethod)
    {
        weaponStateEvent += newMethod;
    }

    public void MovementEventSubscribe(MovementStateEvent newMethod)
    {
        movementStateEvent += newMethod;
    }

}
