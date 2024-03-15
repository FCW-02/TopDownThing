using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float arrowSpeed = 10f;
    public float attackRange = 5f;

    public AudioSource shootSound;

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
        Vector3 direction = firePoint.forward;

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, direction, out hit, attackRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                FireArrow();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void FireArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody arrowRB = arrow.GetComponent<Rigidbody>();
        arrowRB.velocity = firePoint.forward * arrowSpeed;

        if (shootSound != null)
        {
            shootSound.Play();
        }
    }
}
