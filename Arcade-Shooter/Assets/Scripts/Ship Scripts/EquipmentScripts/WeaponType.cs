using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponType : Equipment
{
    // [SerializeField] protected int Damage;
    [SerializeField] protected float FireRate;
    [SerializeField] protected GameObject Bullet;

    protected WeaponType()
    {
        this.Type = EquipmentType.Weapon;
        this.Equipped = true;
    }

    public void AutoFire()
    {
        if (this.Equipped)
        {
            Fire();
        }
        else
        {

        }
    }

    public virtual void Fire()
    {

    }

    protected void Start()
    {
        StartCoroutine(FireWithRate(FireRate));
    }

    protected IEnumerator FireWithRate(float fireRate)
    {
        while (true)
        {
            AutoFire();
            // Wait a certain amount of time to control the frequency of firing
            yield return new WaitForSeconds(1f / fireRate);
        }
    }

}
