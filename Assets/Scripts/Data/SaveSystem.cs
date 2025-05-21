using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveData(OptionsManager options)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Options.dat";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(options);
        
        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/Options.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found in: " + path);
            return null;
        }
    }
}