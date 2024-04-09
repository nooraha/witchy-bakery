using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RecipeBookGUI : MonoBehaviour
{
    List<Recipe> availableRecipes = new List<Recipe>();
    int currentRecipeIndex = 0;

    string currentWorkstation;

    ItemDatabase itemDB;
    RecipeDatabase recipeDB;

    public TMP_Text recipeName;
    public TMP_Text workstationName;
    public Transform productPanel;
    public Transform ingredientsPanel;

    ItemSlotUI productItemSlot;

    public GameObject itemSlotPrefab;

    private void Awake()
    {
        itemDB = FindObjectOfType<ItemDatabase>();
        recipeDB = FindObjectOfType<RecipeDatabase>();

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

    public void UpdateRecipes(string workstation)
    {
        currentWorkstation = workstation;
        availableRecipes = recipeDB.FindRecipesByTag(currentWorkstation);
        currentRecipeIndex = 0;
        UpdateRecipeBook();
    }

    public void UpdateRecipeBook()
    {
        Recipe currentRecipe = availableRecipes[currentRecipeIndex];

        string title = currentRecipe.title;
        int product = currentRecipe.product;
        Dictionary<int, int> ingredients = currentRecipe.ingredients;

        workstationName.text = currentWorkstation;
        recipeName.text = title;

        // Find the item matching the product's id and update the product slot to show its info
        Item productItem = itemDB.FindItemById(product);
        productItemSlot.UpdateItem(productItem);

        while(ingredientsPanel.childCount > 0)
        {
            DestroyImmediate(ingredientsPanel.GetChild(0).gameObject);
        }

        foreach (KeyValuePair<int, int> pair in ingredients)
        {
            //Debug.Log("recipe requires " + pair.Value.ToString() + " of " + pair.Key.ToString());
            GameObject ingrInstance = Instantiate(itemSlotPrefab, ingredientsPanel);
            Item ingrItem = itemDB.FindItemById(pair.Key);
            ingrInstance.GetComponent<ItemSlotUI>().UpdateItem(ingrItem);
        }

    }

    private void InstantiateProductPreview()
    {
        // Instantiate a new item slot in the product panel
        GameObject productInstance = Instantiate(itemSlotPrefab, productPanel);
        productItemSlot = productInstance.GetComponent<ItemSlotUI>();
    }
}
