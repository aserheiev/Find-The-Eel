using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleEvent : MonoBehaviour
{
    public static ToggleEvent Instance { get; private set; }

    [SerializeField] private Toggle eelToggle;
    public bool eels;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        eels = true;
        //Fetch the Toggle GameObject
        eelToggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(eelToggle);
        });

    }

    void ToggleValueChanged(Toggle change)
    {
        if (eels)
        {
            eels = false;
            Debug.Log("eels changed to false");
        } else 
        { 
            eels = true;
            Debug.Log("eels changed to true");
        }
    }
}
