using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int id;
    public string customer;
    public List<Item> items;

    public Order(int id, string customer, List<Item> items)
    {
        this.id = id;
        this.customer = customer;
        this.items = items;
    }
}

public class OrdersList : MonoBehaviour
{
    public List<Order> activeOrders;
    public List<Order> completedOrders;

    public Order FindOrderById(int orderId)
    {
        return activeOrders.Find(o => o.id == orderId);
    }

    public void AddNewOrder(Order order)
    {
        activeOrders.Add(order);
    }

    public void MarkOrderComplete(int orderId)
    {
        Order orderToComplete = FindOrderById(orderId);
        if(activeOrders.Contains(orderToComplete))
        {
            activeOrders.Remove(orderToComplete);
            completedOrders.Add(orderToComplete);
        }
        else
        {
            Debug.Log("Order not active!");
        }
    }
}