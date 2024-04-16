using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnscreenUI : UICanvasManager
{
    private void Awake()
    {
        UIcanvas = GetComponent<CanvasGroup>();
    }
}
