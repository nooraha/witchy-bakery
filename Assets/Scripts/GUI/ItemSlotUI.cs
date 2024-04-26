using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    public Item item;

    public int requiredAmount;
    public int itemAmount;

    private TMP_Text itemNameText;
    private Image itemImage;
    private TMP_Text itemAmountText;

    

    private void Awake()
    {
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        itemNameText = transform.Find("ItemName").GetComponent<TMP_Text>();
        itemAmountText = transform.Find("ItemAmount").GetComponent<TMP_Text>();
    }

    public void UpdateItem(Item item, int itemAmount = 1, int requiredAmount = 0)
    {
        this.item = item;
        if(this.item != null)
        {
            itemNameText.text = item.title;
            itemImage.color = Color.white;
            itemImage.sprite = this.item.sprite;
            itemAmountText.color = Color.black;

            this.requiredAmount = requiredAmount;
            this.itemAmount = itemAmount;

            if(requiredAmount != 0)
            {
                itemAmountText.text = itemAmount + "/" + requiredAmount;
                if(itemAmount < requiredAmount)
                {
                    itemAmountText.color = Color.red;
                }
            }
            else if(itemAmount != 1)
            {
                itemAmountText.text = itemAmount.ToString();
            }
            else
            {
                itemAmountText.text = "";
            }
        }
        else
        {
            itemNameText.text = "";
            itemImage.color = Color.clear;
            itemAmountText.text = "";
        }
    }
}
