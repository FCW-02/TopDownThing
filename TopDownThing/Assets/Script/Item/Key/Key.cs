using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory != null)
        {
            inventory.ItemCollect();
            gameObject.SetActive(false);

            // Notify the door that a key has been collected
            GameObject doorObject = GameObject.FindGameObjectWithTag("Door");
            if (doorObject != null)
            {
                Door door = doorObject.GetComponent<Door>();
                if (door != null)
                {
                    door.KeyCollected();
                }
            }
        }
    }
}
