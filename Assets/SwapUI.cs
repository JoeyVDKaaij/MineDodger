using System;
using UnityEngine;

public class SwapUI : MonoBehaviour
{
    [Header("UI Settings")] 
    [SerializeField, Tooltip("ToggleUI")]
    private bool toggleUI = false;
    [SerializeField, Tooltip("ToggleUI")]
    private GameObject mainMenu = null;
    [SerializeField, Tooltip("ToggleUI")]
    private GameObject levelSelect = null;

    private void Update()
    {
        if (toggleUI)
        {
            ToggleUI();
            toggleUI = false;
        }
    }

    private void ToggleUI()
    {
        if (mainMenu != null && levelSelect != null)
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
            levelSelect.SetActive(!levelSelect.activeSelf);
        }
    }
}
