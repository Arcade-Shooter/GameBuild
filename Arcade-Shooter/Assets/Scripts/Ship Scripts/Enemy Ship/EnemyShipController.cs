using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;
    public float ProbabilityShoot = 0.6f;    //range: 0 - 1
    // Start is called before the first frame update

    private float shootTimer = 0f;
    private float shootInterval = 0.3f; // 发射间隔
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        move();
        // if (Random.Range(0, 1) <= ProbabilityShoot)
        // {
        //     //create new Bullet object at the postion where the ship is.
        //     EnemyShoot();
        // }
        // 更新计时器
        shootTimer += Time.deltaTime;

        // 当计时器超过发射间隔时发射子弹
        if (shootTimer >= shootInterval)
        {
            if (Random.Range(0f, 1f) <= ProbabilityShoot)
            {
                // 创建新的子弹对象在敌人的位置
                EnemyShoot();
            }

            // 重置计时器
            shootTimer = 0f;
        }
    }

    private void move()
    {
        //move the enemy ship
        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the enemy ship position.

        //if the whole body of the enemy ship is out of the camera view, destroy the enemy ship object.
        if (transform.position.y < CameraBounds.BottomBoundary - gameObject.GetComponent<SpriteRenderer>().bounds.size.y)
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
        Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(0, 0, 0));
    }

}
