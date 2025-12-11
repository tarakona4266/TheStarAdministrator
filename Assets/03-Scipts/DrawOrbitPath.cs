using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrbitPath : MonoBehaviour
{
    [SerializeField] LineRenderer cirlceRenderer;
    [SerializeField] int segments = 50;
    [SerializeField] float lineWidth = 1f;
    [SerializeField] float radius;

    void Start()
    {
        cirlceRenderer.widthMultiplier = lineWidth;
        DrawCircle();
    }
    void DrawCircle()
    {
        cirlceRenderer.positionCount = segments; 
        for (int currentStep = 0; currentStep <= segments; currentStep++)
        {
            float circumferenceProgress = (float)currentStep / segments; 
            float currentRadian = circumferenceProgress * 2 * Mathf.PI; 

            float x = Mathf.Cos(currentRadian) * radius;
            float z = Mathf.Sin(currentRadian) * radius;

            Vector3 currentPosition = new Vector3(x, 0, z);

            cirlceRenderer.SetPosition(currentStep, currentPosition);
            print($"Progress : {currentStep}, Point position : {currentPosition}");

        }
    }
}