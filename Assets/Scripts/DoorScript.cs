using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class DoorScript : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int sceneBuildIndex;

    public void WinPuzzle()
    {
        if (sceneBuildIndex >= SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(sceneBuildIndex);
    }
}
