using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Construction : MonoBehaviour
{
    [SerializeField] CameraFocus cameraFocus;
    [SerializeField] Stats gameStats;
    [Header("Prefabs")]
    [SerializeField] GameObject house;
    [SerializeField] GameObject farm;
    [SerializeField] GameObject deco;

    public bool constructionMode;

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
                        buildRotation = hit.normal;
                        buildPosition = hit.point;
                    }
                }

                // dislay building preview
                toBuild.transform.position = buildPosition;
                toBuild.transform.rotation = Quaternion.Euler(buildRotation);
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
