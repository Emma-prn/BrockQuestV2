using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transition transition;

    public void OnPlayButton()
    {
        transition.LoadLevel("House");
    }

    public void OnCreditsButton()
    {
        transition.LoadLevel("Credits");
    }

    public void OnBackButton()
    {
        transition.LoadLevel("Main_menu");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
