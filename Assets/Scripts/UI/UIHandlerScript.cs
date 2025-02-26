using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class UIHandlerScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadPreviousScene();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
