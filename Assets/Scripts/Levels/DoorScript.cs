using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int sceneBuildIndex;

    [SerializeField] private bool nextScene;

    /// <summary>
    /// Win the level (currently set to load the main menu scene)
    /// </summary>
    public void WinPuzzle()
    {
        if (OptionsManager.instance != null)
        {
            OptionsManager.instance.ChangeLevelBeaten(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (nextScene)
        {
            SceneManager.LoadNextScene();
        }
        else
        {
            if (sceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(sceneBuildIndex);
        }
    }
}
