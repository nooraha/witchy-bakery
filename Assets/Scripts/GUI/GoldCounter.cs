using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public TMP_Text counterText;

    public void UpdateGoldCounter(int newAmount)
    {
        counterText.text = newAmount.ToString();
    }
}
