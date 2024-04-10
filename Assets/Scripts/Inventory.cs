using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> inventory = new Dictionary<int, int>();
    protected int itemCapacity = 12;

    public ItemDatabase itemDB;

    private void Awake()
    {
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    public void AddItem(int itemToAdd, int amount)
    {
        if(GetInventoryCapacity() < itemCapacity)
        {
            if(itemDB.FindItemById(itemToAdd) != null)
            {
                if(FindAmountOfItem(itemToAdd) == 0)
                {
                    inventory.Add(itemToAdd, amount);
                }
                else
                {
                    inventory[itemToAdd] += amount;
                }
                Debug.Log("Added " + amount + " of item " + itemToAdd + " to inventory!");
            }
            else
            {
                Debug.Log("Item " + itemToAdd + " not found!");
            }
        }
        else
        {
            Debug.Log("Inventory full!");
        }
    }

    public void RemoveItem(int itemToRemove, int amount)
    {
        if(inventory.ContainsKey(itemToRemove))
        {
            if (inventory[itemToRemove] - amount > 0)
            {
                inventory[itemToRemove] = inventory[itemToRemove] - amount;
                Debug.Log("Removed " + amount + " of " + itemToRemove + " from inventory!");
            }
            else if (inventory[itemToRemove] - amount == 0)
            {
                inventory.Remove(itemToRemove);
                Debug.Log("Removed all of " + itemToRemove + " from inventory!");
            }
            else
            {
                Debug.Log("Inventory doesn't contain " + amount + " of " + itemToRemove + "!");
            }
        }
        else
        {
            Debug.Log("Item not in inventory!");
        }
        
    }

    public int FindAmountOfItem(int item)
    {
        if(inventory.ContainsKey(item))
        {
            return inventory[item];
        }
        else
        {
            return 0;
        }
        
    }

    public int GetInventoryCapacity()
    {
        return inventory.Count;
    }
}
