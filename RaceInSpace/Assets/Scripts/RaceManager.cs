using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    string ScoreKey = "Highscore";
    [SerializeField] List<Checkpoint> checkpoints;
    [SerializeField] DeathScreen death;
    [SerializeField] VisualTimer timer;
    public float bestTime;
    public float devTime;
    public bool isRaceGoing = false;
    public bool hasWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string scenename = SceneManager.GetActiveScene().name;
        ScoreKey = ScoreKey + "_" + scenename;
        timer.timeLeft = devTime;
        timer.totalTime = devTime;
        LoadTime();

    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoints[checkpoints.Count - 1].hasBeenHit && isRaceGoing)
        {
            bool raceDone = true;
            foreach (Checkpoint i in checkpoints) 
            {
                if (!i.hasBeenHit)
                {
                    raceDone = false;
                }
            }
            if (raceDone && !hasWon)
            {
                WonRace();
                hasWon = true;
            }
        }
    }
    
    public void WonRace()
    {
        
        timer.StopTimer();
        if (timer.totalTime - timer.timeLeft <= bestTime)
        {
            bestTime = timer.totalTime - timer.timeLeft;
            print(bestTime);
            SaveTime();
        }
    }

    public void LostRace()
    {

    }

    public void RacePaused()
    {

    }
    public void RaceStart()
    {
        if (!isRaceGoing)
        {
            timer.StartTimer();
            isRaceGoing = true;
        }
    }

    public void SaveTime()
    {
       PlayerPrefs.SetFloat(ScoreKey, bestTime);
       PlayerPrefs.Save();
    }

    public void LoadTime()
    {
        bestTime = PlayerPrefs.GetFloat(ScoreKey, 60.000f);
    }
}
