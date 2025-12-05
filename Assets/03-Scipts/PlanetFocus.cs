using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineCore;

public class PlanetFocus : MonoBehaviour
{
    CinemachineVirtualCamera focusCamera;
    [SerializeField] CinemachineBrain brain;
    Canvas planetInfo;

    void Start()
    {
        focusCamera = GetComponentInChildren<CinemachineVirtualCamera>(true);
        planetInfo = GetComponentInChildren<Canvas>(true);
    }

    public void DoFocus()
    {
        planetInfo.gameObject.SetActive(false);
        focusCamera.gameObject.SetActive(true);
    }

    public void UndoFocus()
    {
        planetInfo.gameObject.SetActive(false);
        focusCamera.gameObject.SetActive(false);
    }

    public void DisplayInfos(bool state)
    {
        if (state)
        {
            planetInfo.gameObject.SetActive(true);
        }
        if (!state)
        {
            planetInfo.gameObject.SetActive(false);
        }
    }
}
