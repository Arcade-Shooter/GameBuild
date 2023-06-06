using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public static class EnemyPrefabsList
{
    public static readonly List<GameObject> EnemyPrefabs = new List<GameObject>();

    //initialize the list
#if UNITY_EDITOR    //only run this code in the editor

    static EnemyPrefabsList()
    {
        string folderPath = "Assets/Prefabs/Ships/Enemy"; //path to the folder containing the prefabs
        EnemyPrefabs.AddRange(ResourceManagement.LoadPrefabsFromFolder(folderPath));   //load all prefabs from the folder
    }

#endif

}

