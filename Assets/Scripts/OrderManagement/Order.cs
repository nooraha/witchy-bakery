using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int id;
    public Dictionary<int, int> requestedItems;

    public Order(int id, Dictionary<int, int> requestedItems)
    {
        this.id = id;
        this.requestedItems = requestedItems;
    }
}