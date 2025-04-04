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

    private VCA _mainVolumeVCA;
    private Bus _musicBus;
    private Bus _sFXBus;

    private void Start()
    {
        _mainVolumeVCA = RuntimeManager.GetVCA("vca:/Main Volume");
        _musicBus = RuntimeManager.GetBus("bus:/Music");
        _sFXBus = RuntimeManager.GetBus("bus:/SFX");
    }

    public void SetMainVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        _mainVolumeVCA.setVolume(volume);
    }

    public void SetMusicVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        _musicBus.setVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        Math.Clamp(volume, 0.0f, 1.0f);
        _sFXBus.setVolume(volume);
    }
}