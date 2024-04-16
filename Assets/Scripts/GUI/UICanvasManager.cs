using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    protected CanvasGroup UIcanvas;

    private void Awake()
    {
        UIcanvas = GetComponent<CanvasGroup>();
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
}
