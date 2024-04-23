using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;
    public Transform gridTransform;

    CustomerDatabase customerDB;
    OrderDatabase orderDB;

    private void Awake()
    {
        customerDB = FindObjectOfType<CustomerDatabase>();
        orderDB = FindObjectOfType<OrderDatabase>();
    }

    private void Start()
    {
        SpawnNewCustomer(1, orderDB.FindOrderById(1));
    }

    public void SpawnNewCustomer(int customerId, Order order)
    {
        GameObject instance = Instantiate(customerPrefab, gridTransform);
        CustomerInstance customerInstance = instance.GetComponent<CustomerInstance>();
        customerInstance.UpdateCurrentOrder(order);
        customerInstance.UpdateCustomerIdentity(customerId);
    }
}
