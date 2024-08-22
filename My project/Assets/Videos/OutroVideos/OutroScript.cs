using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroScript : MonoBehaviour
{
    public GameObject outro1;
    public GameObject outro2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableSecondVideo()
    {
        outro1.SetActive(false);
        outro2.SetActive(true);
        Debug.Log("the button is working");
    }
}
