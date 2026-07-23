using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    RectTransform Bar;

    RectTransform myBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    void Start()
    {
        Bar = GetComponentInParent<RectTransform>();
        myBar = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myBar.sizeDelta.Set(Bar.sizeDelta.x - Time.deltaTime*10, Bar.sizeDelta.y - Time.deltaTime*10);
    }
}
