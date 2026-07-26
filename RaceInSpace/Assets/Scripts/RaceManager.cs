using UnityEngine;
using System.Collections.Generic;

public class RaceManager : MonoBehaviour
{
    [SerializeField] List<Checkpoint> checkpoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpoints[checkpoints.Count - 1].hasBeenHit)
        {
            bool raceDone = true;
            foreach (Checkpoint i in checkpoints) 
            {
                if (!i.hasBeenHit)
                {
                    raceDone = false;
                }
            }
            if (raceDone)
            {
                WonRace();
            }
        }
    }
    
    void WonRace()
    {
        print("[Placeholder Win Text]");
    }

    void LostRace()
    {

    }
}
