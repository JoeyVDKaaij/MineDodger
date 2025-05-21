using System;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class SoundManager : MonoBehaviour
{
    #region instance
    
    public static SoundManager instance { get; private set; }

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void OnDisable()
    {
        instance = null;
    }

    private void OnDestroy()
    {
        instance = null;
    }
    
    #endregion

    private VCA vcaControllerMain;
    private VCA vcaControllerMusic;
    private VCA vcaControllerSound;

    private void Start()
    {
        vcaControllerMain = RuntimeManager.GetVCA("vca:/Master");
        vcaControllerMusic = RuntimeManager.GetVCA("vca:/Music");
        vcaControllerSound = RuntimeManager.GetVCA("vca:/SFX");
    }

    public void SetMainVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        vcaControllerMain.setVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        vcaControllerMusic.setVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        vcaControllerSound.setVolume(volume);
    }
}