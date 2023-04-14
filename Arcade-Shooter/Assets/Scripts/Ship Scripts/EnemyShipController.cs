using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the enemy ship position.

        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the enemy ship object. 
        }
    }

}
