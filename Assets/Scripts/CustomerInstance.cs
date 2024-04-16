using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInstance : MonoBehaviour
{
    public Customer customer;
    bool orderTaken = false;
    bool orderFulfilled = false;
    Order currentOrder;

    SpriteRenderer spriteRenderer;
    PlayerInventory playerInventory;
    OrdersList ordersList;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        ordersList = FindObjectOfType<OrdersList>();

        UpdateCurrentOrder(new Order(1, 1, new Dictionary<int, int> { { 2, 1 } }));
        //spriteRenderer.sprite = customer's sprite
    }

    public void UpdateCurrentOrder(Order order)
    {
        currentOrder = order;
        orderTaken = false;
        orderFulfilled = false;
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

    public void MakeOrder()
    {
        ordersList.ActivateOrder(currentOrder);
        orderTaken = true;
    }

    public void TakeOrFulfillOrder()
    {
        if(!orderTaken)
        {
            MakeOrder();
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
            }
        }
    }

    public void LeaveBakery()
    {
        Destroy(gameObject);
        Debug.Log("Customer left the bakery and definitely didn't explode");
    }
}
