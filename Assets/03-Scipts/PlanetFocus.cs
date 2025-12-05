using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetFocus : MonoBehaviour
{
    CinemachineVirtualCamera focusCamera;
    [SerializeField] CinemachineBrain brain;
    CinemachineCore core;

    void Start()
    {
        focusCamera = GetComponentInChildren<CinemachineVirtualCamera>(true);
        Debug.Log($"focus cam : { focusCamera.gameObject.name}");
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
