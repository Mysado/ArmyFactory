using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action OnLMBClicked;
    public Action OnRMBClicked;
    public Action OnRotateLeftClicked;
    public Action OnRotateRightClicked;

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(0))
                OnLMBClicked?.Invoke();
            if (Input.GetMouseButtonDown(1))
                OnRMBClicked?.Invoke();
            if(Input.GetKeyDown(KeyCode.R))
                OnRotateRightClicked?.Invoke();
            if(Input.GetKeyDown(KeyCode.E))
                OnRotateLeftClicked?.Invoke();
    }
}
