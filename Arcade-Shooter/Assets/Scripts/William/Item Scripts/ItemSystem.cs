using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSystem : MonoBehaviour
{

    public enum ItemType {
        Weapon,
        Shield,
        Thruster,
        Healiing
    };

    private string Name { get; }    //name of the item
    private string Description { get; } // description of the item
    [SerializeField] private int Rarity { get; }    //the probability of the item drop
    private ItemType Type;


    public ItemSystem(string name, string description, int rarity, ItemType type)
    {
        this.Name = name;
        this.Description = description;
        this.Rarity = rarity;
        this.Type = type;
    }

    public abstract void useItem(GameObject player);

}
