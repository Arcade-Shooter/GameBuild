using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment : MonoBehaviour
{
    protected EquipmentType Type; //type of equipment
    protected bool Paused;  //not use yet
    [Header("All the attribute should initialize it in inherited class ")]
    [Header("this for test only!")]
    [SerializeField] protected int Health;
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected string Name;     //nme of the item
    [SerializeField] protected int Rarity;    //the probability of the item drop
    [SerializeField] protected bool Equipped;
    [SerializeField, TextArea] protected string Description; // description of the item

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

    public bool GetEquipState(){
        return this.Equipped;
    }

    public EquipmentType GetEquipmentType(){
        return this.Type;
    }

    public void TakeDamage(int damage){
        if(this.Health > 0){
            this.Health -= damage;
        }else{
            Destroy(this);
        }
    }

        private void OnTriggerEnter2D(Collider2D Collsion)
    {
        if (Collsion.tag == "EnemyBullet")
        {
            // int damage = Collsion.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(1);
            Destroy(Collsion.gameObject);
        }
        else if (Collsion.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(Collsion.gameObject);
        }
    }

}
