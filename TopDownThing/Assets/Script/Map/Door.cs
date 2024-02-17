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
        // Check if the player has collected enough keys
        if (keysCollected >= keysRequired)
        {
            // Check if the door object exists and is active in the scene
            if (doorObject != null && doorObject.activeSelf)
            {
                // Deactivate the door object
                doorObject.SetActive(false);
            }
        }
    }

    public void KeyCollected()
    {
        keysCollected++;
    }
}
