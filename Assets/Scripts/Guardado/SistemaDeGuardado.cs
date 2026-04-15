using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public static class SistemaDeGuardado
{
    public static void Guardar()
    {
        string path = Application.dataPath + "/player.save";
        //string cosa = Application.persistentDataPath + "/player.save";
        //string cosa = System.Environment/*.GetFolderPath*/.SpecialFolder.Desktop + "/player.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        BinaryFormatter formatter = new BinaryFormatter();

        formatter.Serialize(stream, data);

        stream.Close(); 
    }  
    public static PlayerData Cargar()
    {
        string path = Application.dataPath + "/player.save";

        if(File.Exists(path)) 
        {
            FileStream stream = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            PlayerData data = formatter.Deserialize(stream)as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("No hay que cargar");
            return null;
        }
        
    }
}
