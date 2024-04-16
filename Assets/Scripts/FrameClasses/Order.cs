using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int id;
    public int customer;
    public Dictionary<int, int> requestedItems;

    public Order(int id, int customer, Dictionary<int, int> requestedItems)
    {
        this.id = id;
        this.customer = customer;
        this.requestedItems = requestedItems;
    }
}