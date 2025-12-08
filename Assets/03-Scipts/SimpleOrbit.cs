using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleOrbit : MonoBehaviour
{
    [SerializeField] GameObject sun;
    [SerializeField] float orbitalVelocity = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(sun.transform.position, Vector3.up, orbitalVelocity * Time.deltaTime);
    }
}
