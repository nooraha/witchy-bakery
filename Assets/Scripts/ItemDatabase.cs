using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> itemList;

    private void Start()
    {
    }

    public void BuildItemDatabase()
    {
        itemList = new List<Item>
        {
            { new Item(0, "Unknown", 0, "", new List<string> {}, "") },
            { new Item(1, "Apple", 1, "A shiny red apple", new List<string>
            {
                "fruit", "sweet", "ingredient"
            }, "") },
            {new Item(2, "Flour", 1, "It doesn't taste like anything", new List<string>
            {
                "ingredient"
            }, "") },
            {new Item(3, "Cocoa powder", 2, "So good...", new List<string>
            {
                "ingredient"
            }, "") },
            new Item(4, "Green Slime", 1, "Slimey", new List<string>
            {
                "disgusting", "inedible", "ingredient"
            }, "")
        };
    }

    public Item FindItemById(int itemId)
    {
        Item item = itemList.Find(i => i.id == itemId);
        if(item != null)
        {
            return item;
        }
        else
        {
            Debug.Log("Item with id " + itemId + " doesn't exist!");
            return itemList.Find(i => i.id == 0);
        }
    }

    public List<Item> FindItemsByTag(string tag)
    {
        List<Item> matches = itemList.FindAll(item => item.tags.Contains(tag));
        return matches;
    }
}
