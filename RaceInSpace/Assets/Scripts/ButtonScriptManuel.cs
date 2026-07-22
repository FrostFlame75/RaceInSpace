using System;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScriptManuel : MonoBehaviour
{
    [SerializeField]
    [Header("Button Settings")]
    [Tooltip("The type of button. Valid types: test, quit, changeScene, slider")]
    private string type = "test";

    [SerializeField]
    [Tooltip("The value / data to pass into the button. Only necessary for some types.")]
    private string value = "null";

    [SerializeField]
    private AudioMixer masterMixer;

    private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (type == "slider") slider = this.GetComponent<Slider>();
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
        if (type == "slider")
        {
            masterMixer.SetFloat(value, 20*math.log10(slider.value/10)+10);
        }
    }
    
}
