using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;
    float inputH;
    float inputV;

    float mouseH;
    float mouseV;

    float rotationH;
    float rotationV;

    void Start()
    {
        rotationH = transform.eulerAngles.y;
        rotationV = cam.transform.eulerAngles.x;
    }


    void Update()
    {
        bool grounded = true;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1.6f))
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
        
        mouseH = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseV = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationH += mouseH;
        rotationV += -mouseV;
        rotationV = Mathf.Clamp(rotationV, -90, 90);

        
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
            move.x /= 1.3f;
            move.z /= 1.3f;
            rb.velocity = move;
        }
        transform.rotation = Quaternion.Euler(0, rotationH, 0);
        cam.transform.localRotation = Quaternion.Euler(rotationV, 0, 0);
    }
}
