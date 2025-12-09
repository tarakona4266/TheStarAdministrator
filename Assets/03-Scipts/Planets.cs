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

    public int Buildings = 0;

    void OnTriggerEnter (Collider other)
    {
        print(other.gameObject);
        if (tag == "planet_"+other.gameObject.tag && Stats.GetComponent<DayNightCycle>().IsDayActive) 
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
            other.transform.GetChild(1).gameObject.SetActive(false);
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
                case "planet_food":
                    Stats.GetComponent<Stats>().Food += Workers * (Buildings + 1);
                    break;
                case "planet_wood":
                    Stats.GetComponent<Stats>().Wood += Workers;
                    break;
                case "planet_stone":
                    Stats.GetComponent<Stats>().Stone += Workers;
                    break;
                case "planet_house":
                    //Insert stuff here
                    break;
            }
            stopWatch.Restart();
        }
    }
}
