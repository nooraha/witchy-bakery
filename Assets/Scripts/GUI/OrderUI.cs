using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class OrderUI : MonoBehaviour
{
    public Transform orderItemsPanel;
    public TMP_Text customerNameText;

    public Order order;

    public GameObject itemSlotPrefab;

    PlayerInventory playerInventory;
    ItemDatabase itemDB;

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    public void FillOrderInfo()
    {
        Dictionary<int, int> requestedItems = order.requestedItems;

        ResetOrderItemsPanel();
        FillOrderItemsPanel(requestedItems);
        //UpdateCustomerName(customerId);
    }

    void FillOrderItemsPanel(Dictionary<int, int> requestedItems)
    {
        foreach (KeyValuePair<int, int> pair in requestedItems)
        {
            int itemAmount = playerInventory.FindAmountOfItem(pair.Key);
            int requiredAmount = pair.Value;
            GameObject instance = Instantiate(itemSlotPrefab, orderItemsPanel);
            Item item = itemDB.FindItemById(pair.Key);
            instance.GetComponent<ItemSlotUI>().UpdateItem(item, itemAmount, requiredAmount);
        }
    }

    public void UpdateOrderItemsAmount()
    {
        for (int i = 0; i < orderItemsPanel.childCount; i++)
        {
            ItemSlotUI itemSlotUI = orderItemsPanel.GetChild(i).GetComponent<ItemSlotUI>();
            Item item = itemSlotUI.item;
            int itemAmount = playerInventory.FindAmountOfItem(item.id);
            itemSlotUI.UpdateItem(item, itemAmount, itemSlotUI.requiredAmount);
        }
    }

    public void SwitchOrderPosition()
    {
        if (transform.GetSiblingIndex() == transform.parent.childCount-1)
        {
            MoveOrderToBack();
        }
        else
        {
            MoveOrderOnTop();
        }
    }

    void MoveOrderOnTop()
    {
        transform.SetAsLastSibling();
    }

    void MoveOrderToBack()
    {
        transform.SetAsFirstSibling();
    }

    void ResetOrderItemsPanel()
    {
        while (orderItemsPanel.childCount > 0)
        {
            DestroyImmediate(orderItemsPanel.GetChild(0).gameObject);
        }
    }

    void UpdateCustomerName(int customerId)
    {
        customerNameText.text = customerId.ToString();
    }

    void DisplayNoOrdersInfo()
    {
        ResetOrderItemsPanel();
        customerNameText.text = "No orders";
    }
}
