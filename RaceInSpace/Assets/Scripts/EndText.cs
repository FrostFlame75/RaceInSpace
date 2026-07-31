using UnityEngine;
using TMPro;

public class EndText : MonoBehaviour
{
    TMP_Text text;
    [SerializeField] RaceManager rm;

    

    [SerializeField] float max = 0.5f;


    public bool onDeathScreen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = this.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rm.hasWon)
        {
            text.color = new Color(max, max, max, 1);
            onDeathScreen = true;
        }
        else
        {
            text.color = new Color(0,0,0,0);
        }
    }
}
