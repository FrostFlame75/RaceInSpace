using System;
using UnityEngine;

public class ButtonScriptManuel : MonoBehaviour
{
    int first = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        first += 4;
        print(first);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunButtonScript()
    {
        first += 4;
        print(first);        
    }
    
}
