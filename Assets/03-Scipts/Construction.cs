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
    bool mouseLeftClick;

    GameObject toBuild;
    Vector3 buildPosition;
    Vector3 buildRotation;
    Vector3 rayDir;

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
                            rayDir = ray.direction;
                            validPlanet = true;
                        }
                        else if (!homePlanet && tag == "planet_food")
                        {
                            buildRotation = hit.normal;
                            buildPosition = hit.point;
                            rayDir = ray.direction;
                            validPlanet = true;
                        }
                        else
                        {
                            validPlanet = false;
                        }
                            Debug.DrawRay(hit.point, hit.normal, Color.cyan);
                    }
                }
                else
                {
                    validPlanet = false;
                }

                // dislay building preview
                if (validPlanet)
                {
                    if (!toBuild.gameObject.activeSelf) { toBuild.SetActive(true); }

                    toBuild.transform.position = buildPosition;

                    Quaternion rotation = Quaternion.FromToRotation(toBuild.transform.up, buildRotation) * toBuild.transform.rotation; // wrong Y
                    toBuild.transform.rotation = rotation;

                    {   // if no overlap with other building
                        mouseLeftClick = Input.GetMouseButtonDown(0);
                        if (mouseLeftClick)
                        {

                        }
                    }
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
        if (constructionMode)
        { 
            constructionMode = false;
            if (toBuild != null) { Destroy(toBuild); }
        }
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

    void Build()
    {

    }
}
