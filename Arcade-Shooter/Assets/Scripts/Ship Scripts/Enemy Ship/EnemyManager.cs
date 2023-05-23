using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject EnemyShip;

    [SerializeField] private int MinEnemies = 1;
    [SerializeField] private int MaxEnemies = 9;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator());

    }

    IEnumerator enumerator()
    {
        while (true)
        {
            int numEnemies = Random.Range(MinEnemies, MaxEnemies); 
            for (int i = 0; i < numEnemies; i++)
            {
                GameObject NewEnemy = Instantiate(EnemyShip);
                float XPosition = Random.Range(-9, 9);
                NewEnemy.transform.position = new Vector3(XPosition, 7, 0);
            }

            yield return new WaitForSeconds(Random.Range(1, 5));
        }
    }
}
