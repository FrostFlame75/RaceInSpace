using System;
using System.ComponentModel;
using UnityEngine;

public class ButtonScriptManuel : MonoBehaviour
{
    [SerializeField]
    [Header("Button Settings")]
    [Tooltip("The type of button. Valid types: test, quit, changeScene")]
    private string type = "test";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        if (type == "test")
        {
            print("test button!");
        }
        if (type == "quit")
        {
            Application.Quit();
        }
        if (type == "changeScene")
        {
            Application.Quit();
        }

    }
    
}
