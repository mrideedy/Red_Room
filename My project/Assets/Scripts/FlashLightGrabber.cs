using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLightGrabber : MonoBehaviour
{

    public GameObject FLbutton;
    public GameObject flashLight;
    public new GameObject light;
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
        FLbutton.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.collider.tag == "FlashLight")
            {
                FLbutton.SetActive(true);
                Debug.Log("Grabbe It");
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            FLbutton.SetActive(false);
            Debug.Log("Did not Hit");
        }
    }

    public void flashLightGrab()
    {
        flashLight.SetActive(false);
        FLbutton.SetActive(false);
        light.SetActive(true);
    }
}
