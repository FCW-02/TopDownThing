using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI KeyText;
    // Start is called before the first frame update
    void Start()
    {
        KeyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKeyText(Inventory inventory)
    {
        KeyText.text = inventory.NumberCollect.ToString();
    }
}
