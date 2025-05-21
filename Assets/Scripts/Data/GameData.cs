
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int levelBeaten = 0;

    public int mouseSensitivity = 100;

    public bool fullscreen = true;
    public SerializableResolution resolution;
    public int mainVolume = 100;
    public int musicVolume = 100;
    public int soundVolume = 100;

    public GameData(OptionsManager options)
    {
        this.levelBeaten = options.levelBeaten;
        this.mouseSensitivity = options.mouseSensitivity;
        this.fullscreen = options.fullscreen;
        this.resolution = new SerializableResolution(options.resolution);
        this.mainVolume = (int)options.mainVolume;
        this.musicVolume = (int)options.musicVolume;
        this.soundVolume = (int)options.soundVolume;
    }
}
