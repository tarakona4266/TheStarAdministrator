using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    float mouseScroll;
    bool scrollingUp = false;
    bool scrollingDown = false;

    public Ray ray; // reuse ray in construction script

    Vector3 mousePosition;
    Vector3 rayTarget;

    CameraMovement CamMovement;
    Camera cam;

    PlanetFocus targetPlanet;
    [SerializeField] PlanetInfos planetInfos;

    void Start()
    {
        CamMovement = GetComponent<CameraMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        // --- raycast ---
        ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 raydir = ray.direction * 105;
        Debug.DrawRay(ray.origin, raydir, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                targetPlanet = hit.collider.GetComponentInParent<PlanetFocus>();
                string tag = hit.transform.root.tag;
                planetInfos.DisplayInfos(tag);
                //Debug.Log(tag);
            }
        }
        else if (CamMovement.CanMove)
        {
            targetPlanet = null;
            planetInfos.DisplayInfos();
        }
        else
        {
            planetInfos.DisplayInfos();
        }

        // --- focus mode ---
        if (targetPlanet != null || !CamMovement.CanMove)
        {
            mouseScroll = Input.mouseScrollDelta.y;
            if (mouseScroll > 0)
            {
                scrollingUp = true;
                scrollingDown = false;
                if (CamMovement.CanMove)
                {
                    CamMovement.DisableMovement();
                    planetInfos.gameObject.SetActive(false);
                    targetPlanet.DoFocus();
                }
            }
            else if (mouseScroll < 0)
            {
                scrollingDown = true;
                scrollingUp = false;
                if (!CamMovement.CanMove)
                {
                    targetPlanet.UndoFocus();
                    planetInfos.gameObject.SetActive(true);
                    CamMovement.EnableMovement();
                    targetPlanet = null;
                }
            }
            else
            {
                scrollingDown = false;
                scrollingUp = false;
            }
        }
        
    }

}
