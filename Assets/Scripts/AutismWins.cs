using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class AutismWins : MonoBehaviour
{
    [SerializeField] GameObject autismScreen;
    //[SerializeField] private GameObject textField;

    private void Start()
    {
        ButtonManager.Instance.eelTouchCountReached += Instance_eelTouchCountReached;
    }

    private void Instance_eelTouchCountReached(object sender, System.EventArgs e)
    {
        autismScreen.SetActive(true);
    }
}
