using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyShip;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enumerator());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator enumerator()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject NewEnemy = Instantiate(EnemyShip);
                float XPosition = Random.Range(-9, 9);
                NewEnemy.transform.position = new Vector3(XPosition, -7, 0);
            }

            yield return new WaitForSeconds(2.0f);
        }
    }
}
