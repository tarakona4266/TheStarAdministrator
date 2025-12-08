using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    Stopwatch stopWatch = new Stopwatch();
    TimeSpan ts;

    [SerializeField] bool IsDayActive = true;

    [SerializeField] int TimeSecond;
    [SerializeField] int TimeMinute;

    private void Start()
    {
        stopWatch.Start();
    }

    void Update()
    {
        ts = stopWatch.Elapsed;
        TimeSecond = ts.Seconds;
        TimeMinute = ts.Minutes;

        if (TimeMinute == 5) 
        {
            if (IsDayActive) { IsDayActive = false; }
            else { IsDayActive = true; }
            stopWatch.Restart();
        }
    }
}
