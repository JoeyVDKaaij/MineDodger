using System;
using UnityEngine;

public class PauseMenuEnablerScript : MonoBehaviour
{
    [Header("Pauze Menu Settings")]
    [SerializeField, Tooltip("Pauze Menu Object")] 
    private GameObject pauseMenu = null;

    private void Update()
    {
        if (pauseMenu != null && Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeSelf)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.gameplayType = GameplayTypes.Paused;
            }
            pauseMenu.SetActive(true);
        }
    }
}
