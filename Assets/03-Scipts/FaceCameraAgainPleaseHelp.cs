using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraAgainPleaseHelp : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    Vector3 rayDirection;
   
    void Awake()
    {
        Vector3 rotation = Vector3.zero;
        
        Ray ray = new Ray(camTransform.position, rayDirection);
        Debug.DrawRay(camTransform.position, rayDirection, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                rotation = hit.normal;
                print("collision");
            }
            else
            {
                print("no collision");
            }
        }
        transform.rotation = Quaternion.FromToRotation(transform.up, rotation) * transform.rotation;
    }
}
