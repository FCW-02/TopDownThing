using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab for the arrow
    public Transform firePoint; // Point from where the arrow will be fired
    public float fireRate = 1f; // Rate of fire (arrows per second)
    public float arrowSpeed = 10f; // Speed of the arrow
    public float attackRange = 5f; // Range at which the trap will start firing

    public AudioSource shootSound; // Sound to play when shooting arrow

    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            CheckForPlayer();
        }
    }

    void CheckForPlayer()
    {
        Vector3 direction = firePoint.forward; // Direction in which the trap is facing

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, direction, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                FireArrow();
                nextFireTime = Time.time + 1f / fireRate; // Calculate next fire time
            }
        }
    }

    void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.velocity = firePoint.forward * arrowSpeed;

        // Play the shoot sound
        if (shootSound != null)
        {
            shootSound.Play();
        }
    }
}
