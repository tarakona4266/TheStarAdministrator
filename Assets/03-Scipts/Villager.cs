using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Villager : MonoBehaviour
{
    int age = 0;
    int deathAge;
    public string job;
    public float speed;
    public bool tired;

    [SerializeField] public GameObject FoodPlanet;
    [SerializeField] public GameObject WoodPlanet;
    [SerializeField] public GameObject StonePlanet;
    [SerializeField] public GameObject HousePlanet;

    [SerializeField] Stats Stats;

    void Start()
    {
        tired = false;
        deathAge = Random.Range(50, 99);
    }

    void Update()
    {
        tag = job;
        if (age > deathAge)
        {
            Destroy(this.gameObject);
        }

        if (Stats.GetComponent<DayNightCycle>().IsDayActive == false)
        {
            tired = true;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
        }

        if (!tired)
        {
            switch (job) //Check the villager job and make them act accordingly by calling the correct function
            {
                case "food":
                    transform.position += new Vector3(FoodPlanet.transform.position.x - transform.position.x, FoodPlanet.transform.position.y - transform.position.y, FoodPlanet.transform.position.z - transform.position.z).normalized * speed;
                    break;
                case "wood":
                    transform.position += new Vector3(WoodPlanet.transform.position.x - transform.position.x, WoodPlanet.transform.position.y - transform.position.y, WoodPlanet.transform.position.z - transform.position.z).normalized * speed;
                    break;
                case "minor":
                    transform.position += new Vector3(StonePlanet.transform.position.x - transform.position.x, StonePlanet.transform.position.y - transform.position.y, StonePlanet.transform.position.z - transform.position.z).normalized * speed;
                    break;
                case "builder":
                    transform.position += new Vector3(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.y - transform.position.y, HousePlanet.transform.position.z - transform.position.z).normalized * speed;
                    break;
                case "vagabond":
                    break;
                default:
                    break;
            }
        }
        else
        {
            transform.position += new Vector3(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.y - transform.position.y, HousePlanet.transform.position.z - transform.position.z).normalized * speed;

        } 
    }
}