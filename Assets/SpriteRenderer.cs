using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class SpriteRenderer : MonoBehaviour
{
    [SerializeField] private Camera Camera;
    private void LateUpdate()
    {
        Vector3 cameraPosition = Camera.transform.position;
        cameraPosition.y = transform.position.y;
        transform.LookAt(cameraPosition);
        transform.Rotate(0f,180f,0f);
    }
}
