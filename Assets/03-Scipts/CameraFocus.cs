using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    float mouseScroll;
    bool scrollingUp = false;
    bool scrollingDown = false;

    CameraMovement CamMovement;

    //temporary
    [SerializeField] PlanetFocus planet;

    void Start()
    {
        CamMovement = GetComponent<CameraMovement>();
    }

    void Update()
    {
        mouseScroll = Input.mouseScrollDelta.y;
        if (mouseScroll > 0)
        {
            scrollingUp = true;
            scrollingDown = false;
            if (CamMovement.CanMove)
            {
                CamMovement.DisableMovement();
                planet.DoFocus();
            }
        }
        else if (mouseScroll < 0)
        {
            scrollingDown = true;
            scrollingUp = false;
            if (!CamMovement.CanMove)
            {
                planet.UndoFocus();
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
