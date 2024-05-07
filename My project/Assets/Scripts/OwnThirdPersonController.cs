using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnThirdPersonController : MonoBehaviour
{
    public FixedJoystick leftJS;
    public FixedButton rightButton;
    public FixedTouchField touchField;

    public Actions actions;
    public PlayerController playerController;
    public Rigidbody rb;

    protected float CameraAngleY;
    protected float CameraAngleSpeed = 0.1f;
    protected float CameraPosY;
    protected float CameraPosSpeed = 0.1f;
 
    // Start is called before the first frame update
    void Start()
    {
        actions = GetComponent<Actions>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(-leftJS.Horizontal, 0, -leftJS.Vertical);
        var vel = Quaternion.AngleAxis(CameraAngleY + 180, Vector3.up) * input * 5f;

        rb.velocity = new Vector3(-vel.x, rb.velocity.y,-vel.z);
        transform.rotation = Quaternion.AngleAxis(CameraAngleY + Vector3.SignedAngle(Vector3.forward, input.normalized + Vector3.forward * 0.001f, Vector3.up), Vector3.up);

        CameraAngleY += touchField.TouchDist.x * CameraAngleSpeed;

        Camera.main.transform.position = transform.position + Quaternion.AngleAxis(CameraAngleY, Vector3.up) * new Vector3(0, 3, 4);
        Camera.main.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f - Camera.main.transform.position, Vector3.up);

        if(rb.velocity.magnitude > 3f)
        {
            actions.Run();
        }
        else
        {
            actions.Stay();
        }
    }
}
