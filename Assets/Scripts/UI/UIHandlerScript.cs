using System.Collections;
using UnityEngine;
using JoUnityAddOn.SceneManagement;
using JoUnityAddOn.Input;
using UnityEditor;


public class UIHandlerScript : MonoBehaviour
{
    [SerializeField, Tooltip("Set the ui elements that will be disabled when the player does not have the ability to move.")]
    private UnityEngine.UI.Selectable[] uiElementsToDisable;
    
    [SerializeField, Tooltip("Set the camera Animator")]
    private Animator cameraAnimator;
    [SerializeField, Tooltip("ToggleUI")]
    private GameObject mainMenu = null;
    [SerializeField, Tooltip("ToggleUI")]
    private GameObject levelSelect = null;
    
    private void Start()
    {
        Mouse.UnlockMouse();
    }

    public void PlayGame()
    {
        Debug.Log(GameManager.instance != null);
        SceneManager.LoadNextScene();
    }

    public void LoadSceneByIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    
    public void EnableCameraAnimation()
    {
        if (cameraAnimator != null)
        {
            cameraAnimator.SetTrigger("Move");
            StartCoroutine(DelayedToggleUI());
        }
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


    IEnumerator DelayedToggleUI()
    {
        yield return new WaitForSeconds(0.5f);
        
        if (mainMenu != null && levelSelect != null)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            levelSelect.SetActive(!levelSelect.activeSelf);
        }
    }
}
