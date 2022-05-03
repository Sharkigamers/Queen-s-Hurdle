using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveMenu : MonoBehaviour
{
    public static void SaveIslandGameData(IslandGameData islandGameData) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = string.Format(
            "{0}/island{1}.localSave",
            Application.persistentDataPath, islandGameData.indexIsland.ToString()
        );
        FileStream stream = new FileStream(path, FileMode.Create);

        IslandGameData newIslandGameData = new IslandGameData(islandGameData);

        formatter.Serialize(stream, newIslandGameData);
        stream.Close();
    }

    public static IslandGameData LoadIslandGameData(IslandGameData islandGameData) {
        string path = string.Format(
            "{0}/island{1}.localSave",
            Application.persistentDataPath, islandGameData.indexIsland.ToString()
        );
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            IslandGameData newIslandGameData = formatter.Deserialize(stream) as IslandGameData;
            stream.Close();

            return newIslandGameData;
        } else
            return null;
    }
}
