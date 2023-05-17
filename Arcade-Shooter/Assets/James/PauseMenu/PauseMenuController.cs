using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField] int scenePause;
    [SerializeField] int sceneResume;
    [SerializeField] int sceneExit;
    private int togglePause;


    public void Pause()
    {
        //SceneManager.LoadScene();
        float scale = Time.timeScale;
        Time.timeScale = scale == 0 ? //is game paused already?
            Time.timeScale = 1 : //yes? resume game (set the speed of time to 100%)
            Time.timeScale = 0; //no? pause game (set the speed of time to 0%)
    }

    public void Exit()
    {

    }
}


//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class MenuScript : MonoBehaviour
//{
//    public void StartGame()
//    {
//        SceneManager.LoadScene(1);
//    }

//    public void ExitGame()
//    {
//        Application.Quit();
//    }
//}
