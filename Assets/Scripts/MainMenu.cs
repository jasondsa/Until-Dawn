using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void OnPlayButton()
    {
        SceneManager.LoadScene("Until Dawn");
    }

    public void OnInstructionsButton()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void OnHighScoreButton()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
