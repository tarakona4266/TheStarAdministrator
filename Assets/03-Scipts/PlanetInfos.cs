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

    void Update()
    {
        if (displayHomeInfos)
        {
            homeInfos.transform.position = Camera.main.WorldToScreenPoint(homePosition.position) + offset;
        }
        if (displayFoodInfos) 
        { 
        }
        if (displayCristalInfos) 
        { 
        }
        if (displaysWoodInfos) { 
        }
    }

    public void DisplayInfos(string planetType = "Untagged")
    {
        switch (planetType)
        {
            case "food": // home
                displayHomeInfos = true;
                homeInfos.gameObject.SetActive(true);
                break;
            case "wood": // food

                break;
            case "stone": // wood

                break;
            case "house": // cristal
                
                break;
            default:
                homeInfos.gameObject.SetActive(false);
                break;
        }
    }
}
