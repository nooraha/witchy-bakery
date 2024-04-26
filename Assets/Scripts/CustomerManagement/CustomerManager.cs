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

    public void TestSpawnCustomer()
    {
        SpawnNewCustomer(1, orderDB.FindOrderById(1));
        SpawnNewCustomer(2, orderDB.FindOrderById(2));
    }

    public void SpawnNewCustomer(int customerId, Order order)
    {
        GameObject instance = Instantiate(customerPrefab, gridTransform);
        Vector2 newPosition = new Vector2(instance.transform.position.x + customerId, instance.transform.position.y - customerId);
        instance.transform.SetPositionAndRotation(newPosition, instance.transform.rotation);
        CustomerInstance customerInstance = instance.GetComponent<CustomerInstance>();
        customerInstance.UpdateCurrentOrder(order);
        customerInstance.UpdateCustomerIdentity(customerId);
    }
}
