using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> InventoryItem = new List<Item>();
    void Awake()
    {
        instance = this;
    }
    public void AddItem(Item item)
    {
        InventoryItem.Add(item);
    }
}
