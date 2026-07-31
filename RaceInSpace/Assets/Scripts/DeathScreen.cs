using System;
using System.Xml;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{

    Image myImage;
    [SerializeField] RaceManager rm;

    

    [SerializeField] float max = 0.5f;
    

    public bool onDeathScreen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rm.hasWon)
        {
            myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, 1);
            onDeathScreen = true;
        }
        else
        {
            myImage.color = new Color(myImage.color.r, myImage.color.g, myImage.color.b, 0);
        }
    }
}

 
