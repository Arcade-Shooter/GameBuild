using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(1); //Hard Coded for the scene
    }

    public void OpenSettings()
    {

    }

    public void OpenScoreboard()
    {

    }

    public void exit()
    {
        Application.Quit();
    }
}
