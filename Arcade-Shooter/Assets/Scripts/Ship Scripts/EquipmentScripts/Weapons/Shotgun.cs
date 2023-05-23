using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : WeaponType
{
    void Awake()
    {
        //Equipemtn variable
        this.Name = "Shot Gun";
        this.Description = "This is a Shot Gun";
        this.Rarity = 9;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 1.4f;
    }

    public override void Fire()
    {   
        // Create three bullets and set their orientation
        Vector3 bulletDirection = transform.up; // The direction of the bullet is the direction in which the weapon is facing up
        
        float spreadAngle = 15f;

        // The first bullet, scattered slightly to the left
        Quaternion leftRotation = Quaternion.Euler(0, 0, -spreadAngle);
        Instantiate(Bullet, transform.position, transform.rotation * leftRotation).GetComponent<Bullet>().SetDirection(bulletDirection);

        // The second bullet, in the original direction
        Instantiate(Bullet, transform.position, transform.rotation).GetComponent<Bullet>().SetDirection(bulletDirection);

        // The third bullet, scattered slightly to the right
        Quaternion rightRotation = Quaternion.Euler(0, 0, spreadAngle);
        Instantiate(Bullet, transform.position, transform.rotation * rightRotation).GetComponent<Bullet>().SetDirection(bulletDirection);
    }

}
