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

    private void Awake()
    {
        itemImage = GetComponentInChildren<Image>();
        itemNameText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if(this.item != null)
        {
            itemNameText.text = item.title;
            itemImage.color = Color.white;
            itemImage.sprite = this.item.sprite;
        }
        else
        {
            itemNameText.text = "";
            itemImage.color = Color.clear;
        }
    }
}
