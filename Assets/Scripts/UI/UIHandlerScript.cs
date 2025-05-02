using UnityEngine;
using JoUnityAddOn.SceneManagement;
using JoUnityAddOn.Input;
using UnityEditor;


public class UIHandlerScript : MonoBehaviour
{
    [SerializeField, Tooltip("Set the ui elements that will be disabled when the player does not have the ability to move.")]
    private UnityEngine.UI.Selectable[] uiElementsToDisable;
    
    private void Start()
    {
        Mouse.UnlockMouse();
    }

    public void PlayGame()
    {
        Debug.Log(GameManager.instance != null);
        SceneManager.LoadNextScene();
    }

    public void ActivateScene(int index = 0)
    {
        SceneManager.LoadScene(index);
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
