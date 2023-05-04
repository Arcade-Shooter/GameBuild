using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponType : ItemSystem
{
    [SerializeField] private int Damage { get; }
    [SerializeField] private int FireRate { get; }
    [SerializeField] private int Health { get; }

    protected WeaponType(string name, string description, int rarity, int damage, int fireRate, int Health) 
        : base(name, description, rarity, ItemType.Weapon)
    {
        this.Damage = damage;
        this.FireRate = fireRate;
    }

    public abstract void fire();
}
