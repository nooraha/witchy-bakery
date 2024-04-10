using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WorkStation : MonoBehaviour
{
    BakingMenuGUI bakingMenuGUI;
    PlayerInventory playerInventory;
    ItemDatabase itemDB;

    public WorkstationType workstationType = WorkstationType.Oven;

    private void Awake()
    {
        bakingMenuGUI = FindObjectOfType<BakingMenuGUI>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    public void OpenBakingGUI()
    {
        bakingMenuGUI.OpenBakingMenu(this);
    }

    public bool PlayerHasRequiredIngredients(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.ingredients;
        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            if (playerInventory.FindAmountOfItem(pair.Key) < pair.Value)
            {
                return false;
            }
        }
        return true;
    }

    public void MakeRecipe(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.ingredients;
        int product = recipe.product;

        TakeIngredients(ingredients);
        // Start the workstation-specific minigame
        GiveProduct(product);

        Debug.Log("One " + itemDB.FindItemById(product) + " coming right up!");

        bakingMenuGUI.HideBakingMenu();
    }

    private void TakeIngredients(Dictionary<int, int> ingredients)
    {
        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            playerInventory.RemoveItem(pair.Key, pair.Value);
        }
    }

    private void GiveProduct(int product)
    {
        playerInventory.AddItem(product, 1);
    }
}

public enum WorkstationType
{
    Unknown,
    Oven,
    Cauldron,
    MixingBowl
}
