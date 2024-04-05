using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public GameObject player;
    public Canvas uiCanvas; // Reference to the UI Canvas
    public float cutsceneDuration = 6f;

    private PlayerController playerController;
    private bool cutsceneActive = false;
    private float cutsceneTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = false;
        cutsceneCamera.enabled = true;
        cutsceneActive = true;

        playerController = player.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.enabled = false;
        }

        if (uiCanvas != null)
        {
            uiCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneActive)
        {
            cutsceneTimer += Time.deltaTime;

            if (cutsceneTimer >= cutsceneDuration)
            {

                mainCamera.enabled = true;
                cutsceneCamera.enabled = false;
                cutsceneActive = false;

                if (playerController != null)
                {
                    playerController.enabled = true;
                }

                if (uiCanvas != null)
                {
                    uiCanvas.enabled = true;
                }
            }
        }
    }
}
