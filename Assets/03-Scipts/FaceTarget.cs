using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FaceTarget : MonoBehaviour
{
    [SerializeField] Transform lookTarget;
    Vector3 direction;
    Quaternion rotation;

    void Start()
    {
    }

    void Update()
    {
        if (lookTarget != null)
        {

            direction = lookTarget.position - transform.position;
            Debug.DrawRay(transform.position, direction, Color.yellow);
            direction.Normalize();
            rotation = Quaternion.LookRotation(direction * -1);
            transform.rotation = rotation;
        }
    }
}
