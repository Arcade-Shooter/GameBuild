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

    public void StartMenu(){
        PauseMenu.instance.OnRestart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnResume()
    {
        PauseMenu.instance.OnResume();
    } 

    public void OpenSettingMenu()
    {
        PauseMenu.instance.OpenSettingMenu();
    }

    public void CloseSettingMenu(){
        PauseMenu.instance.CloseSettingMenu();
    }

}
