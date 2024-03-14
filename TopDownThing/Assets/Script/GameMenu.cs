using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void start()
    {
        SceneManager.LoadScene("Level1");
    }

    public void quit2()
    {
        Application.Quit();
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
