using System;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    RectTransform Bar;

    RectTransform myBar;

    [SerializeField]
    VisualTimer Timer;
    [SerializeField]
    private float barSize = 200;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    void Start()
    {
        if (Timer.totalTime == -1)
        {
            Destroy(this);
        }
        Bar = GetComponentInParent<RectTransform>();
        myBar = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myBar.sizeDelta = new Vector2(Timer.timeLeft/Timer.totalTime*barSize, Bar.sizeDelta.y);
        myBar.anchoredPosition = new Vector2((barSize-myBar.sizeDelta.x)*-0.5f,0);
    }
}
