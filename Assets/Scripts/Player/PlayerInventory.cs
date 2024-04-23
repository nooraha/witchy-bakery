using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : Inventory
{
    public UnityEvent onItemAdded = new UnityEvent();

    private void Start()
    {
        itemDB.BuildItemDatabase();
        itemCapacity = 99;

        AddItem(1, 3);
        
    }

    public override void AddItem(int itemToAdd, int amount)
    {
        base.AddItem(itemToAdd, amount);
        onItemAdded.Invoke();
    }
}
