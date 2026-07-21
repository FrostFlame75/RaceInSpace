using System;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScriptManuel : MonoBehaviour
{
    [SerializeField]
    [Header("Button Settings")]
    [Tooltip("The type of button. Valid types: test, quit, changeScene")]
    private string type = "test";

    [SerializeField]
    [Tooltip("The value / data to pass into the button. Only necessary for some types.")]
    private string value = "null";
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
            SceneManager.LoadScene(value);
        }

    }
    
}
