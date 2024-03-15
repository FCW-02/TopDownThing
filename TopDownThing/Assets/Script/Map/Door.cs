using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int keysRequired = 3;
    private int keysCollected = 0;

    public GameObject doorObject;
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            Interact();
        }
    }

    void Interact()
    {
        if (keysCollected >= keysRequired)
        {
            if (doorObject != null && doorObject.activeSelf)
            {
                doorObject.SetActive(false);
            }
        }
    }

    public void KeyCollected()
    {
        keysCollected++;
    }
}
