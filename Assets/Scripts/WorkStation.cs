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

    public void MakeRecipe(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.ingredients;
        int product = recipe.product;

        playerInventory.RemoveDictionaryItems(ingredients);
        // Start the workstation-specific minigame
        playerInventory.AddItem(product, 1);

        Debug.Log("One " + itemDB.FindItemById(product) + " coming right up!");

        bakingMenuGUI.HideUI();
    }

}

public enum WorkstationType
{
    Unknown,
    Oven,
    Cauldron,
    MixingBowl
}
