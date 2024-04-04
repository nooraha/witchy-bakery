using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkStation : Inventory
{
    BakingMenuGUI bakingMenuGUI;

    private void Awake()
    {
        bakingMenuGUI = FindObjectOfType<BakingMenuGUI>();
    }

    public void OpenIngredienSelectionGUI()
    {
        Debug.Log("Opening ingredient selection GUI");
        bakingMenuGUI.OpenBakingMenu();
    }
}
