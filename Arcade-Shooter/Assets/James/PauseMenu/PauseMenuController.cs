using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    /**
    We have a boolean, isPaused. This means we dont have to do
    any weird stuff checking the game speed, like in the previous version. 
    */
    private int isPaused;
    [SerializeField] private GameObject pauseUI; // The Pause Menu is hidden by default, but we're gonna enable/disable it when we pause/resume

    /** the Pause() function has 1 job, to pause the game:
    1. When game is resumed, the Pause() function pauses the game and show a pause menu
    2. When the game is resumed, the Pause() function will instead hide the pause menu
    and resume gameplay.
    3. (Maybe fade in the pause menu? Could be nice?)

    

    if the game isPaused (i.e. the timeScale, speed of the game, is stopped (0:1 speed)):
        Resume the game by setting speed to be 1:1

    Else
        Pause the game by setting speed to be 0:1
    */
    public void Pause()
    {
        float scale = Time.timeScale;
        //1. When resumed,
        if(scale == 0)
        {
            //a.  -   pause the game
            Time.timeScale = 1;
            //b.  -   show a pause menu
            pauseUI.SetActive(false);
        }

        //2. When paused:
        else //     (if scale == 1 or any other ridiculous number, means we arent paused)
        {
            //a.  -   resume game
            Time.timeScale = 0;
            //b.  -   hide the pause menu
            pauseUI.SetActive(true);

        }
    }

    public void Exit()
    {

    }
}