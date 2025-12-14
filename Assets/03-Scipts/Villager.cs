using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Villager : MonoBehaviour
{
    public int age = 0;

    int deathAge;
    public string job;
    public float speed;

    bool night;
    public bool tired;
    public bool IsSleeping;
    bool CanGiveHappiness;

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
            if (night)
            {
                tired = true;
                CanGiveHappiness = true;
                IsSleeping = false;
                night = false;
            }

            if (Stats.HouseLeft > 0 && IsSleeping == false)
            {
                transform.position += new Vector3(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.y - transform.position.y, HousePlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
            }
            else if (IsSleeping == true)
            {
                transform.position += new Vector3(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.y - transform.position.y, HousePlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
            }
            else
            {
                transform.position += new Vector3(-transform.position.x, -transform.position.y, -transform.position.z).normalized * speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(-transform.position.x, -transform.position.z) * Mathf.Rad2Deg, 0f);
            }
        }
        else if (Stats.GetComponent<DayNightCycle>().IsDayActive == true)
        {
            if (!night)
            {
                age++;
                night = true;
            }
            if (!tired && CanGiveHappiness)
            {
                Stats.Happiness++;
                CanGiveHappiness = false;
            }
            else if (tired) 
            { 
                Stats.Happiness--;
                CanGiveHappiness = false;
                tired = false; 
            }
            

            switch (job) //Check the villager job and make them act accordingly by calling the correct function
            {
                case "food":
                    transform.position += new Vector3(FoodPlanet.transform.position.x - transform.position.x, FoodPlanet.transform.position.y - transform.position.y, FoodPlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                    transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(FoodPlanet.transform.position.x - transform.position.x, FoodPlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
                    break;
                case "wood":
                    transform.position += new Vector3(WoodPlanet.transform.position.x - transform.position.x, WoodPlanet.transform.position.y - transform.position.y, WoodPlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                    transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(WoodPlanet.transform.position.x - transform.position.x, WoodPlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
                    break;
                case "stone":
                    transform.position += new Vector3(StonePlanet.transform.position.x - transform.position.x, StonePlanet.transform.position.y - transform.position.y, StonePlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                    transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(StonePlanet.transform.position.x - transform.position.x, StonePlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
                    break;
                case "house":
                    transform.position += new Vector3(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.y - transform.position.y, HousePlanet.transform.position.z - transform.position.z).normalized * speed * Time.deltaTime;
                    transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(HousePlanet.transform.position.x - transform.position.x, HousePlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
                    break;
                case "vagabond":
                    break;
                default:
                    transform.rotation = Quaternion.Euler(90f, Mathf.Atan2(FoodPlanet.transform.position.x - transform.position.x, FoodPlanet.transform.position.z - transform.position.z) * Mathf.Rad2Deg, 0f);
                    break;
            }
        }
    }

    public void Eeping()
    {
        tired = false;
        IsSleeping = true;
        print("dodo");
    }
}