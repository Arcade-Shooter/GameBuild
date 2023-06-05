using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject settingMenu;
    public GameObject gameOverMenu;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        // this.pauseMenu = GameObject.Find("PauseMenu");
        // this.settingMenu = GameObject.Find("SettingMenu");    
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
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
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void OnGameOver()
    {   //Pause the game
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        GameIsPaused = true;
        SoundEffect.instance.pauseSound();  //Pause the sound
    }

    public void OnPause()
    {   //Pause the game
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        GameIsPaused = true;
        SoundEffect.instance.pauseSound();  //Pause the sound
    }

    public void OnResume()
    {   //Resume the game
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        GameIsPaused = false;
        SoundEffect.instance.unPauseSound();    //Unpause the sound
    }

    public void OnRestart()
    {   //Restart the game
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        GameIsPaused = false;
        SoundEffect.instance.unPauseSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Load the current scene
    }

    public void OpenSettingMenu()
    {
        GameIsPaused = true;
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void CloseSettingMenu()
    {
        GameIsPaused = true;
        settingMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

}
