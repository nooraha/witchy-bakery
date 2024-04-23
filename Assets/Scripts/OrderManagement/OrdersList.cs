using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class OrdersList : MonoBehaviour
{
    public List<Order> activeOrders = new List<Order>();
    public List<Order> completedOrders = new List<Order>();

    PlayerInventory playerInventory;
    PlayerCurrency playerCurrency;
    ItemDatabase itemDB;
    OrdersListUI ordersListUI;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerCurrency = FindObjectOfType<PlayerCurrency>();
        itemDB = FindObjectOfType<ItemDatabase>();
        ordersListUI = FindObjectOfType<OrdersListUI>();
    }

    public void ActivateOrder(Order order)
    {
        activeOrders.Add(order);
        ordersListUI.UpdateDisplayedOrder();
    }

    public void MarkOrderComplete(Order order)
    {
        if (activeOrders.Contains(order))
        {
            activeOrders.Remove(order);
            completedOrders.Add(order);
            GiveOrderCompletionRewards(order);
            Debug.Log("Completed order " + order.id);
            ordersListUI.UpdateDisplayedOrder();
        }
        else
        {
            Debug.Log("Order not found in active orders!");
        }
    }

    void GiveOrderCompletionRewards(Order order)
    {
        playerCurrency.AddGold(CalculateReward(order));
    }

    int CalculateReward(Order order)
    {
        int totalCost = 0;

        foreach (KeyValuePair<int, int> pair in order.requestedItems)
        {
            int itemId = pair.Key;
            int itemAmount = pair.Value;

            int itemRarity = itemDB.FindItemById(itemId).rarity;
            double itemCost = Mathf.Pow(2, itemRarity) * 10;

            totalCost += (int)itemCost * itemAmount;
        }

        return totalCost;
    }

}