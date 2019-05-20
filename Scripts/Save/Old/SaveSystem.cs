using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {
    /*
    public static void SaveEssence(EssenceHolder essenceHolder)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/essence.tar";
        FileStream stream = new FileStream(path, FileMode.Create);

        EssenceData data = new EssenceData(essenceHolder);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static EssenceData LoadEssence()
    {
        string path = Application.persistentDataPath + "/essence.tar";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            EssenceData data = formatter.Deserialize(stream) as EssenceData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Loadfail, empty");
            return null;
        }
    }
    */
}
