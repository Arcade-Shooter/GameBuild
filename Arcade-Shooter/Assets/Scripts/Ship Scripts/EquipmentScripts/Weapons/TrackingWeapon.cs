using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWeapon : WeaponType
{
    [SerializeField] private Missile Missiles;
    void Awake()
    {
        //Equipemtn variable
        this.Name = "Tracking Waepon";
        this.Description = "This is a Tracking Waepon";
        this.Rarity = 4;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 1.0f;
    }

    public override void Fire()
    {
        // 获取场上的所有敌人
        EnemyShipController[] enemies = FindObjectsOfType<EnemyShipController>();
        // Debug.Log(enemies.Length + " enemies has been found.");

        if (enemies.Length > 0)
        {
            // 随机选择一个敌人作为追踪目标
            int randomIndex = Random.Range(0, enemies.Length);
            Transform target = enemies[randomIndex].transform;
            Missiles.SetTarget(target);
            Instantiate(Missiles, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("No Enemy Found!");
        }

        // Vector3 direction = enemies[randomIndex].transform.position;
        // float spreadAngle = 360 - Mathf.Atan2(direction.x, direction.y)  * Mathf.Rad2Deg;
        // transform.eulerAngles = new Vector3(0,0, spreadAngle);
        // this.transform.rotation = this.transform.rotation * Quaternion.Euler(0,0,rotationAngle);
        // transform.Translate(Vector3.up * Bullet.speed * Time.deltaTime);


       
    }

}
