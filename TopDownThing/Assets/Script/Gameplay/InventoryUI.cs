using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI KeyText;

    void Start()
    {
        KeyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKeyText(Inventory inventory)
    {
        KeyText.text = inventory.NumberCollect.ToString();
    }
}
