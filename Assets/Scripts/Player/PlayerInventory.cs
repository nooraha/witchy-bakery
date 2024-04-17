using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{

    private void Start()
    {
        itemDB.BuildItemDatabase();
        itemCapacity = 99;

        AddItem(1, 3);
        
    }
}
