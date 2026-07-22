using System;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class VisualTimer : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 140;
    [SerializeField]
    private float amount = 1;

    TMP_Text canvasText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        canvasText = GetComponent<TMP_Text>();
        print("ryn");
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0 && amount < 0){ canvasText.text = "0:00.0"; return; }
        string visualTimeMin = math.floor(timeLeft/60).ToString();
        string visualTimeSec = ((math.round(timeLeft*10)/10)%60).ToString();
        if (visualTimeSec.Length == 3)
        {
            visualTimeSec = "0" + visualTimeSec;
        }
        if (visualTimeSec.Length == 2)
        {
            visualTimeSec = visualTimeSec + ".0";
        }
        if (visualTimeSec.Length == 1)
        {
            visualTimeSec = "0" + visualTimeSec + ".0";
        }
        canvasText.text = visualTimeMin + ":" + visualTimeSec;    
        timeLeft += Time.deltaTime * amount;
    }
}
