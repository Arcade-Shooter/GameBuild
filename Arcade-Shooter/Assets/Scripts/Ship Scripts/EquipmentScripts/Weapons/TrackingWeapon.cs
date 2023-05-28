using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingWeapon : WeaponType
{
    void Awake()
    {
        //Equipemtn variable
        this.Name = "Tracking Waepon";
        this.Description = "This is a Tracking Waepon";
        this.Rarity = 4;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 3.0f;
    }

    public override void Fire()
    {
        //create new Bullet object at the postion where the ship is.
        Instantiate(this.Bullet, transform.position, transform.rotation);

    }

}
