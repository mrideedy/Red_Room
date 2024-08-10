using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public FixedJoystick joystick;
    private CharacterController controller;
    public float moveSpeed = 5.0f;
    public Transform cameraTransform;
    

    //Camera Rotation
    private Touch theTouch;
    
    
    
    
  
   

    Inventory inventory;
    int currentCount;
    public GameObject FireCanvas;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<CharacterController>();

       
    }

    // Update is called once per frame
    void Update()
    {
        // Get the camera's forward direction (only considering horizontal direction)
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // Eliminate the y component to prevent vertical influence
        cameraForward.Normalize();

        // Get the camera's right direction (perpendicular to forward)
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0; // Eliminate the y component to prevent vertical influence
        cameraRight.Normalize();

        // Calculate the movement direction relative to the camera's orientation
        Vector3 move = cameraRight * joystick.Horizontal + cameraForward * joystick.Vertical;

        controller.Move(move * moveSpeed * Time.deltaTime);

    }






    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if(col.gameObject.tag == "Heart")
        {
            Item item = new Item();
            item.itemType = ItemType.Heart;
            Inventory.instance.AddItem(item);
            currentCount = Inventory.instance.InventoryItem.Count;
            //InventoryCountText.instance.Log("Item added to inventory. Count: " + currentCount);
            InventoryCountText.instance.UpdateInventoryCount(currentCount);
            Debug.Log(Inventory.instance.InventoryItem.Count);
            Destroy(col.gameObject);
            Debug.Log("goball");
        }
        if(col.gameObject.tag == "Fire")
        {
            if(currentCount == 3)
            {
                FireCanvas.SetActive(true);
            }
        }
    }
}

