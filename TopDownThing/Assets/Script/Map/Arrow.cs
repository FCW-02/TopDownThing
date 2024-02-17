using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float arrowSpeed = 10f; // Speed of the arrow
    public float lifetime = 2f; // Lifetime of the arrow in seconds

    void Start()
    {
        // Destroy the arrow after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the arrow forward
        transform.Translate(Vector3.forward * arrowSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the arrow hits the player
        if (other.CompareTag("Player"))
        {
            // Destroy the player upon contact
            Destroy(other.gameObject);

            // Destroy the arrow upon hitting the player
            Destroy(gameObject);
        }
    }
}
