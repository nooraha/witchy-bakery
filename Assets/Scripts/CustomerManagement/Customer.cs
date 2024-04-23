using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public string title;
    public int id;
    public Sprite sprite;

    public Customer(string title, int id, string sprite)
    {
        this.title = title;
        this.id = id;
        this.sprite = Resources.Load<Sprite>("Sprites/Customers/" + sprite);
    }
}
