using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPlanetSurface : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    Vector3 rayDirection;

    void Start()
    {
        rayDirection = transform.position - camTransform.position;

        Ray ray = new Ray(camTransform.position, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Vector3 position = hit.point;
                Vector3 rotation = hit.normal;
                transform.position = position;
                transform.rotation = Quaternion.FromToRotation(transform.up, rotation) * transform.rotation;
            }
        }
    }

    private void OnRenderObject()
    {
        rayDirection = transform.position - camTransform.position;

        Ray ray = new Ray(camTransform.position, rayDirection);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                Vector3 position = hit.point;
                Vector3 rotation = hit.normal;
                transform.position = position;
                transform.rotation = Quaternion.FromToRotation(transform.up, rotation) * transform.rotation;
            }
        }
    }

}
