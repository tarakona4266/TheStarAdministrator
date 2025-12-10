using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Construction : MonoBehaviour
{
    enum Buildings
    {
        house,
        school,
        deco,
        farm
    }
    Buildings cuurentPrefab;

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

    bool mouseRightClick;

    GameObject toBuild;
    Vector3 buildPosition;
    Vector3 buildRotation;
    Vector3 rayDir;

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
                    toBuild.SetActive(true);

                    toBuild.transform.position = buildPosition;
                    Quaternion rotation = Quaternion.FromToRotation(toBuild.transform.up, buildRotation) * toBuild.transform.rotation;
                    toBuild.transform.rotation = rotation;

                    mouseRightClick = Input.GetMouseButtonDown(1);
                    if (mouseRightClick)
                    {
                        Build();
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
        else
        {
            constructionMode = true; 
        }
    }

    public void SelectPrefab(int prefabIndex = 0)
    {
        if (toBuild != null)
        {
            Destroy(toBuild);
        }
        Buildings prefabType = (Buildings)prefabIndex;
        switch (prefabType)
        {
            case Buildings.house:
                cuurentPrefab = Buildings.house;
                toBuild = Instantiate(house, transform);
                break;
            case Buildings.farm:
                cuurentPrefab = Buildings.farm;
                toBuild = Instantiate(farm, transform);
                break;
            case Buildings.school:
                cuurentPrefab = Buildings.school;
                toBuild = Instantiate(school, transform);
                break;
            case Buildings.deco:
                cuurentPrefab = Buildings.deco;
                toBuild = Instantiate(deco, transform);
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
        if (validPlanet) {
            GameObject build = null;
            switch (cuurentPrefab)
            {
                case Buildings.house:
                    cuurentPrefab = Buildings.house;
                    build = Instantiate(house, toBuild.transform.position, toBuild.transform.rotation, transform);
                    break;
                case Buildings.farm:
                    cuurentPrefab = Buildings.farm;
                    build = Instantiate(farm, toBuild.transform.position, toBuild.transform.rotation, transform);
                    break;
                case Buildings.school:
                    cuurentPrefab = Buildings.school;
                    build = Instantiate(school, toBuild.transform.position, toBuild.transform.rotation, transform);
                    break;
                case Buildings.deco:
                    cuurentPrefab = Buildings.deco;
                    build = Instantiate(deco, toBuild.transform.position, toBuild.transform.rotation, transform);
                    break;
            }
            if (build != null)
            {
                build.SetActive(true);
                build.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    public void OnDisable()
    {
        if (constructionMode)
        {
            constructionMode = false;
            if (toBuild != null) { Destroy(toBuild); }
        }
    }
}
