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
        SelectPrefab(house);
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

                        }
                        else if (!homePlanet && tag == "planet_food")
                        {
                            buildRotation = hit.normal;
                            buildPosition = hit.point;
                            validPlanet = true;
                        }
                        else
                        {
                            validPlanet = false;
                        }
                    }
                }
                
                // dislay building preview
                if (validPlanet)
                {
                    toBuild.transform.position = buildPosition;
                    toBuild.transform.rotation = Quaternion.Euler(buildRotation);
                }
            }
        }
    }

    public void SelectPrefab(GameObject prefab)
    {
        toBuild = Instantiate(prefab, transform);
        toBuild.transform.position = buildPosition;
        toBuild.transform.rotation = Quaternion.Euler(buildRotation);
        toBuild.SetActive(true);
    }
}
