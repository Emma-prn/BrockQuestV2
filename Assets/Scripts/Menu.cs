using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("House");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnBackButton()
    {
        SceneManager.LoadScene("Main_menu");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
