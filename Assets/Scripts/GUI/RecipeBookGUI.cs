using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookGUI : MonoBehaviour
{
    List<Recipe> availableRecipes = new List<Recipe>();
    int currentRecipeIndex = 0;

    WorkStation currentWorkstation;

    ItemDatabase itemDB;
    RecipeDatabase recipeDB;
    PlayerInventory playerInventory;

    public TMP_Text recipeName;
    public TMP_Text workstationName;
    public Transform productPanel;
    public Transform ingredientsPanel;
    public Button makeButton;

    ItemSlotUI productItemSlot;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        itemDB = FindObjectOfType<ItemDatabase>();
        recipeDB = FindObjectOfType<RecipeDatabase>();
        playerInventory = FindObjectOfType<PlayerInventory>();

        InstantiateProductPreview();
    }

    public void FlipToPreviousRecipe()
    {
        if (currentRecipeIndex == 0)
        {
            currentRecipeIndex = availableRecipes.Count - 1;
        }
        else
        {
            currentRecipeIndex--;
        }

        UpdateRecipeBook();
    }

    public void FlipToNextRecipe()
    {
        if (currentRecipeIndex == availableRecipes.Count - 1)
        {
            currentRecipeIndex = 0;
        }
        else
        {
            currentRecipeIndex++;
        }

        UpdateRecipeBook();
    }

    public void UpdateRecipes(WorkStation workstation)
    {
        currentWorkstation = workstation;
        WorkstationType workstationType = currentWorkstation.workstationType;
        availableRecipes = recipeDB.FindRecipesByWorkstation(workstationType);
        currentRecipeIndex = 0;
        UpdateRecipeBook();
    }

    public void UpdateRecipeBook()
    {
        Recipe currentRecipe = GetCurrentRecipe();

        string title = currentRecipe.title;
        int product = currentRecipe.product;
        Dictionary<int, int> ingredients = currentRecipe.ingredients;

        workstationName.text = currentWorkstation.ToString();
        recipeName.text = title;

        // Find the item matching the product's id and update the product slot to show its info
        Item productItem = itemDB.FindItemById(product);
        productItemSlot.UpdateItem(productItem);

        ResetIngredientsPanel();

        // Update panel with new ingredients
        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            int itemAmount = playerInventory.FindAmountOfItem(pair.Key);
            int requiredAmount = pair.Value;
            GameObject ingrInstance = Instantiate(itemSlotPrefab, ingredientsPanel);
            Item ingrItem = itemDB.FindItemById(pair.Key);
            ingrInstance.GetComponent<ItemSlotUI>().UpdateItem(ingrItem, itemAmount, requiredAmount);
        }

        EnableOrDisableMakeButton();
    }

    private void ResetIngredientsPanel()
    {
        // Remove all ingredients in ingredient panel (left over from previous recipe)
        while (ingredientsPanel.childCount > 0)
        {
            DestroyImmediate(ingredientsPanel.GetChild(0).gameObject);
        }
    }

    private void InstantiateProductPreview()
    {
        // Instantiate a new item slot in the product panel
        GameObject productInstance = Instantiate(itemSlotPrefab, productPanel);
        productItemSlot = productInstance.GetComponent<ItemSlotUI>();
    }

    private void EnableOrDisableMakeButton()
    {
        if (playerInventory.InventoryContainsItems(GetCurrentRecipe().ingredients))
        {
            makeButton.interactable = true;
        }
        else
        {
            makeButton.interactable = false;
        }
    }

    public Recipe GetCurrentRecipe()
    {
        return availableRecipes[currentRecipeIndex];
    }

    public void MakeCurrentRecipe()
    {
        currentWorkstation.MakeRecipe(GetCurrentRecipe());
    }

    
}
