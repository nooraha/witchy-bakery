using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : BaseMenu
{
    PlayerInventory playerInventory;
    ItemDatabase itemDB;

    public Transform inventoryPanel;

    public GameObject itemSlotPrefab;

    protected override void Awake()
    {
        base.Awake();
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    private void Start()
    {
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

    public override void OpenMenu()
    {
        base.OpenMenu();
        ResetInventoryItems();
        DisplayInventoryItems();
    }
}
