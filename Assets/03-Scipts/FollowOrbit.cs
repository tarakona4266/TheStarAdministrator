using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOrbit : MonoBehaviour
{
    [SerializeField] Transform positionReference;
    void Start()
    {
        transform.position = positionReference.position;
    }

    void Update()
    {
        transform.position = positionReference.position;
    }
}
