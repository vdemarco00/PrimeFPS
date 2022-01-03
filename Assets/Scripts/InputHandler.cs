using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour 
{
    bool acceptInput;
    public delegate void FireEvent();
    FireEvent fireEvent;

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
                    fireEvent();
            }
        }
    }

    public void FireEventSubscribe(FireEvent newMethod)
    {
        fireEvent += newMethod;
    }
}
