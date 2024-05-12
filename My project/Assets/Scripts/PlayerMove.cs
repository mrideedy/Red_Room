using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    private CharacterController controller;
    public float moveSpeed = 5.0f;

    //Camera Rotation
    private Touch theTouch;
    private float cameraSensitivity = 5f;
    public Transform cameraTransform;
    private float cameraPitch;
    private float halfOfScreenWidth;
    private Vector2 lookInput;
    private bool isOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<CharacterController>();

        halfOfScreenWidth = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(move * moveSpeed * Time.deltaTime);

        GetTouchInput();

        if (isOnScreen)
        {
            LookAround();
        }
    }

    void LookAround()
    {

        // vertical (pitch) rotation
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        // horizontal (yaw) rotation
        transform.Rotate(transform.up, lookInput.x);
    }

    public void GetTouchInput()
    {
        
          if (Input.touchCount > 0)
          {
                theTouch = Input.GetTouch(0);
                isOnScreen = true;
                if(theTouch.position.x > halfOfScreenWidth)
                {
                    if (theTouch.phase == TouchPhase.Began)
                    {
                        Debug.Log("Touch Start");

                    }
                    else if (theTouch.phase == TouchPhase.Moved)
                    {
                        Debug.Log("Touch Moved");
                        lookInput = theTouch.deltaPosition * cameraSensitivity * Time.deltaTime;
                    }
                    else if (theTouch.phase == TouchPhase.Stationary)
                    {
                        lookInput = Vector2.zero;
                    }
                    else if (theTouch.phase == TouchPhase.Ended)
                    {
                        Debug.Log("Touch Ended");
                    }
                }
                
          }
          else
          {
            isOnScreen = false;
          }
        
    }
}
