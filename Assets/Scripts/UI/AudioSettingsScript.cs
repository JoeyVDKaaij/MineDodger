using System;
using UnityEngine;
using UnityEngine.UI;
using FMOD.Studio;
using FMODUnity;

public class AudioSettingsScript : MonoBehaviour
{
    [Header("UI Elements Settings")]
    [SerializeField, Tooltip("The slider changing the main volume.")]
    private Slider mainVolumeSlider = null;
    [SerializeField, Tooltip("The slider changing the music volume.")]
    private Slider musicVolumeSlider = null;
    [SerializeField, Tooltip("The slider changing the SFX volume.")]
    private Slider sfxVolumeSlider = null;
    
    private VCA vcaControllerMain;
    private VCA vcaControllerMusic;
    private VCA vcaControllerSound;

    private void Awake()
    {
        vcaControllerMain = RuntimeManager.GetVCA("vca:/Master");
        vcaControllerMusic = RuntimeManager.GetVCA("vca:/Music");
        vcaControllerSound = RuntimeManager.GetVCA("vca:/SFX");
    }

    public void ChangeVolume(int intType)
    {
        VolumeType type = (VolumeType)intType;
        
        if (OptionsManager.instance != null)
        {
            switch (type)
            {
                case VolumeType.Main:
                    if (mainVolumeSlider != null)
                        OptionsManager.instance.ApplyVolume(mainVolumeSlider.value, type);
                    break;
                case VolumeType.Music:
                    if (musicVolumeSlider != null)
                        OptionsManager.instance.ApplyVolume(musicVolumeSlider.value, type);
                    break;
                case VolumeType.SFX:
                    if (sfxVolumeSlider != null)
                        OptionsManager.instance.ApplyVolume(sfxVolumeSlider.value, type);
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case VolumeType.Main:
                    if (mainVolumeSlider != null)
                        vcaControllerMain.setVolume(mainVolumeSlider.value / 100);
                    break;
                case VolumeType.Music:
                    if (musicVolumeSlider != null)
                        vcaControllerMusic.setVolume(musicVolumeSlider.value / 100);
                    break;
                case VolumeType.SFX:
                    if (sfxVolumeSlider != null)
                        vcaControllerSound.setVolume(sfxVolumeSlider.value / 100);
                    break;
            }
        }
    }
}
