using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int NumberCollect { get; private set; }

    public UnityEvent<Inventory> OnKeyCollect;

    public void ItemCollect()
    {
        NumberCollect++;
        OnKeyCollect.Invoke(this);
    }
}
