using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShip : MonoBehaviour
{
    //general boss ship variables
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int Speed;
    [SerializeField] private GameObject Bullet;

    private float FireRate;
    private int direction;

    float CameraLeft;
    float CameraRight;

    private void Awake()
    {
        this.MaxHealth = 10;
        this.Speed = 3;
        this.Health = this.MaxHealth;
        this.FireRate = 3.0f;
        //initialize the camera boundaries
        CameraLeft = CameraBounds.LeftBoundary;
        CameraRight = CameraBounds.RightBoundary;

    }

    void Update()
    {
        if (PauseMenu.GameIsPaused)    //check if game is paused
        {
            //randomly generate the direction of the boss ship in every 2 seconds
            if (Time.frameCount % 120 == 0)
            {
                direction = Random.Range(0, 99);
            }
            Move();

            //call fire function every seconds
            if (Time.frameCount % 50 == 0)
            {
                Fire();
            }
        }
    }

    //boss move function
    //boss ship can only move left and right inside of the camera boundary, boss ship boarder detection is implemented
    private void Move()
    {
        //get the boarder of the ship by renderer
        float ShipLeft = GetComponent<Renderer>().bounds.min.x;
        float ShipRight = GetComponent<Renderer>().bounds.max.x;
        if (direction < 50)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            if (transform.position.x + ShipLeft <= CameraLeft)
            {
                transform.position = new Vector3(CameraLeft - ShipLeft, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            if (transform.position.x + ShipLeft >= CameraRight)
            {
                transform.position = new Vector3(CameraRight - ShipRight, transform.position.y, transform.position.z);
            }
        }
    }

    //boss ship fire function
    //boss ship can fire 5 bullets at the same time
    public void Fire()
    {
        //play boss ship shoot sound effect
        ShipSoundEffect.instance.PlayBossShootSound();
        //create new Bullet object at the postion where the ship is, and bullet direction is spreaded
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 10));
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, -10));
        Instantiate(Bullet, transform.position, Quaternion.identity);
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 20));
        Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, -20));
    }

    //boss ship take damage function
    public void TakeDamage()
    {
        this.Health -= 1;
        if (this.Health <= 0)
        {
            OnDestroy();
            this.Health = 0;
        }
    }

    private void OnDestroy()
    {
        //play explosion sound effect when boss ship is destroyed
        ShipSoundEffect.instance.PlayExplosionSound();
        //drop equipment when boss ship is destroyed
        GameObject randomEquipment = EquipmentPrefabsList.GetRandomEquipment();
        Instantiate(randomEquipment, this.transform.position, Quaternion.identity);  //drop the equipment on the boss ship's position

        //play explosion animation and sound effect when boss ship is destroyed
        Destroy(gameObject);
    }
}
