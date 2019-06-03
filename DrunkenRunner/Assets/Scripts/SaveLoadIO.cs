using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveLoadIO : MonoBehaviour
{
    string SavesPath = Application.persistentDataPath;
    string CharakerSubPath = "Charakters";

    public void FixFolderStructure()
    {
        if (!Directory.Exists(Path.Combine(SavesPath, CharakerSubPath)))
        {
            Directory.CreateDirectory(Path.Combine(SavesPath, CharakerSubPath));
        }
    }

    public void LoadAllCharaktersData()
    {
        
    }

}
