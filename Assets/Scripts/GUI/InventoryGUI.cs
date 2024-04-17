using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : UICanvasManager
{
    PlayerInventory playerInventory;
    ItemDatabase itemDB;

    public Transform inventoryPanel;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        UIcanvas = GetComponent<CanvasGroup>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();

        HideUI();
    }

    void DisplayInventoryItems()
    {
        foreach(KeyValuePair<int, int> pair in playerInventory.GetFullInventory())
        {
            Item item = itemDB.FindItemById(pair.Key);
            int amount = pair.Value;

            GameObject instance = Instantiate(itemSlotPrefab, inventoryPanel);
            ItemSlotUI itemSlotUI = instance.GetComponent<ItemSlotUI>();
            itemSlotUI.UpdateItem(item, amount);
        }
    }

    void ResetInventoryItems()
    {
        while(inventoryPanel.childCount > 0)
        {
            DestroyImmediate(inventoryPanel.GetChild(0).gameObject);
        }
    }

    public void OpenInventoryGUI()
    {
        ShowUI();
        ResetInventoryItems();
        DisplayInventoryItems();
    }
}
