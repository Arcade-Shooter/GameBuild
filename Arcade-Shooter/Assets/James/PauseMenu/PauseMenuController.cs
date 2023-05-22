using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
Overview of PauseMenuController.cs:
    _______________________________________________
    1. --> private int isPaused;

    This variable is very important, it means we dont have to do
    any weird stuff like checking the game speed
    because that would be very bad code practice lol
    _______________________________________________
    2. pauseUI --> [SerializeField] private GameObject pauseUI;
    
    The Pause Menu is hidden by default,
    but we're gonna enable/disable it when we pause/resume
    _______________________________________________
    3. Pause() --> public void Pause()
    
    The Pause() function has 1 job, to pause the game:
    1. When game is resumed, the Pause() function pauses the game and show a pause menu
    2. When the game is resumed, the Pause() function will instead hide the pause menu
    and resume gameplay.
    3. (Maybe fade in the pause menu? Could be nice?)

    
    Made some Pseudocode for reference:

    if the game isPaused (i.e. the timeScale, speed of the game, is stopped (0:1 speed)):
        Resume the game by setting speed to be 1:1

    Else
        Pause the game by setting speed to be 0:1
    _______________________________________________
    4. Exit() --> public void Exit()
    DONT NEED THIS RIGHT NOW CAUSE SCENE-CHANGING WILL COME LATER

    _______________________________________________
    5. update() --> void update()
    Keypress Pausing, it's handled here.
    Any time the user presses the Pause key (ie. ESC)
    the game will pause
*/
public class PauseMenuController : MonoBehaviour
{
    //Variables:
    private int isPaused;
    [SerializeField] private GameObject pauseUI; // The Pause Menu is hidden by default, but we're gonna enable/disable it when we pause/resume

    //Methods PauseResume() and update():
    public void PauseResume()
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

    /**
    if Esc key pressed, the game will pause
    */
    void Update()
    {
        //Debug.Log("UPDATUNBG!!");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc Key Pressed! Game should pause/resume");
            this.PauseResume();
        }
    }
}