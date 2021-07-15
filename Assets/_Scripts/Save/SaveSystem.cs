using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerScript playerScript)
    {
        //allows us to write data to a file
        BinaryFormatter formatter = new BinaryFormatter();
        
        //path to save file
        string path = Application.persistentDataPath + "/player.game";
        //creates a file (or open a file OpenOrCreate) to save to
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(playerScript);
        //method to write to the file
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.game";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
