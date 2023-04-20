using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoaderV2Button:MonoBehaviour
{
    [SerializeField] private string sceneName = "Scenes/PickYourScene.unity";

    void Start()
    {
        //Debug.Log("the level loader works, should ");
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        LoadScene();
    //    }
    //}

    /**LoadScene() no arguments, uses the sceneName given in the SerializeField value */
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    /**LoadScene(string scene_Name), this is the Button-compatible function, so you can still input a scene value */
    public void LoadScene(string scene_Name)
    {
        SceneManager.LoadScene(scene_Name);
    }
}