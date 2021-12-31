using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float mouseSensitivity;
    [SerializeField] float movementSpeed;

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
        inputH = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        inputV = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        mouseH = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseV = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationH += mouseH;
        rotationV += -mouseV;
        rotationV = Mathf.Clamp(rotationV, -90, 90);

        Vector3 move = transform.right * inputH + transform.forward * inputV;
        move.y = rb.velocity.y;
        rb.velocity = move;
        transform.rotation = Quaternion.Euler(0, rotationH, 0);
        cam.transform.localRotation = Quaternion.Euler(rotationV, 0, 0);
    }
}
