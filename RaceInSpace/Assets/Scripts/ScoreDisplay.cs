using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] VisualTimer timer;
    [SerializeField] RaceManager rm;
    [SerializeField] string toDisplay;
    bool done = false;
    string score;
    TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (rm.hasWon && !done)
        {
            Display();
            done = true;
        }
    }

    void Display()
    {
        switch (toDisplay) 
        {
            case "best":
                text.text = "Best Time: " + rm.bestTime.ToString();
                break;
            case "dev":
                if ((timer.totalTime - timer.timeLeft) < rm.devTime)
                {
                    text.text = "You beat the target time!";
                }
                else
                {
                    text.text = "You failed this test...";
                }
                break;
            default:
                text.text = "Your Time: " + (timer.totalTime - timer.timeLeft).ToString();
                break;
        }
        
    }
}
