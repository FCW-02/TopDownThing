using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManage : MonoBehaviour
{
    public Canvas cutsceneCanvas;
    public float imageDuration = 2f;
    public string levelToLoad = "YourLevelScene";

    private Image[] images;
    private int currentImageIndex = 0;
    private bool isCutsceneFinished = false;

    private void Start()
    {

        images = cutsceneCanvas.GetComponentsInChildren<Image>();

        DisplayNextImage();
    }

    private void DisplayNextImage()
    {

        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }

        images[currentImageIndex].gameObject.SetActive(true);

        currentImageIndex++;

        if (currentImageIndex >= images.Length)
        {
            isCutsceneFinished = true;
            return;
        }

        Invoke("DisplayNextImage", imageDuration);
    }

    private void Update()
    {
        if (isCutsceneFinished)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
