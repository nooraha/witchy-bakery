using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Inventory : MonoBehaviour
{
    Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    protected int itemCapacity = 12;

    public void AddItem(Item itemToAdd, int amount)
    {
        if(GetInventoryCapacity() < itemCapacity)
        {
            if(itemToAdd != null)
            {
                inventory.Add(itemToAdd, amount);
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

    public void RemoveItem(Item itemToRemove, int amount)
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

    public int FindAmountOfItem(Item item)
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

    public List<Item> FindItemsByTag(string tag)
    {
        List<Item> matches = inventory.Where(pair => pair.Key.tags.Contains(tag))
            .Select(pair => pair.Key)
            .ToList();
        return matches;
    }
}
