using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 0.2f;
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isHorizontalRotation;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.position.x > Screen.width / 2)
            {
                // Detect the initial touch position when the touch begins
                if (touch.phase == TouchPhase.Began)
                {
                    startTouchPosition = touch.position;
                }

                // Detect movement during the touch
                if (touch.phase == TouchPhase.Moved)
                {
                    currentTouchPosition = touch.position;
                    Vector2 touchDelta = currentTouchPosition - startTouchPosition;

                    // Determine if the swipe is more horizontal or vertical
                    if (Mathf.Abs(touchDelta.x) > Mathf.Abs(touchDelta.y))
                    {
                        isHorizontalRotation = true;
                    }
                    else
                    {
                        isHorizontalRotation = false;
                    }

                    // Apply rotation based on the determined direction
                    if (isHorizontalRotation)
                    {
                        // Horizontal rotation (left-right)
                        float rotationY = -touchDelta.x * rotationSpeed;
                        transform.Rotate(0, rotationY, 0, Space.World);
                        player.Rotate(0, rotationY, 0,Space.World);

                    }
                    else
                    {
                        // Vertical rotation (up-down)
                        float rotationX = -touchDelta.y * rotationSpeed;
                        transform.Rotate(rotationX, 0, 0, Space.Self);
                    }

                    // Update the start position for the next frame
                    startTouchPosition = currentTouchPosition;
                }
            }
            
        }
    }
}

