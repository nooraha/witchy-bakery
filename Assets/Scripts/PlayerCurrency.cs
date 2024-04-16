using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    private int goldAmount = 0;
    public GoldCounter goldCounter;

    private void Awake()
    {
        goldCounter = FindObjectOfType<GoldCounter>();
    }

    private void Start()
    {
        AddGold(500);
    }

    public void AddGold(int amount)
    {
        goldAmount += amount;
        goldCounter.UpdateGoldCounter(goldAmount);
    }

    public void RemoveGold(int amount)
    {
        goldAmount -= amount;
        goldCounter.UpdateGoldCounter(goldAmount);
    }

    public int GetCurrentGold()
    {
        return goldAmount;
    }
}
