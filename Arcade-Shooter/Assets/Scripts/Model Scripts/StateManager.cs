using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    private bool GameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingMenu;
    [SerializeField] private GameObject gameOverMenu;

    void Awake() {
        if (instance == null)
        {
            instance = this;
        }

        instance.enabled = true;
        //find the child object of canvas
        // pauseMenu = GameObject.Find("Canvas/PauseMenu");
        // settingMenu = GameObject.Find("Canvas/SettingMenu");
        // gameOverMenu = GameObject.Find("Canvas/GameOverMenu");

       OnPlaying();
    }

    void Start() {
        
        if(this.pauseMenu != null){
            this.pauseMenu.SetActive(false);
        }else{
            Debug.Log("pauseMenu is null");
        }

        if(this.settingMenu != null){
            this.settingMenu.SetActive(false);
        }else{
            Debug.Log("settingMenu is null");
        }

        if(this.gameOverMenu != null){
            this.gameOverMenu.SetActive(false);
        }else{
            Debug.Log("gameOverMenu is null");
        }
        
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {   this.enabled = true;
            //If the player presses the escape key, pause the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    OnPause();
                }
                else
                {
                    OnPlaying();
                }
            }
        }else{
            this.enabled = false;
            Time.timeScale = 1f;
        }
    }
    public bool getState()
    {   //Return the state of the game
        return this.GameIsPaused;
    }
    public void OnPlaying()
    {   //Playing state
        //active the Timer
        Time.timeScale = 1f;
        GameIsPaused = false;
        //Disable the all menus
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        SoundEffect.instance.unPauseSound();   //Unpause the sound
    }
    public void OnGameOver()
    {   //Pause the game
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenu.SetActive(false);
        settingMenu.SetActive(false);
        gameOverMenu.SetActive(true);   //Enable the game over menu
        SoundEffect.instance.pauseSound();
    }
    public void OnPause()
    {   //Pause the game
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenu.SetActive(true);  //Enable the pause menu
        settingMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        SoundEffect.instance.pauseSound(); 
    }
    public void OnRestart(){
        SceneManager.LoadScene(1);
    }
    public void OpenSettingMenu()
    {
        GameIsPaused = true;
        pauseMenu.SetActive(false);
        settingMenu.SetActive(true);    //Enable the setting menu
        gameOverMenu.SetActive(false);
        SoundEffect.instance.pauseSound();
    }

}
