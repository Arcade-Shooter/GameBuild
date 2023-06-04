using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // public void SettingMenu()
    // {
    //     Application.LoadLevel("Setting");
    // }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
