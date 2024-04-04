using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BakingMenuGUI : MonoBehaviour
{
    CanvasGroup bakingMenu;

    private void Awake()
    {
        bakingMenu = FindObjectOfType<CanvasGroup>();
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
    }
}
