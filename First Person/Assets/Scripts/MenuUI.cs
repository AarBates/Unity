using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    //When the play button is pressed, load the game.
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    //When the quit button is pressed, close the application.
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
