using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int sceneBuildIndex;

    /// <summary>
    /// Win the level (currently set to load the main menu scene)
    /// </summary>
    public void WinPuzzle()
    {
        if (sceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(sceneBuildIndex);
    }
}
