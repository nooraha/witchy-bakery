using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class CustomerDatabase : MonoBehaviour
{
    public List<Customer> customerList;

    private void Start()
    {
        BuildDatabase();
    }

    public void BuildDatabase()
    {
        customerList = new List<Customer> {
            {new Customer("unknown", 0, "") },
            {new Customer("bunny", 1, "testSprite") },
            {new Customer("bear", 2, "testSprite") },
            {new Customer("fox", 3, "testSprite") }
        };
    }

    public Customer FindCustomerById(int customerId)
    {
        Customer customer = customerList.Find(c => c.id == customerId);
        if (customer != null)
        {
            return customer;
        }
        else
        {
            Debug.Log("Customer with id " + customerId + " doesn't exist!");
            return customerList.Find(i => i.id == 0);
        }
    }
}
