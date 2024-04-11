using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    [SerializeField] private GameObject[] messageLeft;
    [SerializeField] private GameObject[] messageRight;
    [SerializeField] private GameObject[] messageSame;
    [SerializeField] private GameObject[] messageBoth;
    [SerializeField] public AudioSource musics;

    public Button buttonExit;
    public Button buttonStart;
    public Button buttonLeftEel;
    public Button buttonRightEel;
    //public Button settingsConfirm;
    //public Button gameEel;
    public bool leftEelClicked;
    public bool rightEelClicked;
    private AudioSource playChime;
    private int eelTouchCount;
    public event EventHandler eelTouchCountReached;
    public event EventHandler startNoEels;


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

        buttonExit.onClick.AddListener(delegate { TaskOnExit(); });
        buttonStart.onClick.AddListener(delegate { TaskOnStart(); });
        buttonLeftEel.onClick.AddListener(delegate { TaskOnLeftEel(); });
        buttonRightEel.onClick.AddListener(delegate { TaskOnRightEel(); });
        playChime = GetComponent<AudioSource>();
        leftEelClicked = false;
        rightEelClicked = false;
        eelTouchCount = 0;
    }


    private void Update()
    {
        if (eelTouchCount == 10)
        {
            // autismWins.GetComponent<Animator>().SetTrigger("Play");
            eelTouchCountReached?.Invoke(this, EventArgs.Empty);
            Debug.Log("event fired");
            eelTouchCount++;
        }
    }

    private void Start()
    {
        buttonLeftEel.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        buttonRightEel.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
    }

    private void TaskOnExit()
    {
        Application.Quit();
    }

    private void TaskOnStart()
    {
        if (ToggleEvent.Instance.eels)
        {
            CameraControl.Instance.ToggleCam();
            playChime.Play();
            musics.PlayDelayed(3f);
        }
        else
        {
            startNoEels?.Invoke(this, EventArgs.Empty);
        }
        
    }
    private void TaskOnLeftEel()
    {
     if (leftEelClicked &&  rightEelClicked)
        {
            // both have already been clicked
            foreach (GameObject element in messageBoth)
            {
                element.SetActive(true);
            }
            eelTouchCount++;
        }   else
        {
            if (leftEelClicked && !rightEelClicked)
            {
                // only left has already been clicked
                foreach (GameObject element in messageSame)
                {
                    element.SetActive(true);
                }
                eelTouchCount++;
            } else
            {
                if (!leftEelClicked && rightEelClicked)
                {
                    // left unclicked and right clicked
                    foreach (GameObject element in messageRight)
                    {
                        element.SetActive(true);
                    }
                    leftEelClicked = true;
                    eelTouchCount++;
                } else
                {
                    // neither have been clicked
                    foreach (GameObject element in messageLeft)
                    {
                        element.SetActive(true);
                    }
                    leftEelClicked = true;
                    eelTouchCount++;
                }
            }
        }
    }
    private void TaskOnRightEel()
    {
        if (leftEelClicked && rightEelClicked)
        {
            // both have already been clicked
            foreach (GameObject element in messageBoth)
            {
                element.SetActive(true);
            }
            eelTouchCount++;
        }
        else
        {
            if (rightEelClicked && !leftEelClicked)
            {
                // only right has already been clicked
                foreach (GameObject element in messageSame)
                {
                    element.SetActive(true);
                }
                eelTouchCount++;
            }
            else
            {
                if (!rightEelClicked && leftEelClicked)
                {
                    // left unclicked and right clicked
                    foreach (GameObject element in messageRight)
                    {
                        element.SetActive(true);
                    }
                    rightEelClicked = true;
                    eelTouchCount++;
                }
                else
                {
                    // neither have been clicked
                    foreach (GameObject element in messageLeft)
                    {
                        element.SetActive(true);
                    }
                    rightEelClicked = true;
                    eelTouchCount++;
                }
            }
        }
    }

    private void CheckClickedEels(bool clickedThis, bool clickedThat)
    {
        // to refactor later
    }
}
