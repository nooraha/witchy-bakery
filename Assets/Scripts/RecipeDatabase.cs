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
            { new Recipe("unknown", 0, new Dictionary<int, int>() {  }, 0, new List<string>() {}) },
            { new Recipe("recipe 1", 1, new Dictionary<int, int>() { { 1, 1 } }, 2, new List<string>() { "oven"}) },
            { new Recipe("skillet apple", 2, new Dictionary<int, int>() { { 3, 1 } }, 1, new List<string>() { "skillet"}) },
            { new Recipe("recipe 3", 3, new Dictionary<int, int>() { { 3, 1 } }, 2, new List<string>() { "skillet"}) },
            { new Recipe("oven apple", 4, new Dictionary<int, int>() { { 4, 1 }, {2, 2 } }, 1, new List<string>() { "oven"}) },
            { new Recipe("recipe 5", 5, new Dictionary<int, int>() { { 2, 1 } }, 4, new List<string>() { "oven"}) },
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

    public List<Recipe> FindRecipesByTag(string tag)
    {
        List<Recipe> matches = recipeList.FindAll(recipe => recipe.tags.Contains(tag));
        foreach(Recipe match in matches)
        {
            Debug.Log(match);
        }
        return matches;
    }
}
