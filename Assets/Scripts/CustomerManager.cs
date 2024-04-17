using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public GameObject customerPrefab;

    public void SpawnNewCustomer(Customer customer, Order order)
    {
        GameObject instance = Instantiate(customerPrefab);
        CustomerInstance customerInstance = instance.GetComponent<CustomerInstance>();
        customerInstance.UpdateCurrentOrder(order);
        customerInstance.UpdateCustomerIdentity(customer);
    }
}
