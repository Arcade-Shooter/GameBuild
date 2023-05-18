using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponType : Equipment
{
    // [SerializeField] protected int Damage;
    [SerializeField] protected float FireRate;
    [SerializeField] protected int Health;

    protected WeaponType(){
        this.Type = EquipmentType.Weapon;
    }   
    // protected WeaponType(string name, string description, int rarity)
    //     : base(name, description, rarity, EquipmentType.Weapon) 
    //     {

    //     }
    
    public abstract void fire();

}
