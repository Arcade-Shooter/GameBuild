using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponType
{

    public GameObject Bullet;
    private float nextFireTime = 0f;
    public MachineGun(){
        
    }

    void Awake() {
        //Equipemtn variable
        this.Name = "MachineGun";
        this.Description ="This is a Machine Gun";
        this.Rarity = 9;
        //WeaponType veriable 
        this.Health = 3;
        this.FireRate = 1.3f;
    }

    void Update()
    {
        if(this.Equipped == true){
            Fire();
        }
    }

    public override void Fire()
    {

        if (Time.time > nextFireTime)
        {
            GameObject.Instantiate(Bullet, transform.position, transform.rotation);
            nextFireTime = Time.time + 1 / this.FireRate;
        }
        Debug.Log("MachineGun is firing at a rate of " + this.FireRate + " bullets per second.");
    }

    public override void Equip()
    {
        this.Equipped = true;
        Debug.Log("MachineGun equipped.");
    }

    public override void Unequip()
    {
        this.Equipped = false;
        Debug.Log("MachineGun unequipped.");
    }
}
