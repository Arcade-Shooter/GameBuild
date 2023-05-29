using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;
    public int ProbabilityShoot;    //range: 0 - 10
    // Start is called before the first frame update

//stealing code from ObjectHealthDamage
    //need to drag in the healthbar here (the healthbar prefab should contain the healthbar script necessary)
    public GameObject hb;
    void Start()
    {
        EnemyShoot();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            hb.GetComponent<Healthbar>().Damage(1); 
            int health = hb.GetComponent<Healthbar>().getCurrentHealth();
            if(health <= 0)
            {
                Debug.Log("No Health: Enemy Destroyed");
                Destroy(gameObject);
                Destroy(collision.gameObject);
            } else
            {
                Debug.Log("Some Health: Enemy Survived");
            }

            
        }
        if (collision.tag == "Player")
        {
            Debug.Log("No Healthbar stuff, just die");
            Destroy(gameObject);
        }
    }

    public void EnemyShoot()
    {
        float Probability = Random.Range(0, 10);
        if (Probability <= ProbabilityShoot)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(0, 0, 0));   //create new Bullet object at the postion where the ship is.

        }
    }

}
