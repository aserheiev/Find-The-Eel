using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance { get; private set; } 

    [SerializeField] Camera menuCamera;
    [SerializeField] Camera gameCamera;
    public event EventHandler brazil;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        menuCamera.enabled = true;
    }

    public void SwitchCam()
    {
        menuCamera.enabled = false;
        gameCamera.enabled = true;
    }

    public void ToggleCam()
    {
        GetComponent<Animator>().SetTrigger("Change");
        brazil?.Invoke(this, EventArgs.Empty);
    }
}
