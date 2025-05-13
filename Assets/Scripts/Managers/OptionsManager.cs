using FMOD.Studio;
using UnityEngine;
using FMODUnity;


public class OptionsManager : MonoBehaviour
{
    public static OptionsManager instance;

    public int levelBeaten = 0;

    public int mouseSensitivity = 100;

    public bool fullscreen = true;
    public float mainVolume = 100;
    public float musicVolume = 100;
    public float soundVolume = 100;
    
    
    private Bus masterBus;
    private Bus musicBus;
    private Bus sfxBus;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            masterBus = RuntimeManager.GetBus("bus:/Master Bus");
            musicBus = RuntimeManager.GetBus("bus:/Master/Music");
            sfxBus = RuntimeManager.GetBus("bus:/Master/SFX");
            
            GameData data = SaveSystem.LoadData();
            
            if (data != null)
            {
                levelBeaten = data.levelBeaten;
                mouseSensitivity = data.mouseSensitivity;
                fullscreen = data.fullscreen;
                mainVolume = data.mainVolume;
                musicVolume = data.musicVolume;
                soundVolume = data.soundVolume;

                masterBus.setVolume(mainVolume / 100);
                musicBus.setVolume(mainVolume / 100);
                sfxBus.setVolume(mainVolume / 100);
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

        masterBus.setVolume(mainVolume / 100);
        musicBus.setVolume(mainVolume / 100);
        sfxBus.setVolume(mainVolume / 100);
        
        SaveSystem.SaveData(this);
    }
    
}
