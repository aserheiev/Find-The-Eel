using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;
    private float timer;
    private float timerMax;

    private void Awake()
    {
        timerMax = 0.3f;
        timer = 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0f;
            // _x = Random.Range(-0.5f, 0.5f);
            // _y = Random.Range(-0.5f, 0.5f);
        }

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
