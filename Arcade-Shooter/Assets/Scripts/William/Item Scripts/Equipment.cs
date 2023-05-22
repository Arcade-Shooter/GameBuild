using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment : MonoBehaviour
{

    protected string Name;     //nme of the item
    protected string Description; // description of the item
    [SerializeField] protected int Rarity;    //the probability of the item drop
    protected EquipmentType Type; //type of equipment
    protected bool Equipped;

    protected Equipment()
    {
        Equipped = false; 
    }

    public void Equip(){
        this.Equipped = true;
        Debug.Log(Name + " is Equipped.");
    }
    public void Unequip(){
        this.Equipped = false;
        Debug.Log(Name + " is Unequipped.");

    }

    public EquipmentType GetEquipmentType(){
        return this.Type;
    }

}
