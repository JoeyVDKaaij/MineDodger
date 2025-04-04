using UnityEngine;
using JoUnityAddOn.SceneManagement;
using JoUnityAddOn.Input;
using UnityEditor;


public class UIHandlerScript : MonoBehaviour
{
    private void Start()
    {
        Mouse.UnlockMouse();
    }

    public void PlayGame()
    {
        Debug.Log(GameManager.instance != null);
        SceneManager.LoadNextScene();
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
