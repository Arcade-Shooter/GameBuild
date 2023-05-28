using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;
    public int ProbabilityShoot;    //range: 0 - 10
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnemyShoot();
        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the enemy ship position.
        if (transform.position.y < -6.0f)
        {
            //kill the enemy ship object.
            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Debug.Log("Enemy Hit");
            if (Random.Range(0, 10) < 4)    //40% chance to drop a random equipment
            {
                //drop a random equipment on the enemy ship's position
                int randomIndex = Random.Range(0, EquipmentPrefabsList.EquipmentPrefabs.Count);
                Instantiate(EquipmentPrefabsList.EquipmentPrefabs[randomIndex], this.transform.position, Quaternion.identity);  
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Player")
        {
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
