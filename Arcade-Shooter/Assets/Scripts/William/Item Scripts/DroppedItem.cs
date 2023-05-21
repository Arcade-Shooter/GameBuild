using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DroppedItem : MonoBehaviour
{
    protected string Name;     //nme of the item
    protected string Description; // description of the item
    [SerializeField] protected int Rarity;    //the probability of the item drop
    protected DroppedItemList Type; //type of equipment
    protected bool used;

    protected DroppedItem(){
        this.used = false;
    }

    public abstract void UseItem();
    public abstract void DropItem();
}
