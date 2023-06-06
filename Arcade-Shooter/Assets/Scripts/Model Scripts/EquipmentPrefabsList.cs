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
    #if UNITY_EDITOR    //only run this code in the editor
    static EquipmentPrefabsList()
    {
        string folderPath = "Assets/Prefabs/Equipment"; //path to the folder containing the prefabs
        EquipmentPrefabs.AddRange(ResourceManagement.LoadPrefabsFromFolder(folderPath));   //load all prefabs from the folder
    }
    #endif


    //get a random equipment from the list
    public static GameObject GetRandomEquipment()
    {
        return EquipmentPrefabs[Random.Range(0, EquipmentPrefabs.Count)];
    }



}

