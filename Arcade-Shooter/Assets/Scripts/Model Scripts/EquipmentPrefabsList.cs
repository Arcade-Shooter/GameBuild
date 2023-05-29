using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public static class EquipmentPrefabsList
{
    //create a read only list of prefabs that can be accessed from anywhere, but only initialized here.
    //this is used to spawn random equipment on enemy death.
    public static readonly List<GameObject> EquipmentPrefabs = new List<GameObject>();

    //initialize the list
    static EquipmentPrefabsList()
    {
        string folderPath = "Assets/Prefabs/Equipment"; //path to the folder containing the prefabs
        EquipmentPrefabs.AddRange(LoadPrefabsFromFolder(folderPath));   //load all prefabs from the folder
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

    //get a random equipment from the list
    public static GameObject GetRandomEquipment()
    {
        return EquipmentPrefabs[Random.Range(0, EquipmentPrefabs.Count)];
    }



}

