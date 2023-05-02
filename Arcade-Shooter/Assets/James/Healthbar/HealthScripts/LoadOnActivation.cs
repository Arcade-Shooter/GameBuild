using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnActivation : MonoBehaviour
{
    [SerializeField] string levelName;
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene(levelName, LoadSceneMode.Additive); //the additive does something special i forgot
        SceneManager.LoadScene(levelName);
    }
}
