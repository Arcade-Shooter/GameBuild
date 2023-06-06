using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthDamage : MonoBehaviour
{
    //Temporarily ignoring this function for now but will move to EnemyShipController
    // public GameObject Hb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Copy Pasted Code from "Enemy Ship Controller"
        if(collision.tag == "PlayerBullet")
        {
            // Debug.Log("OBJECTHEALTHDAMAGE.CS DOESNT USE HEALTHBARV12 PROBABLY SHOULD");
            //We will come back here





            //int testHealth = Hb.Healthbae
            // Debug.Log("OBJHEAlth Damage test");
            //Hb.HealthbarV7SpriteTiled.damage();
            // Debug.Log("OBJHEAlth ReadDamage: Die?");
            //Debug.Log("OBJHEAlth ReadDamage: Survive?"+Hb.HealthbarV);
            //if Hb.HealthbarV7SpriteTiled.health 
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Player")
        {
            Debug.Log("Touched Player ALSO HEALTHBARV12.CS");
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
