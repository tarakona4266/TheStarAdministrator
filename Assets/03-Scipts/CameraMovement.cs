using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform camTransform;

    Vector3 mousePosition;
    float mouseX;
    float mouseY;

    float rightBorder;
    float leftBorder;
    float topBorder;
    float bottomBorder;

    [Header("Parameters")]
    [SerializeField] private float ScreenEdgeSize = 100;
    [SerializeField] private float movementSpeed = 5;
    [Header("Starting state")]
    [SerializeField] bool canMove;
    [HideInInspector] public bool CanMove
    {
        get { return canMove; }
    }

    void Start()
    {
        camTransform = GetComponent<Transform>();

        rightBorder = Screen.width - ScreenEdgeSize;
        leftBorder = ScreenEdgeSize;
        topBorder = Screen.height - ScreenEdgeSize;
        bottomBorder = ScreenEdgeSize;
    }

    private void Update()
    {
        if (canMove)
        {
            mousePosition = Input.mousePosition;
            mouseX = mousePosition.x;
            mouseY = mousePosition.y;

            if (mouseX > rightBorder)
            {
                camTransform.Translate(Vector3.right * movementSpeed * Time.deltaTime, Space.World);
            }
            if (mouseX < leftBorder)
            {
                camTransform.Translate(Vector3.left * movementSpeed * Time.deltaTime, Space.World);
            }
            if (mouseY > topBorder)
            {
                camTransform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);
            }
            if (mouseY < bottomBorder)
            {
                camTransform.Translate(Vector3.back * movementSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    public void EnableMovement()
    {
        canMove = true;
    }
    public void DisableMovement()
    {
        canMove = false;
    }
}
