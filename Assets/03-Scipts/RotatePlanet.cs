using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] Transform sun;
    Vector3 direction;
    Quaternion rotation;
    Canvas planetInfo;

    void Start()
    {
        planetInfo = GetComponentInChildren<Canvas>();
    }

    void Update()
    {
        direction = sun.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.yellow);
        direction.Normalize();
        rotation = Quaternion.LookRotation(direction * -1);
        transform.rotation = rotation;
        //Debug.Log(rotation);
    }
}
