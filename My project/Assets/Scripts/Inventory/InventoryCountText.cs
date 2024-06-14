using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryCountText : MonoBehaviour
{
     public static InventoryCountText instance;
    //public Text debugText;
    public TMP_Text inventoryCountText; // Reference to the UI Text element for inventory count

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        /*if (debugText == null)
        {
            Debug.LogError("Debug Text UI element is not assigned.");
        }*/

        if (inventoryCountText == null)
        {
            Debug.LogError("Inventory Count UI element is not assigned.");
        }
    }

    /*public void Log(string message)
    {
        if (debugText != null)
        {
            debugText.text += message + "\n";
        }
    }*/

    public void UpdateInventoryCount(int count)
    {
        if (inventoryCountText != null)
        {
            inventoryCountText.text = "Number of Hearts collected: " + count;
        }
    }
}
