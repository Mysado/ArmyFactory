using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action OnLPMClicked;
    public Action OnRPMClicked;
    public Action OnRotateLeftClicked;
    public Action OnRotateRightClicked;

    // Update is called once per frame
    void Update()
    {
            if(Input.GetMouseButtonDown(0))
                OnLPMClicked?.Invoke();
            if (Input.GetMouseButtonDown(1))
                OnRPMClicked?.Invoke();
            if(Input.GetKeyDown(KeyCode.R))
                OnRotateRightClicked?.Invoke();
            if(Input.GetKeyDown(KeyCode.E))
                OnRotateLeftClicked?.Invoke();
    }
}
