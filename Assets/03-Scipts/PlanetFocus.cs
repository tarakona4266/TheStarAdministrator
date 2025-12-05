using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineCore;

public class PlanetFocus : MonoBehaviour
{
    CinemachineVirtualCamera focusCamera;
    [SerializeField] CinemachineBrain brain;

    void Start()
    {
        focusCamera = GetComponentInChildren<CinemachineVirtualCamera>(true);
    }

    public void DoFocus()
    {
        focusCamera.gameObject.SetActive(true);
    }
    public void UndoFocus()
    {
        focusCamera.gameObject.SetActive(false);
    }
}
