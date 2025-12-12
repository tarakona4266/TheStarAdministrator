using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Construction_food : MonoBehaviour
{
    [SerializeField] CameraFocus cameraFocus;
    [SerializeField] Stats gameStats;
    [SerializeField] Construction_cost_stats cost;
    [SerializeField] GameObject costDisplay;
    [SerializeField] ConstructionAudioController audioController;
    [Header("Prefabs")]
    [SerializeField] GameObject farm;
    [SerializeField] float rotationOffset = 0f;
    [Header("UI")]
    [SerializeField] TextMeshProUGUI woodCost;
    [SerializeField] TextMeshProUGUI cristalCost;
    [SerializeField] TextMeshProUGUI builderCost;
    [SerializeField] TextMeshProUGUI happinessBonus;

    public bool constructionMode;
    bool validPlanet;

    bool mouseRightClick;
    bool doOnce = true;

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
                        if (hit.transform.root.CompareTag("planet_food"))
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
                    rotation.Normalize();

                    toBuild.transform.rotation = rotation;
                    if (doOnce) // otherwise the building dosen't face the camera
                    {
                        toBuild.transform.Rotate(Vector3.up, rotationOffset, Space.Self);
                        doOnce = false;
                    }
                    
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
            if (costDisplay.activeSelf)
            {
                costDisplay.SetActive(false);
                woodCost.text = "-";
                cristalCost.text = "-";
                builderCost.text = "-";
                happinessBonus.text = "-";
            }
        }
        else
        {
            constructionMode = true;
            costDisplay.SetActive(true);
        }
    }

    public void SelectPrefab()
    {
        doOnce = true;

        if (toBuild != null) { Destroy(toBuild); }

        toBuild = Instantiate(farm, transform);

        if (toBuild != null)
        {
            toBuild.transform.position = buildPosition;
            toBuild.transform.rotation = Quaternion.Euler(buildRotation);
        }

        int[] buildingCost = cost.GetCost("farm");

        woodCost.text = string.Format($"{buildingCost[0]}");
        cristalCost.text = string.Format($"{buildingCost[1]}");
        builderCost.text = string.Format($"{buildingCost[2]}");
        happinessBonus.text = string.Format($" + {buildingCost[3]}");
    }

    void Build()
    {
        if (validPlanet)
        {
            bool canBuild = cost.VerifyCost(gameStats.Wood, gameStats.Stone, 1, "farm");

            if (canBuild)
            {
                GameObject build = Instantiate(farm, toBuild.transform.position, toBuild.transform.rotation, transform);
                if (build != null)
                {
                    build.SetActive(true);
                    build.GetComponent<BoxCollider2D>().enabled = true;
                    gameStats.Farm++;
                    gameStats.Wood -= cost.Fwood;
                    gameStats.Stone -= cost.Fcristal;
                    audioController.PlaySound(true);
                }
            }
            else
            {
                audioController.PlaySound(false);
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
