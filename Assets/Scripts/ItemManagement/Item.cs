using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public string title;
    public int id;
    public int rarity;
    public string description;
    public Sprite sprite;
    public List<string> tags;

    public Item(int id, string title, int rarity, string description, List<string> tags, string sprite)
    {
        this.title = title;
        this.id = id;
        this.rarity = rarity;
        this.description = description;
        this.tags = tags;
        this.sprite = Resources.Load<Sprite>("Sprites/Items/" + sprite);
    }

    public override string ToString()
    {
        return title + " / " + id;
    }
}
