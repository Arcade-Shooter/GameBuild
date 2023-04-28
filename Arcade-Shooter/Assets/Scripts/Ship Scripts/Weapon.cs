using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Module
{

    [SerializeField] private string WeaponName;
    [SerializeField] private List<Projectile> Projectile;
    [SerializeField] private float FireRate;

    [SerializeField] private GameObject pew;
    private float ShootFrameCounter;
    [SerializeField] private bool shoot;

    // Update is called once per frame
    void Update()
    {

        // If fire rate is 1 then it shoots 1 every 60 frames
        if (ShootFrameCounter <= FireRate) //If the weapon has not completed it's firerate cooldown then continue the cooldown
        {
            ShootFrameCounter += Time.deltaTime;
            shoot = false;
        }
        else if(shoot) //If the weapon has completed it's cooldown and has been told to shoot
        {
            foreach (Projectile p in Projectile)
            {
                Instantiate(p, transform.position, transform.rotation);
            }
            ShootFrameCounter = 0;
            shoot = false;
        }
    }

    public void FireWeapon()
    {
        //Shoot module if applicable
        this.shoot = true;
    }
}
