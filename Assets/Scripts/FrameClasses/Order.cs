using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int id;
    public int customer;
    public List<int> items;
    public Payout payout;

    public Order(int id, int customer, List<int> items, Payout payout)
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

    PlayerInventory playerInventory;

    private void Start()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public List<Order> GetActiveOrders()
    {
        return activeOrders;
    }

    public Order FindOrderById(int orderId)
    {
        return activeOrders.Find(o => o.id == orderId);
    }

    public void ActivateOrder(Order order)
    {
        activeOrders.Add(order);
    }

    public void MarkOrderComplete(Order order)
    {
        if(activeOrders.Contains(order))
        {
            activeOrders.Remove(order);
            completedOrders.Add(order);
        }
        else
        {
            Debug.Log("Order not found in active orders!");
        }
    }

    public void GiveOrderPayout(Order order)
    {
        // increment exp by order.payout.exp
        // increment money by order.payout.money
        foreach(KeyValuePair<int, int> pair in order.payout.items)
        {
            playerInventory.AddItem(pair.Key, pair.Value);
        }
        
    }

}

public class OrderDatabase : MonoBehaviour
{

    public List<Order> orderList;

    private void Start()
    {
        BuildOrderDatabase();
    }

    public void BuildOrderDatabase()
    {

    }

    public void AddNewOrder(int id, int customer, List<int> items, Payout payout)
    {
        orderList.Add(new Order(id, customer, items, payout));
    }
}