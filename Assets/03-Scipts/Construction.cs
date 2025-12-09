using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] CameraFocus cameraFocus;
    [SerializeField] Stats gameStats;
    [Header("Prefabs")]
    [SerializeField] bool homePlanet = true;
    [SerializeField] GameObject house;
    [SerializeField] GameObject school;
    [SerializeField] GameObject farm;
    [SerializeField] GameObject deco;

    public bool constructionMode;
    bool validPlanet;
    bool validLocation;

    GameObject toBuild;
    Vector3 buildPosition;
    Vector3 buildRotation;

    void Start()
    {
    }

    void Update()
    {
        if (constructionMode)
        {
            if (toBuild != null)
            {
                // get the surface to build on
                Ray ray = cameraFocus.ray;
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        string tag = hit.transform.root.tag;
                        if (homePlanet && tag == "planet_house")
                        {
                            buildRotation = hit.normal;
                            buildPosition = hit.point;
                            validPlanet = true;
                            print("home planet");

                        }
                        else if (!homePlanet && tag == "planet_food")
                        {
                            buildRotation = hit.normal;
                            buildPosition = hit.point;
                            validPlanet = true;
                            print("food planet");
                        }
                        else
                        {
                            validPlanet = false;
                            print("no valid planet");
                        }
                    }
                    else
                    {
                        validPlanet = false;
                        print("no valid planet");
                    }
                }
                
                // dislay building preview
                if (validPlanet)
                {
                    toBuild.SetActive(true);
                    toBuild.transform.position = buildPosition;
                    toBuild.transform.rotation = Quaternion.Euler(buildRotation);
                }
                else
                {
                    toBuild.SetActive(false);
                }
            }
        }
    }

    public void EnableConstructionMode()
    {
        if (constructionMode) { constructionMode = false; }
        else { constructionMode = true; }
    }

    public void SelectPrefab(string prefabName)
    {
        if (toBuild != null)
        {
            Destroy(toBuild);
        }
        switch (prefabName)
            {
            case "house":
                toBuild = Instantiate(house, transform);
                print("house selected");
                break;
            case "farm":
                toBuild = Instantiate(farm, transform);
                print("farm selected");
                break;
            case "school":
                toBuild = Instantiate(school, transform);
                print("school selected");
                break;
            case "deco":
                toBuild = Instantiate(deco, transform);
                print("decoration selected");
                break;
        }
        if (toBuild != null)
        {
            toBuild.transform.position = buildPosition;
            toBuild.transform.rotation = Quaternion.Euler(buildRotation);
        }
    }
}
