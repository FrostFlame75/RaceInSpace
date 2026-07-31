using System;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VisualTimer : MonoBehaviour
{   
    public float timeLeft = 140;
    [SerializeField]
    private float amount = 1;

    [SerializeField]
    private bool running = false;
    TMP_Text canvasText;

    public float totalTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvasText = GetComponent<TMP_Text>();
        
        print("ryn");
        if (amount < 0)
        {
            totalTime = timeLeft;
        }
        else
        {
            totalTime = -1;
        }
        
    }
    void Start()
    {
        
    }
    public void StartTimer()
    {
        running = true;
    }
    public void StopTimer()
    {
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (timeLeft <= 0 && amount < 0){ canvasText.text = "0:00.0"; return; }
        string visualTimeSecOnes;
        if (timeLeft > 0) { visualTimeSecOnes = (math.floor(timeLeft) % 60).ToString(); } 
        else if (timeLeft < -1)  { visualTimeSecOnes = (Math.Ceiling(timeLeft) % 60).ToString(); } 
        else { visualTimeSecOnes = "-" + (Math.Ceiling(timeLeft) % 60).ToString(); }
            string visualTimeSecDeci = Math.Abs((math.round(timeLeft * 1000) % 60000) % 1000).ToString();
        if (visualTimeSecOnes.Length == 1)
        {
            visualTimeSecOnes = "0" + visualTimeSecOnes;
        }
        switch (visualTimeSecDeci.Length)
        {
            case 0:
                visualTimeSecDeci = visualTimeSecDeci + "0";
                goto case 1;
            case 1:
                visualTimeSecDeci = visualTimeSecDeci + "0";
                goto case 2;
            case 2:
                visualTimeSecDeci = visualTimeSecDeci + "0";
                goto default;
            default:
                break;

        }
        canvasText.text = visualTimeSecOnes + "." + visualTimeSecDeci;
        if (running) timeLeft += Time.deltaTime * amount;
    }
}
