using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using TMPro;

public class OrdersListUI : MonoBehaviour
{
    List<OrderUI> orderUIs = new List<OrderUI>();

    int displayedOrderIndex = 0;

    PlayerInventory playerInventory;
    ItemDatabase itemDB;
    OrdersList ordersList;

    public GameObject orderUIPrefab;
    public Transform orderPanel;

    private void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
        ordersList = FindObjectOfType<OrdersList>();
    }

    private void Start()
    {
        //UpdateDisplayedOrder();
        playerInventory.onItemAdded.AddListener(UpdateAllOrderItemsAmount);
        ordersList.onOrderTaken.AddListener(InstantiateNewOrder);
        ordersList.onOrderCompleted.AddListener(RemoveOrder);
    }

    public void UpdateAllOrderItemsAmount()
    {
        foreach(OrderUI orderUI in orderUIs)
        {
            orderUI.UpdateOrderItemsAmount();
        }
    }

    public void InstantiateNewOrder(Order order)
    {
        GameObject instance = Instantiate(orderUIPrefab, orderPanel);
        instance.transform.SetAsFirstSibling();
        OrderUI orderUI = instance.GetComponent<OrderUI>();
        orderUI.order = order;
        orderUI.FillOrderInfo();
        orderUIs.Add(orderUI);
    }

    public void RemoveOrder(Order order)
    {
        OrderUI orderUIToRemove = orderUIs.Find(i => i.order == order);
        if(orderUIToRemove != null)
        {
            orderUIs.Remove(orderUIToRemove);
            Destroy(orderUIToRemove.gameObject);
        }
        
    }

    //public void UpdateDisplayedOrder()
    //{
    //    if(displayedOrderIndex >= ordersList.activeOrders.Count)
    //    {
    //        displayedOrderIndex = 0;
    //    }

    //    if(ordersList.activeOrders.Count != 0)
    //    {
    //        Order displayedOrder = ordersList.activeOrders[displayedOrderIndex];
    //        FillOrderInfo(displayedOrder);
    //    }
    //    else
    //    {
    //        DisplayNoOrdersInfo();
    //    }
  
    //}

    //public void DisplayNextOrder()
    //{
    //    if (displayedOrderIndex == ordersList.activeOrders.Count - 1)
    //    {
    //        displayedOrderIndex = 0;
    //    }
    //    else
    //    {
    //        displayedOrderIndex++;
    //    }

    //    UpdateDisplayedOrder();
    //}
}
