using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;


    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the bullet position.
        if (transform.position.y > 5.53f || transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the bullet object. 
        }
    }

    public void SetDirection(Vector3 dirction)
    {
        this.Direction = dirction.normalized;
    }

}
