using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //In Start Menu state
    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettingMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void OnAboutUS()
    {
        SceneManager.LoadScene(3);
    }

    public void OnQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnBack()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //In Playing state

    public void OnRestart()
    {
        StateManager.instance.OnPlaying();
        SceneManager.LoadScene(1);
    }

    public void OnGoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnGoSetting()
    {
        StateManager.instance.OpenSettingMenu();
    }

    public void OnGoResume()
    {
        StateManager.instance.OnPlaying();
    }

    public void OnGoPauseMenu()
    {
        StateManager.instance.OnPause();
    }

}
