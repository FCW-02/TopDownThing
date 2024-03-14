using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPause : MonoBehaviour
{
    public GameObject EndMenu;

    private void Update()
    {

    }

    public void Pause()
    {
        EndMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        EndMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            Pause();
        }
    }
}