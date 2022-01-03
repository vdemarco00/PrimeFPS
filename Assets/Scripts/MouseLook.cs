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
    void Start()
    {
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

        transform.rotation = Quaternion.Euler(0, rotationH, 0);
        cam.transform.localRotation = Quaternion.Euler(rotationV, 0, 0);
    }
}
