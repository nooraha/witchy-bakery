using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDatabase : MonoBehaviour
{
    List<Order> orderDBList;

    private void Start()
    {
        BuildDatabase();
    }

    void BuildDatabase()
    {
        orderDBList = new List<Order>
        {
            new Order(0, new Dictionary<int, int>{}),
            new Order(1, new Dictionary<int, int>{{1, 2}}),
            new Order(2, new Dictionary<int, int>{{3, 1}})
        };
    }

    public Order FindOrderById(int orderId)
    {
        Order order = orderDBList.Find(i => i.id == orderId);
        if(order != null)
        {
            return order;
        }
        else
        {
            Debug.Log("Order with id " + orderId + " doesn't exist!");
            return orderDBList.Find(i => i.id == 0);
        }
    }
}
