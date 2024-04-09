using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BakingMenuGUI : MonoBehaviour
{
    RecipeBookGUI recipeBookGUI;
    CanvasGroup bakingMenu;

    string currentWorkstation = "oven";

    private void Awake()
    {
        bakingMenu = FindObjectOfType<CanvasGroup>();
        recipeBookGUI = FindObjectOfType<RecipeBookGUI>();
    }

    private void Start()
    {
        HideBakingMenu();
    }

    public void HideBakingMenu()
    {
        bakingMenu.alpha = 0;
        bakingMenu.interactable = false;
        bakingMenu.blocksRaycasts = false;
    }

    public void OpenBakingMenu()
    {
        bakingMenu.alpha = 1;
        bakingMenu.interactable = true;
        bakingMenu.blocksRaycasts = true;

        UpdateWorkstation(currentWorkstation);
    }

    public void UpdateWorkstation(string newWorkStation)
    {
        currentWorkstation = newWorkStation;
        recipeBookGUI.UpdateRecipes(currentWorkstation);
    }


}
