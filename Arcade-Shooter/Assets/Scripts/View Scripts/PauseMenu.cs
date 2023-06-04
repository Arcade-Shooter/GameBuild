using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        //If the player presses the escape key, pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                OnPause();
            }
            else
            {
                OnResume();
            }
        }
    }

    public void OnPause()
    {   //Pause the game
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        ShipSoundEffect.instance.pauseSound();  //Pause the sound
    }

    public void OnResume()
    {   //Resume the game
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ShipSoundEffect.instance.unPauseSound();    //Unpause the sound
    }

    public void OnRestart()
    {   //Restart the game
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        ShipSoundEffect.instance.unPauseSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Load the current scene
    }

}
