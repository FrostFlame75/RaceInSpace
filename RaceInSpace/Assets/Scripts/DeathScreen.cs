using System;
using System.Xml;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{

    Image myImage;

    [SerializeField]
    GameObject Text1;
[SerializeField]
    GameObject Text2;

    float showingTime = 0f;

    float max = 0.5f;

    public bool onDeathScreen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       myImage = this.GetComponent<Image>();
    }  

    // Update is called once per frame
    void Update()
    {
        myImage.color = new Color(184, 0, 0, math.clamp(showingTime, 0, max));
        if (this.showingTime > 0 && this.showingTime < max + 0.1f)
        {
            this.showingTime += Time.deltaTime;
        }
        if (this.showingTime > max && this.showingTime < max + 0.1f)
        {
            this.showingTime = max*6;
            Text1.SetActive(true);
            Text2.SetActive(true);
            this.onDeathScreen = true;
        }
    }

    public void Show()
    {
        this.showingTime += 0.01f;
        
    }
    public void Hide()
    {
        this.onDeathScreen = false;
        this.showingTime = 0;
        this.Text1.SetActive(false);
        this.Text2.SetActive(false);
    }
}
