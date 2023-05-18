using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType {
    Weapon,
    Shield,
    Thruster,
};

public abstract class Equipment : MonoBehaviour
{

    protected string Name;     //nme of the item
    protected string Description; // description of the item
    [SerializeField] protected int Rarity;    //the probability of the item drop
    protected EquipmentType Type; //type of equipment
    protected bool Equipped;

    protected Equipment(){
        this.Equipped = false;
    }

    // protected Equipment(string name, string description, int rarity, EquipmentType type)
    // {
    //     this.Name = name;
    //     this.Description = description;
    //     this.Rarity = rarity;
    //     this.Type = type;
    //     this.Equipped = false;
    // }

    public abstract void Equip();
    public abstract void Unequip();

}
