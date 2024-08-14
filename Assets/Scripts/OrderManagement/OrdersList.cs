using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Events;

public class OrdersList : MonoBehaviour
{
    public List<Order> activeOrders = new List<Order>();
    public List<Order> completedOrders = new List<Order>();

    public UnityEvent<Order> onOrderTaken = new UnityEvent<Order>();
    public UnityEvent<Order> onOrderCompleted = new UnityEvent<Order>();

    PlayerInventory playerInventory;
    PlayerCurrency playerCurrency;
    ItemDatabase itemDB;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        playerCurrency = FindObjectOfType<PlayerCurrency>();
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    public void ActivateOrder(Order order)
    {
        activeOrders.Add(order);
        onOrderTaken.Invoke(order);
    }

    public void MarkOrderComplete(Order order)
    {
        if (activeOrders.Contains(order))
        {
            activeOrders.Remove(order);
            completedOrders.Add(order);
            GiveOrderCompletionRewards(order);
            Debug.Log("Completed order " + order.id);
            onOrderCompleted.Invoke(order);
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