using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGUI : UICanvasManager
{
    PlayerInventory playerInventory;

    public Transform inventoryPanel;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        UIcanvas = GetComponent<CanvasGroup>();
        playerInventory = FindObjectOfType<PlayerInventory>();

        HideUI();
    }

    void FillInventoryWithSlots()
    {
        for(int i = 0; i < playerInventory.GetItemCapacity(); i++)
        {
            GameObject instance = Instantiate(itemSlotPrefab, inventoryPanel);
        }
    }
}
