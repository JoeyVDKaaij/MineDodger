using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GraphicsSettingsScript : MonoBehaviour
{
    [Header("UI Elements Settings")]
    [SerializeField, Tooltip("The dropdown setting of the resolution.")]
    private TMP_Dropdown resDropdown;
    [SerializeField, Tooltip("The fullscreen setting.")]
    private Toggle fullScreenToggle;
    
    private Resolution[] allResolutions;
    private bool isFullScreen;
    private int selectedResolution;
    List<Resolution> selectedResolutionList = new List<Resolution>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFullScreen = true;
        allResolutions = Screen.resolutions;
        
        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach (Resolution res in allResolutions)
        {
            newRes = res.width.ToString() + "x" + res.height.ToString();
            if (!resolutionStringList.Contains(newRes))
            {
                resolutionStringList.Add(newRes);
                selectedResolutionList.Add(res);
            }
        }
        
        resDropdown.AddOptions(resolutionStringList);

        if (OptionsManager.instance != null)
        {
            resDropdown.value = selectedResolutionList.IndexOf(OptionsManager.instance.resolution);
        }
    }

    public void ChangeResolution()
    {
        if (OptionsManager.instance != null)
        {
            OptionsManager.instance.ApplyGraphics(selectedResolutionList[selectedResolution], fullScreenToggle.isOn);
        }
        else
        {
            selectedResolution = resDropdown.value;
            Screen.SetResolution(selectedResolutionList[selectedResolution].width, selectedResolutionList[selectedResolution].height, fullScreenToggle.isOn);
        }
    }
}
