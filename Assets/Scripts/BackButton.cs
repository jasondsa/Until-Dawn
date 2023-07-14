using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public GameObject MainMenu;
    public void OnBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
