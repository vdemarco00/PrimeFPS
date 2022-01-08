using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float mouseSensitivity;
    float mouseH;
    float mouseV;

    float rotationH;
    float rotationV;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotationH = transform.eulerAngles.y;
        rotationV = cam.transform.eulerAngles.x;
    }

    void Update()
    {
        mouseH = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseV = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotationH += mouseH;
        rotationV += -mouseV;
        rotationV = Mathf.Clamp(rotationV, -90, 90);

        rb.MoveRotation(Quaternion.Euler(0, rotationH, 0));
        cam.transform.localRotation = Quaternion.Euler(rotationV, 0, 0);
    }
}
