using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ResourceManagement : MonoBehaviour
{

#if UNITY_EDITOR    //only run this code in the editor

    public static List<GameObject> LoadPrefabsFromFolder(string folderPath)
    {
        List<GameObject> prefabsList = new List<GameObject>();

        //get all files in the folder
        string[] files = Directory.GetFiles(folderPath);

        //loop through all files in the folder
        foreach (string file in files)
        {
            if (Path.GetExtension(file) == ".prefab")   //if the file is a prefab
            {
                GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(file);    //load the prefab
                if (prefab != null)
                {
                    prefabsList.Add(prefab);
                }
            }
        }

        return prefabsList;
    }

#endif


}
 