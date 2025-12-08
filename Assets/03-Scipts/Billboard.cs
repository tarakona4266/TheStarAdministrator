using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 camPosition = cam.transform.position;
        camPosition.y = transform.position.y;
        transform.LookAt(camPosition);
    }
}
