using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestPlanet : MonoBehaviour
{
    [SerializeField] private int Workers = 0;
    [SerializeField] int TimeSecond;
    [SerializeField] GameObject Stats; 

    void OnTriggerEnter (Collider other)
    {
        print(other.gameObject);
        if (tag == "planet_"+other.gameObject.tag) 
        { 
            other.gameObject.SetActive(false); 
            Workers++;
        }
    }

    Stopwatch stopWatch = new Stopwatch();
    TimeSpan ts;

    void Update()
    {
        ts = stopWatch.Elapsed;
        TimeSecond = ts.Seconds; //Is useful only for debug purposes
        int TimeMinute = ts.Minutes;
        
        if (Workers > 0)
        {
            stopWatch.Start();
        }
        else
        {
            stopWatch.Stop();
            stopWatch.Reset();
        }

        if (TimeMinute == 1)
        {
            switch (this.gameObject.tag)
            {
                case "food":
                    Stats.GetComponent<Stats>().Food += Workers;
                    break;
                case "wood":
                    Stats.GetComponent<Stats>().Wood += Workers;
                    break;
                case "stone":
                    Stats.GetComponent<Stats>().Stone += Workers;
                    break;
                case "house":
                    Stats.GetComponent<Stats>().House += Workers;
                    break;
            }
            stopWatch.Restart();
        }
    }
}
