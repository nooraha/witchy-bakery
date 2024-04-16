using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour
{
    private List<Recipe> recipeList;

    private void Start()
    {
        BuildRecipeDatabase();
    }

    public void BuildRecipeDatabase()
    {
        recipeList = new List<Recipe>
        {
            { new Recipe("unknown", 0, new Dictionary<int, int>() {  }, 0, WorkstationType.Unknown) },
            { new Recipe("recipe 1", 1, new Dictionary<int, int>() { { 1, 1 } }, 2, WorkstationType.Oven) },
            { new Recipe("skillet apple", 2, new Dictionary<int, int>() { { 3, 1 } }, 1, WorkstationType.Cauldron) },
            { new Recipe("recipe 3", 3, new Dictionary<int, int>() { { 3, 1 } }, 2, WorkstationType.Cauldron) },
            { new Recipe("oven apple", 4, new Dictionary<int, int>() { { 4, 1 }, {2, 2 } }, 1, WorkstationType.Oven) },
            { new Recipe("recipe 5", 5, new Dictionary<int, int>() { { 2, 1 } }, 4, WorkstationType.MixingBowl) },
        };
    }

    public Recipe FindRecipeById(int recipeId)
    {
        Recipe item = recipeList.Find(i => i.id == recipeId);
        if (item != null)
        {
            return item;
        }
        else
        {
            Debug.Log("Recipe with id " + recipeId + " doesn't exist!");
            return recipeList.Find(i => i.id == 0);
        }
    }

    public List<Recipe> FindRecipesByWorkstation(WorkstationType type)
    {
        List<Recipe> matches = recipeList.FindAll(recipe => recipe.workstation == type);
        return matches;
    }
}
