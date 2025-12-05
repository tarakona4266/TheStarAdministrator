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
    bool tired;

    public SphereCollider Trigger;
    [SerializeField] GameObject FoodPlanet;
    [SerializeField] GameObject WoodPlanet;
    [SerializeField] GameObject MiningPlanet;
    [SerializeField] GameObject HousePlanet;

    void Start()
    {
        tired = false;
        deathAge = Random.Range(50, 99);
    }

    void Update()
    {
        if (age > deathAge)
        {
            Destroy(gameObject);
        }
        if (!tired)
        {
            switch (job) //Check the villager job and make them act accordingly by calling the correct function
            {
                case "food":
                    transform.position += new Vector3(FoodPlanet.transform.position.x, FoodPlanet.transform.position.y, FoodPlanet.transform.position.z);
                    break;
                case "wood":
                    transform.position += new Vector3(WoodPlanet.transform.position.x, WoodPlanet.transform.position.y, WoodPlanet.transform.position.z);
                    break;
                case "minor":
                    transform.position += new Vector3(MiningPlanet.transform.position.x, MiningPlanet.transform.position.y, MiningPlanet.transform.position.z);
                    break;
                case "builder":
                    transform.position += new Vector3(HousePlanet.transform.position.x, HousePlanet.transform.position.y, HousePlanet.transform.position.z);
                    break;
                case "vagabond":
                    break;
                default:
                    break;

            }
        }
    }
}