using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    float mouseScroll;
    bool scrollingUp = false;
    bool scrollingDown = false;

    Vector3 mousePosition;
    [SerializeField] Vector3 rayTarget;

    CameraMovement CamMovement;
    Camera cam;

    PlanetFocus targetPlanet;

    void Start()
    {
        CamMovement = GetComponent<CameraMovement>();
        cam = Camera.main;
    }

    void Update()
    {
        // --- raycast ---
        Ray ray =  Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 raydir = ray.direction * 105;
        Debug.DrawRay(ray.origin, raydir, Color.green);

        // --- scroll ---
        mouseScroll = Input.mouseScrollDelta.y;
        if (mouseScroll > 0)
        {
            scrollingUp = true;
            scrollingDown = false;
            if (CamMovement.CanMove)
            {
                CamMovement.DisableMovement();
                //targetPlanet.DoFocus();
            }
        }
        else if (mouseScroll < 0)
        {
            scrollingDown = true;
            scrollingUp = false;
            if (!CamMovement.CanMove)
            {
                //targetPlanet.UndoFocus();
                CamMovement.EnableMovement();
            }
        }
        else
        {
            scrollingDown = false;
            scrollingUp = false;
        }
        
    }

}
