using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    ItemDatabase itemDB;

    private void Start()
    {
        itemDB = FindObjectOfType<ItemDatabase>();
        itemDB.BuildItemDatabase();
        itemCapacity = 3;

        AddItem(itemDB.FindItemById(1), 3);
        AddItem(itemDB.FindItemById(2), 1);
        AddItem(itemDB.FindItemById(3), 6);
        AddItem(itemDB.FindItemById(4), 30);
        RemoveItem(itemDB.FindItemById(1), 3);
        RemoveItem(itemDB.FindItemById(1), 1);
        AddItem(itemDB.FindItemById(4), 30);
        RemoveItem(itemDB.FindItemById(2), 3);
    }
}
