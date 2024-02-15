using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Recipe
{
    public string title;
    public int id;
    public Dictionary<Item, int> ingredients;
    public Dictionary<Item, int> products;
    public WorkStation workStation;

    public Recipe(string title, int id, Dictionary<Item, int> ingredients, Dictionary<Item, int> products, WorkStation workStation)
    {
        this.title = title;
        this.id = id;
        this.ingredients = ingredients;
        this.products = products;
        this.workStation = workStation;
    }
}

public class RecipesList : MonoBehaviour
{
    public List<Recipe> availableRecipes;
    public Inventory inventory;

    public bool AbleToMakeRecipe(Recipe recipe)
    {
        foreach(KeyValuePair<Item, int> ingredient in recipe.ingredients)
        {
            if(inventory.FindAmountOfItem(ingredient.Key) < ingredient.Value)
            {
                return false;
            }
        }
        return true;
    }
}
