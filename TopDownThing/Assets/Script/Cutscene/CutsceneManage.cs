using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManage : MonoBehaviour
{
    public Canvas cutsceneCanvas; // Reference to the Canvas containing your cutscene
    public float imageDuration = 2f; // Duration each image should be displayed in seconds
    public string levelToLoad = "YourLevelScene"; // Name of the level scene to load after the cutscene

    private Image[] images; // Array to hold references to all images in the cutscene
    private int currentImageIndex = 0; // Index of the current image being displayed
    private bool isCutsceneFinished = false; // Flag to track whether the cutscene has finished

    private void Start()
    {
        // Get all Image components under the cutscene Canvas
        images = cutsceneCanvas.GetComponentsInChildren<Image>();

        // Start displaying images sequentially
        DisplayNextImage();
    }

    private void DisplayNextImage()
    {
        // Disable all images
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        // Enable the next image in the sequence
        images[currentImageIndex].gameObject.SetActive(true);

        // Move to the next image index
        currentImageIndex++;

        // If all images have been displayed, indicate that the cutscene has finished
        if (currentImageIndex >= images.Length)
        {
            isCutsceneFinished = true;
            return;
        }

        // Schedule the next image to be displayed after the specified duration
        Invoke("DisplayNextImage", imageDuration);
    }

    private void Update()
    {
        // Check if the cutscene has finished
        if (isCutsceneFinished)
        {
            // Load the level scene
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
