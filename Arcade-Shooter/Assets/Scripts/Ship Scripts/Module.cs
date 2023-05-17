using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{

    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    private int Power; // Not Implimented
    [SerializeField] private Classification classification;
    protected bool Paused;
    protected bool Disabled;
    public bool Connected;


    //Method for taking damage
    public void TakeDamage(int Damage)
    {
        this.Health -= Damage;
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Method for healing damage
    public void HealDamage(int Damage)
    {
        this.Health += Damage;
    }

    //Methods for adjusting power
    public void IncreasePower(int Power)
    {
        this.Power += Power;
    }

    public void DecreasePower(int Power)
    {
        this.Power -= Power;
    }

    //Methods for toggling disabled state
    public void Enable()
    {
        this.Disabled = false;
    }

    public void Disable()
    {
        this.Disabled = true;
    }

    //Method to return the Classification of the module
    public Classification GetClassification()
    {
        return this.classification;
    }

    internal bool IsThruster() //Simple method used in the ships detect thrusters method
    {
        return this.classification == Classification.Thruster;
    }

    //Method to control Collisions with modules
    private void OnTriggerEnter2D(Collider2D Collsion)
    {
        if (Collsion.tag == "EnemyBullet")
        {
            int damage = Collsion.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(Collsion.gameObject);
        }
        else if (Collsion.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(Collsion.gameObject);
        }
    }
}

    //Module classifications
    public enum Classification 
{
    Weapon,
    Shield,
    Thruster
}
