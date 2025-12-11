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
        library,
        museum
    }
    Buildings currentPrefab;
    string currentPrefabName;

    [SerializeField] CameraFocus cameraFocus;
    [SerializeField] Stats gameStats;
    [SerializeField] Construction_cost_stats cost;
    [Header("Prefabs")]
    [SerializeField] bool homePlanet = true;
    [SerializeField] GameObject house;
    [SerializeField] GameObject school;
    [SerializeField] GameObject library;
    [SerializeField] GameObject museum;

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
                currentPrefab = Buildings.house;
                currentPrefabName = "house";
                toBuild = Instantiate(house, transform);
                break;
            case Buildings.library:
                currentPrefab = Buildings.library;
                currentPrefabName = "library";
                toBuild = Instantiate(library, transform);
                break;
            case Buildings.school:
                currentPrefab = Buildings.school;
                currentPrefabName = "school";
                toBuild = Instantiate(school, transform);
                break;
            case Buildings.museum:
                currentPrefab = Buildings.museum;
                currentPrefabName = "museum";
                toBuild = Instantiate(museum, transform);
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
        if (validPlanet)
        {
            // verify ressources
            bool canBuild = cost.VerifyCost(gameStats.Wood, gameStats.Stone, 1, currentPrefabName);

            // build
            if (canBuild)
            {
                GameObject build = null;
                switch (currentPrefab)
                {
                    case Buildings.house:
                        currentPrefab = Buildings.house;
                        build = Instantiate(house, toBuild.transform.position, toBuild.transform.rotation, transform);
                        gameStats.House++;
                        gameStats.Wood -= cost.Hwood;
                        gameStats.Stone -= cost.Hcristal;
                        break;

                    case Buildings.library:
                        currentPrefab = Buildings.library;
                        build = Instantiate(library, toBuild.transform.position, toBuild.transform.rotation, transform);
                        gameStats.Farm++;
                        gameStats.Wood -= cost.Lwood;
                        gameStats.Stone -= cost.Lcristal;
                        gameStats.Happiness += cost.Lhappiness;
                        break;

                    case Buildings.school:
                        currentPrefab = Buildings.school;
                        build = Instantiate(school, toBuild.transform.position, toBuild.transform.rotation, transform);
                        gameStats.Wood -= cost.Swood;
                        gameStats.Stone -= cost.Scristal;
                        break;

                    case Buildings.museum:
                        currentPrefab = Buildings.museum;
                        build = Instantiate(museum, toBuild.transform.position, toBuild.transform.rotation, transform);
                        gameStats.Wood -= cost.Mwood;
                        gameStats.Stone -= cost.Mcristal;
                        gameStats.Happiness += cost.Mhappiness;
                        break;
                }
                if (build != null)
                {
                    build.SetActive(true);
                    build.GetComponent<BoxCollider2D>().enabled = true;
                }
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
