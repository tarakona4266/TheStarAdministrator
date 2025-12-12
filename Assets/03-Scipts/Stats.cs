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
    [SerializeField] public int Farm = 0;

    [SerializeField] public int Villagers = 0;
    [SerializeField] public int Happiness = 10;

    private GameObject[] getCountFood;
    private GameObject[] getCountWood;
    private GameObject[] getCountStone;
    private GameObject[] getCountHouse;
    private GameObject[] getCountVagabond;
    private GameObject[] getCountUnemployed;

    private void Start()
    {
        HouseLeft = House;
    }

    private void Update()
    {
        getCountFood = GameObject.FindGameObjectsWithTag("food");
        getCountWood = GameObject.FindGameObjectsWithTag("wood");
        getCountStone = GameObject.FindGameObjectsWithTag("stone");
        getCountHouse = GameObject.FindGameObjectsWithTag("house");
        getCountVagabond = GameObject.FindGameObjectsWithTag("vagabond");
        getCountUnemployed = GameObject.FindGameObjectsWithTag("unemployed");

        Villagers = getCountFood.Length + getCountWood.Length + getCountStone.Length + getCountHouse.Length + getCountVagabond.Length + getCountUnemployed.Length;

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
