using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemSlotUI : MonoBehaviour
{
    public Item item;

    private TMP_Text itemNameText;
    private Image itemImage;
    private TMP_Text itemAmountText;

    private void Awake()
    {
        itemImage = GetComponentInChildren<Image>();
        itemNameText = transform.Find("ItemName").GetComponent<TMP_Text>();
        itemAmountText = transform.Find("ItemAmount").GetComponent<TMP_Text>();
    }

    public void UpdateItem(Item item, int amount = 1)
    {
        this.item = item;
        if(this.item != null)
        {
            itemNameText.text = item.title;
            itemImage.color = Color.white;
            itemImage.sprite = this.item.sprite;
            itemAmountText.text = amount.ToString();
        }
        else
        {
            itemNameText.text = "";
            itemImage.color = Color.clear;
            itemAmountText.text = "";
        }
    }
}
