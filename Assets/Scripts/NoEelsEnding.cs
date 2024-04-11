using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class NoEelsEnding : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    //[SerializeField] private GameObject textField;

    private void Start()
    {
        ButtonManager.Instance.startNoEels += Instance_startNoEels;
    }

    private void Instance_startNoEels(object sender, System.EventArgs e)
    {
        endScreen.SetActive(true);
    }
}
