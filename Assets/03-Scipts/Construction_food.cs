using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Construction_food : MonoBehaviour
{
    [SerializeField] CameraFocus cameraFocus;
    [SerializeField] Stats gameStats;
    [Header("Prefabs")]
    [SerializeField] GameObject farm;

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
                    if (doOnce)
                    {
                        toBuild.transform.Rotate(Vector3.up, 30f, Space.Self);
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
        }
        else
        {
            constructionMode = true;
        }
    }

    public void SelectPrefab()
    {
        if (toBuild != null) { Destroy(toBuild); }

        toBuild = Instantiate(farm, transform);

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
            GameObject build = Instantiate(farm, toBuild.transform.position, toBuild.transform.rotation, transform);
            if (build != null)
            {
                build.SetActive(true);
                build.GetComponent<BoxCollider2D>().enabled = true;
                gameStats.Farm++;
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
