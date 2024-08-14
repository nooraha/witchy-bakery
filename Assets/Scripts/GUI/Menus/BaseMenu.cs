using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseMenu : MonoBehaviour
{
    protected CanvasGroup UIcanvas;

    private GameStateManager gameStateManager;

    protected virtual void Awake()
    {
        UIcanvas = GetComponent<CanvasGroup>();
        gameStateManager = FindObjectOfType<GameStateManager>();
    }

    public void HideUI()
    {
        UIcanvas.alpha = 0;
        UIcanvas.interactable = false;
        UIcanvas.blocksRaycasts = false;
    }

    public void ShowUI()
    {
        UIcanvas.alpha = 1;
        UIcanvas.interactable = true;
        UIcanvas.blocksRaycasts = true;
        
    }

    public virtual void OpenMenu()
    {
        ShowUI();
        gameStateManager.setState(GameState.Menu);
    }

    public virtual void CloseMenu()
    {
        HideUI();
        gameStateManager.setState(GameState.Playing);
    }
}
