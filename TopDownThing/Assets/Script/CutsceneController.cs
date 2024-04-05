using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public GameObject player; // Reference to the player GameObject
    public float cutsceneDuration = 6f; // Duration of the cutscene in seconds

    private PlayerController playerController; // Reference to the PlayerController script
    private bool cutsceneActive = false;
    private float cutsceneTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Disable the main camera at the beginning
        mainCamera.enabled = false;
        // Enable the cutscene camera
        cutsceneCamera.enabled = true;
        cutsceneActive = true;

        // Get the PlayerController component from the player GameObject
        playerController = player.GetComponent<PlayerController>();

        // Disable player movement during the cutscene
        if (playerController != null)
        {
            playerController.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the cutscene is active
        if (cutsceneActive)
        {
            // Increment the timer
            cutsceneTimer += Time.deltaTime;

            // Check if the cutscene duration has elapsed
            if (cutsceneTimer >= cutsceneDuration)
            {
                // Switch back to the main camera
                mainCamera.enabled = true;
                cutsceneCamera.enabled = false;
                cutsceneActive = false;

                // Re-enable player movement after the cutscene
                if (playerController != null)
                {
                    playerController.enabled = true;
                }
            }
        }
    }
}
