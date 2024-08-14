using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class WorkStation : MonoBehaviour
{
    BakingMenu bakingMenu;
    PlayerInventory playerInventory;
    ItemDatabase itemDB;

    public WorkstationType workstationType = WorkstationType.Oven;

    private void Awake()
    {
        bakingMenu = FindObjectOfType<BakingMenu>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        itemDB = FindObjectOfType<ItemDatabase>();
    }

    public void OpenBakingGUI()
    {
        bakingMenu.OpenMenu(this);
    }

    public void MakeRecipe(Recipe recipe)
    {
        Dictionary<int, int> ingredients = recipe.ingredients;
        int product = recipe.product;

        playerInventory.RemoveDictionaryItems(ingredients);
        // Start the workstation-specific minigame
        // Opens specific canvas, generic MinigameManager class?
        playerInventory.AddItem(product, 1);

        Debug.Log("One " + itemDB.FindItemById(product) + " coming right up!");

        bakingMenu.HideUI();
    }

}

public enum WorkstationType
{
    Unknown,
    Oven,
    Cauldron,
    MixingBowl
}
