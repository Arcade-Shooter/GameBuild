using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public static class EnemyPrefabsList
{
    public static readonly List<GameObject> EnemyPrefabs = new List<GameObject>();

    //initialize the list
    static EnemyPrefabsList()
    {
        string folderPath = "Assets/Prefabs/Ships/Enemy"; //path to the folder containing the prefabs
        EnemyPrefabs.AddRange(LoadPrefabsFromFolder(folderPath));   //load all prefabs from the folder
    }


    private static List<GameObject> LoadPrefabsFromFolder(string folderPath)
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

}

