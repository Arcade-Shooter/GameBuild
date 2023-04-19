using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
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
                float XPosition = Random.Range(-8.4f, 8.4f);
                GameObject Enemyship1 = Instantiate(EnemyShip, new Vector3(XPosition, 6.5f, 0), Quaternion.Euler(0, 0, 0));

            }
        }
        yield return new WaitForSeconds(3.0f);
    }
}
