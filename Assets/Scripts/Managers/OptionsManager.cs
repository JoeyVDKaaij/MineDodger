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
                fullscreen = data.fullscreen;
                resolution = data.resolution.ToUnityResolution();
                mainVolume = data.mainVolume;
                musicVolume = data.musicVolume;
                soundVolume = data.soundVolume;

                vcaControllerMain.setVolume(mainVolume / 100);
                vcaControllerMusic.setVolume(mainVolume / 100);
                vcaControllerSound.setVolume(mainVolume / 100);
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

    public void ApplySettings()
    {
        Screen.fullScreen = fullscreen;

        vcaControllerMain.setVolume(mainVolume / 100);
        vcaControllerMusic.setVolume(mainVolume / 100);
        vcaControllerSound.setVolume(mainVolume / 100);
        
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
