using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Module
{

    [SerializeField] private string WeaponName;
    [SerializeField] private Projectile Projectile;
    [SerializeField] private float FireRate;

    [SerializeField] private GameObject pew;
    private float ShootFrameCounter;
    [SerializeField] private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (ShootFrameCounter <= FireRate) // If rate is 1 then it shoots 1 every 60 frames
        {
            ShootFrameCounter += Time.deltaTime;
            shoot = false;
        }
        else if(shoot)
        {
            Instantiate(pew, transform.position, transform.rotation);
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
