using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType {
    Weapon,
    Shield,
    Thruster,
};

public abstract class Equipment : MonoBehaviour
{

    private string Name;     //nme of the item
    private string Description; // description of the item
    [SerializeField] private int Rarity;    //the probability of the item drop
    private EquipType Type; //type of equipment
    private bool Equiped;


    public Equipment(string name, string description, int rarity, EquipType type)
    {
        this.Name = name;
        this.Description = description;
        this.Rarity = rarity;
        this.Type = type;
    }

    public abstract void useItem(GameObject player);
    


}
