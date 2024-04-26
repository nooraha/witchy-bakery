using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerInstance : MonoBehaviour
{
    public Customer customer;
    public string customerName;

    bool orderTaken = false;
    bool orderFulfilled = false;
    public Order currentOrder;

    SpriteRenderer spriteRenderer;
    PlayerInventory playerInventory;
    OrdersList ordersList;
    CustomerDatabase customerDB;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        ordersList = FindObjectOfType<OrdersList>();
        customerDB = FindObjectOfType<CustomerDatabase>();
    }

    public void UpdateCurrentOrder(Order order)
    {
        currentOrder = order;
        orderTaken = false;
        orderFulfilled = false;
    }

    public void UpdateCustomerIdentity(int customerId)
    {
        customer = customerDB.FindCustomerById(customerId);
        spriteRenderer.sprite = customer.sprite;
        customerName = customer.title;
    }

    public void TryToFulfillOrder()
    {
        Dictionary<int, int> requestedItems = currentOrder.requestedItems;
        if(playerInventory.InventoryContainsItems(requestedItems))
        {
            playerInventory.RemoveDictionaryItems(requestedItems);
            ordersList.MarkOrderComplete(currentOrder);
            orderFulfilled = true;
            LeaveBakery();
        }
        else
        {
            Debug.Log("Inventory doesn't contain all requested items!");
        }
    }

    public void TakeOrder()
    {
        ordersList.ActivateOrder(currentOrder);
        orderTaken = true;
    }

    public void TakeOrFulfillOrder()
    {
        if(!orderTaken)
        {
            TakeOrder();
            Debug.Log("Order taken!");
        }
        else
        {
            if(!orderFulfilled)
            {
                TryToFulfillOrder();
            }
            else
            {
                Debug.Log("Order fulfilled already");
                LeaveBakery();
            }
        }
    }

    public void LeaveBakery()
    {
        Destroy(gameObject);
        Debug.Log("Customer left the bakery and definitely didn't explode");
    }
}
