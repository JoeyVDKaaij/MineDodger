using UnityEngine;
using UnityEngine.UI;

public class GameplaySettingsScript : MonoBehaviour
{
    [Header("UI Elements Settings")]
    [SerializeField, Tooltip("The slider changing the mouse sensitivity.")]
    private Slider mouseSensitivitySlider = null;

    public void ChangeMouseSensitivity()
    {
        if (OptionsManager.instance != null)
        {
            OptionsManager.instance.mouseSensitivity = (int)mouseSensitivitySlider.value;
        }
    }
}
