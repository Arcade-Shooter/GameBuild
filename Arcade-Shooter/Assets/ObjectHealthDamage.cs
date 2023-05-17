using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthDamage : MonoBehaviour
{
    public GameObject Hb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Copy Pasted Code from "Enemy Ship Controller"
        if(collision.tag == "PlayerBullet")
        {
            //int testHealth = Hb.Healthbae
            Debug.Log("OBJHEAlth Damage test");
            //Hb.HealthbarV7SpriteTiled.damage();
            Debug.Log("OBJHEAlth ReadDamage: Die?");
            //Debug.Log("OBJHEAlth ReadDamage: Survive?"+Hb.HealthbarV);
            //if Hb.HealthbarV7SpriteTiled.health 
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.tag == "PlayerBullet")
    //     {
    //         Debug.Log("Enemy Hit");
    //         Destroy(gameObject);
    //         Destroy(collision.gameObject);
    //     }
    //     if (collision.tag == "Player")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
