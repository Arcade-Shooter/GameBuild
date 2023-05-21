using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponType
{
    public GameObject Bullet;
    private float nextFireTime = 0f;

    void Awake() {
        //Equipemtn variable
        this.Name = "Shot Gun";
        this.Description ="This is a Shot Gun";
        this.Rarity = 9;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 1.2f;
    }

    void Update()
    {
        if(this.Equipped == true){
            Fire();
        }
    }

    public override void Fire()
    {
        // 创建三颗子弹并设置其方向
        Vector3 bulletDirection = transform.up; // 子弹的方向为武器朝上的方向
        Quaternion bulletRotation = Quaternion.Euler(0, 0, 0); // 子弹的旋转角度
        float spreadAngle = 15f;

         if (Time.time > nextFireTime)
        {
          // 散射角度

        // 第一颗子弹，朝向略微向左散射
        Quaternion leftRotation = Quaternion.Euler(0, 0, -spreadAngle);
        Instantiate(Bullet, transform.position, transform.rotation * leftRotation).GetComponent<Bullet>().SetDirection(bulletDirection);

        // 第二颗子弹，朝向原方向
        Instantiate(Bullet, transform.position, transform.rotation).GetComponent<Bullet>().SetDirection(bulletDirection);

        // 第三颗子弹，朝向略微向右散射
        Quaternion rightRotation = Quaternion.Euler(0, 0, spreadAngle);
        Instantiate(Bullet, transform.position, transform.rotation * rightRotation).GetComponent<Bullet>().SetDirection(bulletDirection);
            nextFireTime = Time.time + 1 / this.FireRate;
        }
    }

      public override void Equip()
    {
        this.Equipped = true;
        Debug.Log("ShotGun equipped.");
    }

    public override void Unequip()
    {
        this.Equipped = false;
        Debug.Log("ShotGun unequipped.");
    }
}
