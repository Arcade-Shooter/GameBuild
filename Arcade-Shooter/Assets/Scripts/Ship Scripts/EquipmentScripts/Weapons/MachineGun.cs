using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponType
{

    void Awake()
    {
        //Equipemtn variable
        this.Name = "MachineGun";
        this.Description = "This is a Machine Gun";
        this.Rarity = 9;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 0.9f;
    }

    public override void Fire()
    {
        Instantiate(this.Bullet, transform.position, transform.rotation);

    }
}
