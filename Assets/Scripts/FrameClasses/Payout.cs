using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payout
{
    public int exp;
    public int money;
    public Dictionary<Item, int> items;

    public Payout(int exp, int money, Dictionary<Item, int> items)
    {
        this.exp = exp;
        this.money = money;
        this.items = items;
    }
}
