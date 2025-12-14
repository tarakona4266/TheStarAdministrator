using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlanetInfos : MonoBehaviour
{
    [Header("Planet positions")]
    [SerializeField] Transform homePosition;
    [SerializeField] Transform foodPosition;
    [SerializeField] Transform woodPosition;
    [SerializeField] Transform cristalPosition;

    [Header("UI elements")]
    [SerializeField] TextMeshProUGUI homeInfos;
    [SerializeField] TextMeshProUGUI foodInfos;
    [SerializeField] TextMeshProUGUI woodInfos;
    [SerializeField] TextMeshProUGUI cristalInfos;
    [SerializeField] float planetRadius = 60f;

    bool displayHomeInfos = false;
    bool displayFoodInfos = false;
    bool displaysWoodInfos = false;
    bool displayCristalInfos = false;
    Vector3 offset;

    void Start()
    {
        homeInfos.gameObject.SetActive(false);
        offset = new Vector3(0, planetRadius, 0);
    }

    public void DisplayInfos(string planetType = "Untagged")
    {
        switch (planetType)
        {
            case "planet_house": // home
                homeInfos.transform.position = Camera.main.WorldToScreenPoint(homePosition.position) + offset;
                homeInfos.gameObject.SetActive(true);
                break;
            case "planet_food": // food
                foodInfos.transform.position = Camera.main.WorldToScreenPoint(foodPosition.position) + offset;
                foodInfos.gameObject.SetActive(true);
                break;
            case "planet_wood": // wood
                woodInfos.transform.position = Camera.main.WorldToScreenPoint(woodPosition.position) + offset;
                woodInfos.gameObject.SetActive(true);
                break;
            case "planet_stone": // cristal
                cristalInfos.transform.position = Camera.main.WorldToScreenPoint(cristalPosition.position) + offset;
                cristalInfos.gameObject.SetActive(true);
                break;
            default:
                homeInfos.gameObject.SetActive(false);
                woodInfos.gameObject.SetActive(false);
                cristalInfos.gameObject.SetActive(false);
                foodInfos.gameObject.SetActive(false);
                break;
        }
    }
}
