using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Equipment : MonoBehaviour
{
    protected EquipmentType Type; //type of equipment
    protected bool Paused;  //not use yet
    [Header("All the attribute should initialize it in inherited class ")]
    [Header("this for test only!")]
    [SerializeField] protected int Health;      //the health of the equipment
    [SerializeField] protected int MaxHealth;   //the max health of the equipment
    [SerializeField] protected string Name;     //nme of the item
    [SerializeField] protected int Rarity;    //the probability of the item drop
    [SerializeField] protected bool Equipped;   //the probability of the item drop
    [SerializeField] private float spawnTime;   //the time when the equipment is spawned
    [SerializeField, TextArea] protected string Description; // description of the item

    protected Equipment()
    {
        Equipped = false;
    }

    protected void Start()
    {
        spawnTime = Time.time; //record the time when the equipment is spawned
        StartCoroutine(CheckLifetime());
    }

    protected IEnumerator CheckLifetime()
    {
        while (true)
        {
            if (Time.time - spawnTime > 15 && !Equipped)
            {
                Destroy(gameObject); //destroy the equipment if it is not equipped for 1 minute
                yield break;
            }

            yield return null;
        }
    }

    public void Equip()
    {
        this.Equipped = true;
        SoundEffect.instance.PlayEquipSound();
        Debug.Log(Name + " is Equipped.");

    }
    public void Unequip()
    {
        this.Equipped = false;
        SoundEffect.instance.PlayUnequipSound();
        Debug.Log(Name + " is Unequipped.");

    }

    public bool GetEquipState()
    {
        return this.Equipped;
    }

    public EquipmentType GetEquipmentType()
    {
        return this.Type;
    }

    public void TakeDamage(int damage)
    {
        if (this.Health > 0)
        {
            this.Health -= damage;
        }
        else
        {
            SoundEffect.instance.PlayExplosionSound();
            Destroy(this);
        }
    }

    public void DestroyEquipment()
    {

    }

    private void OnTriggerEnter2D(Collider2D Collsion)
    {
        if (this.Equipped)
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

}
