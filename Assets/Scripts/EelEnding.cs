using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EelEnding : MonoBehaviour
{
    [SerializeField] GameObject eelClickable;
    [SerializeField] GameObject eelField;
    [SerializeField] GameObject[] eelTrueEnd;
    private Button eelButton;
    private float timer;
    private float delay = 5f;
    private bool brazil;

    private void Awake()
    {
        CameraControl.Instance.brazil += Instance_brazil;
        timer = 0f;
        brazil = false;
    }

    private void Instance_brazil(object sender, System.EventArgs e)
    {
        eelField.SetActive(true);
        eelClickable.SetActive(true);
        eelButton = eelClickable.GetComponent<Button>();
        eelButton.onClick.AddListener(TheEnd);
        eelButton.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay && brazil)
        {
            Application.Quit();
        }
    }

    private void TheEnd()
    {
        ButtonManager.Instance.musics.Stop();
        timer = 0f;
        eelField.SetActive(false);
        eelClickable.SetActive(false);
        foreach (GameObject go in eelTrueEnd)
        {
            go.SetActive(true);
        }
        
        brazil = true;
    }
}
