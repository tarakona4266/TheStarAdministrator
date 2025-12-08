using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Food = 0;
    public int Wood = 0;
    public int Stone = 0;
    public int House = 0;

    public int Villagers = 0;
    public int Happiness = 0;

    private GameObject[] getCount;

    private void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("food");
        Villagers = getCount.Length;
    }
}
