using System;
using System.ComponentModel;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
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
    TMP_Text text;
    bool sure = false;
    [SerializeField] GameObject textObject = null;
    InputAction back;
    Image myImage;
    [SerializeField] string axis;
    [SerializeField] ButtonScriptManuel yawButton;
    [SerializeField] ButtonScriptManuel pitchButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        if (type == "slider") slider = this.GetComponent<Slider>();
        if (type == "reset") { text = textObject.GetComponent<TMP_Text>(); text.text = "Reset data permanently?"; }
        if (type == "settings") text = textObject.GetComponent<TMP_Text>();
            back = InputSystem.actions.FindAction("Back");
        myImage = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == "changeScene" && ((value == "MainMenu") || ((value == "LevelSelect") && (SceneManager.GetActiveScene().name != "MainMenu") && (myImage.color.a > 0))))
        {
            if (back.WasPressedThisFrame())
            {
                ButtonPressed();
            }
        }
    }

    public void updateText()
    {
        if (PlayerPrefs.GetInt(value) == -1)
        {
            text.text = axis + " Inverted";
        }
        else
        {
            text.text = "Invert " + axis;
        }
    }

    public void ButtonPressed()
    {
        Debug.Log("Button pressed");
        //Switch statement
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
            if (myImage.color.a > 0)
            {
                Debug.Log("Registered value");
                SceneManager.LoadScene(value);
            }
        }
        if (type == "slider")
        {
            masterMixer.SetFloat(value, 20*math.log10(slider.value/10)+10);
        }
        if (type == "reset")
        {
            if (!sure)
            {
                text.text = "Are you sure?";
                sure = true;
            }
            else
            {
                PlayerPrefs.DeleteAll();
                text.text = "Data Deleted";
                sure = false;
            }
            yawButton.updateText();
            pitchButton.updateText();
        }
        if (type == "settings")
        {
            PlayerPrefs.SetInt(value, PlayerPrefs.GetInt(value, 1) * -1);
            if (PlayerPrefs.GetInt(value) == -1)
            {
                text.text = axis +  " Inverted";
            }
            else
            {
                text.text = "Invert " + axis;
            }
            PlayerPrefs.Save();
        }
    }
    
}
