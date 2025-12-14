using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform camTransform;

    Vector3 mousePosition;
    Vector3 moveDir;
    float mouseX;
    float mouseY;

    float rightBorder;
    float leftBorder;
    float topBorder;
    float bottomBorder;

    [Header("Parameters")]
    [SerializeField] private float screenEdgeSize = 20;
    [SerializeField] private float movementSpeed = 15;
    [Header("Starting state")]
    [SerializeField] bool canMove;
    [HideInInspector] public bool CanMove
    {
        get { return canMove; }
    }

    void Start()
    {
        camTransform = GetComponent<Transform>();

        screenEdgeSize = Screen.width * screenEdgeSize / 100;

        rightBorder = Screen.width - screenEdgeSize;
        leftBorder = screenEdgeSize;
        topBorder = Screen.height - screenEdgeSize;
        bottomBorder = screenEdgeSize;
    }

    private void Update()
    {
        if (canMove)
        {
            mousePosition = Input.mousePosition;
            mouseX = mousePosition.x;
            mouseY = mousePosition.y;

            if (mouseX > rightBorder && camTransform.position.x < 15)
            {
                moveDir.x = 1;
            }
            else if (mouseX < leftBorder && camTransform.position.x > -15)
            {
                moveDir.x = -1;
            }
            else { moveDir.x = 0; }

            if (mouseY > topBorder && camTransform.position.z < 35)
            {
                moveDir.z = 1;
            }
            else if (mouseY < bottomBorder && camTransform.position.z > -35)
            {
                moveDir.z = -1;
            }
            else { moveDir.z = 0; }

            moveDir.Normalize();
            camTransform.Translate(moveDir * movementSpeed * Time.deltaTime, Space.World);

            //print(camTransform.position);
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
