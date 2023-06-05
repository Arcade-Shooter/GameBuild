using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //get the enemy ship prefab list
    [SerializeField] private List<GameObject> EnemyShipPrefabs = new List<GameObject>();
    [SerializeField] private int MinEnemies = 1;
    [SerializeField] private int MaxEnemies = 5;

    private float CameraLeft;
    // = CameraBounds.LeftBoundary;
    private float CameraRight;
    // = CameraBounds.RightBoundary;
    private float spawnRangeX;
    //  = CameraBounds.RightBoundary - CameraBounds.LeftBoundary;
    private float spawnHeight;
    //  = CameraBounds.TopBoundary + 1;

    void Awake()
    {
        EnemyShipPrefabs.AddRange(EnemyPrefabsList.EnemyPrefabs); //get the enemy ship prefab list
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator());

        //initialize the camera boundaries
        CameraLeft = CameraBounds.LeftBoundary;
        CameraRight = CameraBounds.RightBoundary;
        spawnRangeX = CameraBounds.RightBoundary - CameraBounds.LeftBoundary;
        spawnHeight = CameraBounds.TopBoundary + 1;

    }


    IEnumerator enumerator()
    {
        while (true)
        {
            //check if game is not paused
            if (!StateManager.instance.getState())
            {
                int numEnemies = Random.Range(MinEnemies, MaxEnemies);  //randomly generate the number of enemies
                for (int i = 0; i < numEnemies; i++)
                {
                    //randomly generate the enemy ship
                    GameObject NewEnemy = Instantiate(EnemyShipPrefabs[Random.Range(0, EnemyShipPrefabs.Count)]);
                    float XPosition = Random.Range(CameraLeft, CameraRight);    //randomly generate the x position of the enemy ship
                    float YPosition = spawnHeight + Random.Range(0, 7);  //randomly generate the y position of the enemy ship
                    NewEnemy.transform.position = new Vector3(XPosition, YPosition, 0); //set the position of the enemy ship
                }

                yield return new WaitForSeconds(Random.Range(0, 3));
            }


        }
    }


}
