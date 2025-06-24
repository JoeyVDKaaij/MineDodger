using FMOD.Studio;
using UnityEngine;
using FMODUnity;


public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;

    public int levelBeaten = 0;

    public int mouseSensitivity = 100;

    public bool fullscreen = true;
    public Resolution resolution;
    
    public float mainVolume = 100;
    public float musicVolume = 100;
    public float soundVolume = 100;
    
    private VCA vcaControllerMain;
    private VCA vcaControllerMusic;
    private VCA vcaControllerSound;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            vcaControllerMain = RuntimeManager.GetVCA("vca:/Master");
            vcaControllerMusic = RuntimeManager.GetVCA("vca:/Music");
            vcaControllerSound = RuntimeManager.GetVCA("vca:/SFX");
            
            GameData data = SaveSystem.LoadData();
            
            if (data != null)
            {
                levelBeaten = data.levelBeaten;
                mouseSensitivity = data.mouseSensitivity;
                
                ApplyGraphics(data.resolution.ToUnityResolution(), data.fullscreen);
                
                ApplyVolume(data.mainVolume, VolumeType.Main);
                ApplyVolume(data.musicVolume, VolumeType.Music);
                ApplyVolume(data.soundVolume, VolumeType.SFX);
            }
            else
            {
                resolution = Screen.currentResolution;
                
                SaveSystem.SaveData(this);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyAllSettings(int pMouseSensitivity, Resolution pResolution, bool pFullscreenfloat, float pMainVolume, float pMusicVolume, float pSoundVolume)
    {
        mouseSensitivity = pMouseSensitivity;
        
        ApplyGraphics(pResolution, pFullscreenfloat);
        
        ApplyVolume(pMainVolume, VolumeType.Main);
        ApplyVolume(pMusicVolume, VolumeType.Music);
        ApplyVolume(pSoundVolume, VolumeType.SFX);
        
        SaveSystem.SaveData(this);
    }

    public void ApplyVolume(float volume, VolumeType volumeType)
    {
        switch (volumeType)
        {
            case VolumeType.Main:
                mainVolume = volume;
                vcaControllerMain.setVolume(mainVolume / 100);
                break;
            case VolumeType.Music:
                musicVolume = volume;
                vcaControllerMusic.setVolume(musicVolume / 100);
                break;
            case VolumeType.SFX:
                soundVolume = volume;
                vcaControllerSound.setVolume(soundVolume / 100);
                break;
        }
    }

    public void ApplyGraphics(Resolution pResolution, bool pFullscreen)
    {
        fullscreen = pFullscreen;
        resolution = pResolution;
        Screen.SetResolution(resolution.width, resolution.height, fullscreen);
    }

    public void SaveSettings()
    {
        SaveSystem.SaveData(this);
    }

    public void ChangeLevelBeaten(int level)
    {
        if (level > levelBeaten)
        {
            levelBeaten = level;
            SaveSettings();
        }
    }
}
