using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineCore;

public class PlanetFocus : MonoBehaviour
{
    CinemachineVirtualCamera focusCamera;
    [SerializeField] CinemachineBrain brain;
    [SerializeField] GameObject surfaceCanvas = null;
    [SerializeField] GameObject surface;

    void Start()
    {
        focusCamera = GetComponentInChildren<CinemachineVirtualCamera>(true);
    }

    public void DoFocus()
    {
        surface.SetActive(true);
        focusCamera.gameObject.SetActive(true);
        if (surfaceCanvas != null) { surfaceCanvas.gameObject.SetActive(true); }
    }

    public void UndoFocus()
    {
        focusCamera.gameObject.SetActive(false);
        if (surfaceCanvas != null) { surfaceCanvas.gameObject.SetActive(false); }
        surface.SetActive(false);
    }

}
