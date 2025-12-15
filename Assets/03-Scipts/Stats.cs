using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    [SerializeField] public int Food;
    [SerializeField] public int Wood;
    [SerializeField] public int Stone;
    [SerializeField] public int House;
    [SerializeField] public int HouseLeft;
    [SerializeField] public int Farm;

    [SerializeField] public int Villagers;
    [SerializeField] public int Vagabonds;

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
        Vagabonds = getCountVagabond.Length;

        if (Happiness <= 0 || Villagers <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
        else if (Happiness >= 100)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
