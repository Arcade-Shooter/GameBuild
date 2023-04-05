using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Module
{

    [SerializeField] private string WeaponName;
    [SerializeField] private Projectile Projectile;
    [SerializeField] private float FireRate;

    public Weapon(int Health, int Power, string Name, Projectile Projectile, float FireRate)
        : base(Health, Power, Classification.Weapon)
    {
        this.WeaponName = Name;
        this.Projectile = Projectile;
        this.FireRate = FireRate;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {

    }
}
