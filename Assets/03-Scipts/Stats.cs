using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] public int Food = 0;
    [SerializeField] public int Wood = 0;
    [SerializeField] public int Stone = 0;
    [SerializeField] public int House = 5;
    [SerializeField] public int HouseLeft = 0;

    [SerializeField] public int Villagers = 0;
    [SerializeField] public int Happiness = 10;

    private GameObject[] getCount;

    private void Start()
    {
        HouseLeft = House;
    }

    private void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("food");
        Villagers = getCount.Length;

        if (Happiness <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
        else if (Happiness >= 100)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
