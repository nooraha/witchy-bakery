using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BakingMenu : BaseMenu
{
    RecipeBookGUI recipeBookGUI;
    WorkStation currentWorkstation;

    protected override void Awake()
    {
        base.Awake();
        recipeBookGUI = FindObjectOfType<RecipeBookGUI>();
    }

    private void Start()
    {
        HideUI();
    }

    public void OpenMenu(WorkStation workstation)
    {
        OpenMenu();
        UpdateWorkstation(workstation);
    }

    public void UpdateWorkstation(WorkStation newWorkstation)
    {
        currentWorkstation = newWorkstation;
        recipeBookGUI.UpdateRecipes(currentWorkstation);
    }

    
}
