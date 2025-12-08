using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FaceSun : MonoBehaviour
{
    [SerializeField] Transform sun;
    Vector3 direction;
    Quaternion rotation;

    void Start()
    {
    }

    void Update()
    {
        if (sun != null)
        {
            direction = sun.position - transform.position;
            Debug.DrawRay(transform.position, direction, Color.yellow);
            direction.Normalize();
            rotation = Quaternion.LookRotation(direction * -1);
            transform.rotation = rotation;
        }
    }
}
