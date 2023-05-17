using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponType : Equipment
{
    [SerializeField] private int Damage;
    [SerializeField] private int FireRate;
    [SerializeField] private int Health;

    protected WeaponType(string name, string description, int rarity, int damage, int fireRate, int Health) 
        : base(name, description, rarity, EquipType.Weapon)
    {
        this.Damage = damage;
        this.FireRate = fireRate;
    }

    public abstract void fire();
}
