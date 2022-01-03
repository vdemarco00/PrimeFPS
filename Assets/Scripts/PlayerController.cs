using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] EnergyWeapon weapon;
    [SerializeField] Transform bottom;
    float inputH;
    float inputV;

    void Start()
    {
    }


    void Update()
    {
        bool grounded = true;

        RaycastHit hit;
        if (Physics.Raycast(bottom.position, transform.TransformDirection(Vector3.down), out hit, 0.2f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * inputH + transform.forward * inputV;
        move.Normalize();
        move *= movementSpeed * Time.deltaTime;
        move.y = rb.velocity.y;
        if (grounded)
        {
            rb.velocity = move;
        }
        else
        {
            if (inputH != 0 && inputV != 0)
            {
                move.x /= 1.3f;
                move.z /= 1.3f;
                
                rb.velocity = move;
            }
        }
    }
}
