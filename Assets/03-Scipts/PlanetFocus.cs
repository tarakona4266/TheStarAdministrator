using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineCore;

public class PlanetFocus : MonoBehaviour
{
    CinemachineVirtualCamera focusCamera;
    [SerializeField] CinemachineBrain brain;
    [SerializeField] Canvas planetInfo;

    void Start()
    {
        focusCamera = GetComponentInChildren<CinemachineVirtualCamera>(true);
    }

    public void DoFocus()
    {
        DisplayInfos(false);
        focusCamera.gameObject.SetActive(true);
    }

    public void UndoFocus()
    {
        DisplayInfos(true);
        focusCamera.gameObject.SetActive(false);
    }

    public void DisplayInfos(bool state)
    {
        if (planetInfo != null)
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
}
