using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Recipe
{
    public string title;
    public int id;
    public Dictionary<int, int> ingredients;
    public int product;
    public WorkstationType workstation;

    public Recipe(string title, int id, Dictionary<int, int> ingredients, int product, WorkstationType workstation)
    {
        this.title = title;
        this.id = id;
        this.ingredients = ingredients;
        this.product = product;
        this.workstation = workstation;
    }
}
