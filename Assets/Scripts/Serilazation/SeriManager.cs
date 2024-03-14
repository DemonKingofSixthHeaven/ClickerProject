using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;




public class SeriManager : MonoBehaviour
{
    public static bool Save(string SaveName,object SaveData)
        
    {
        BinaryFormatter formatter = getBinaryFormatter();
        if (Directory.Exists(Application.persistentDataPath + "/saves")) {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }
        string path = Application.persistentDataPath + "/saves" + SaveName + ".save";
        FileStream file = File.Create(path);
        formatter.Serialize(file, SaveData);
        file.Close();
        return true;
    }
    public static BinaryFormatter getBinaryFormatter()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return formatter;
    }
    public static object Load ( string path)
    {
        if (!File.Exists(path))
        {
            return null;
        }
        BinaryFormatter formatter = getBinaryFormatter ();
        FileStream file = File.Open(path, FileMode.Open);
        try
        {
            object Save = formatter.Deserialize(file);
            file.Close();
            return Save;
        }
        catch
        {
            Debug.LogErrorFormat("Failed to load flie at {0}", path);
            file.Close();
            return null;
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
