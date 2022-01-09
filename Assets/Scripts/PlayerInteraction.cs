using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] float interactionDistance;

    bool holdingItem;
    [SerializeField] GameObject heldItem;
    [SerializeField] Transform holdTransform;
    [SerializeField] float throwForce;
 
    public delegate void MovementStateEvent(bool active);
    MovementStateEvent movementStateEvent;

    public delegate void WeaponStateEvent(bool active);
    WeaponStateEvent weaponStateEvent;

    void Start()
    {
        GameManager.instance.inputHandler.InteractEventSubscribe(Interact);
        GameManager.instance.inputHandler.FireEventSubscribe(ThrowItem);

    }

    private void Update()
    {
        if (heldItem != null)
        {
            heldItem.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            heldItem.transform.position = holdTransform.position;
            heldItem.transform.localRotation = Quaternion.identity;
        }
    }

    void Interact()
    {
        RaycastHit hit;

        if (holdingItem)
        {
            heldItem.transform.parent = null;
            Rigidbody objRB = heldItem.GetComponent<Rigidbody>();
            objRB.useGravity = true;
            objRB.freezeRotation = false;
            heldItem.GetComponent<Collider>().isTrigger = false;

            heldItem = null;
            holdingItem = false;
            Invoke("ReleaseWeapon", 0.1f);
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.GetComponent<Rigidbody>() && !holdingItem)
            {
                Debug.Log("interact with " + hit.collider.name);

                heldItem = hit.collider.gameObject;
                Rigidbody objRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                objRB.useGravity = false;
                objRB.freezeRotation = true;
                heldItem.GetComponent<Collider>().isTrigger = true;
                holdingItem = true;

                heldItem.transform.position = holdTransform.position;
                heldItem.transform.parent = holdTransform;
                weaponStateEvent(false);
            }
        }
    }

    void ThrowItem(bool firing)
    {
        if (firing && holdingItem)
        {
            heldItem.transform.parent = null;
            Rigidbody objRB = heldItem.GetComponent<Rigidbody>();
            objRB.freezeRotation = false;
            heldItem.GetComponent<Collider>().isTrigger = false;
            objRB.useGravity = true;
            objRB.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);

            heldItem = null;
            holdingItem = false;
            Invoke("ReleaseWeapon", 0.1f);
        }
    }

    void ReleaseWeapon()
    {
        weaponStateEvent(true);
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
