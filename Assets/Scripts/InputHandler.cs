using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour 
{
    bool acceptInput;
    public delegate void FireEvent(bool buttonDown);
    FireEvent fireEvent;

    public delegate void InteractEvent();
    InteractEvent interactEvent;

    private void Awake()
    {
        acceptInput = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (acceptInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (fireEvent != null)
                    fireEvent(true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (fireEvent != null)
                    fireEvent(false);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (interactEvent != null)
                    interactEvent();
            }
        }
    }

    public void FireEventSubscribe(FireEvent newMethod)
    {
        fireEvent += newMethod;
    }

    public void InteractEventSubscribe(InteractEvent newMethod)
    {
        interactEvent += newMethod;
    }
}
