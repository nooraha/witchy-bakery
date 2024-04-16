using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BakingMenuGUI : UICanvasManager
{
    RecipeBookGUI recipeBookGUI;
    WorkStation currentWorkstation;

    private void Awake()
    {
        recipeBookGUI = FindObjectOfType<RecipeBookGUI>();
        UIcanvas = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        HideUI();
    }

    public void OpenBakingMenu(WorkStation workstation)
    {
        ShowUI();
        UpdateWorkstation(workstation);
    }

    public void UpdateWorkstation(WorkStation newWorkstation)
    {
        currentWorkstation = newWorkstation;
        recipeBookGUI.UpdateRecipes(currentWorkstation);
    }

    
}
