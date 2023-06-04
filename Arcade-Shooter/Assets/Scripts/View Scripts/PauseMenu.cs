using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                ShipSoundEffect.instance.pauseSound();
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                ShipSoundEffect.instance.unPauseSound();
            }
        }
    }

}
