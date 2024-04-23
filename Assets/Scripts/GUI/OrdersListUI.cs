using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using TMPro;

public class OrdersListUI : MonoBehaviour
{
    public Transform orderItemsPanel;
    public TMP_Text customerNameText;

    public GameObject itemSlotPrefab;

    int displayedOrderIndex = 0;

    PlayerInventory playerInventory;
    ItemDatabase itemDB;
    OrdersList ordersList;

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
        ordersList = FindObjectOfType<OrdersList>();
    }

    private void Start()
    {
        UpdateDisplayedOrder();
        playerInventory.onItemAdded.AddListener(UpdateOrderItemsAmount);
    }

    public void FillOrderInfo(Order order)
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

    void UpdateOrderItemsAmount()
    {
        for(int i = 0; i < orderItemsPanel.childCount; i++)
        {
            ItemSlotUI itemSlotUI = orderItemsPanel.GetChild(i).GetComponent<ItemSlotUI>();
            Item item = itemSlotUI.item;
            int itemAmount = playerInventory.FindAmountOfItem(item.id);
            itemSlotUI.UpdateItem(item, itemAmount,itemSlotUI.requiredAmount);
        }
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

    public void UpdateDisplayedOrder()
    {
        if(displayedOrderIndex >= ordersList.activeOrders.Count)
        {
            displayedOrderIndex = 0;
        }

        if(ordersList.activeOrders.Count != 0)
        {
            Order displayedOrder = ordersList.activeOrders[displayedOrderIndex];
            FillOrderInfo(displayedOrder);
        }
        else
        {
            DisplayNoOrdersInfo();
        }
    
        
    }

    public void DisplayNextOrder()
    {
        if (displayedOrderIndex == ordersList.activeOrders.Count - 1)
        {
            displayedOrderIndex = 0;
        }
        else
        {
            displayedOrderIndex++;
        }

        UpdateDisplayedOrder();
    }
}
