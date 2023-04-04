using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{

    

    private int Healh;
    private int MaxHealth;
    private int Power;
    private int MaxPower;
    private Classification classification;
    private bool PauseState;
    private bool Disabled;



    protected Module(int Health, int Power, Classification classification)
    {
        this.Healh = Health;
        this.MaxHealth = Healh;
        this.Power = Power;
        this.MaxPower = Power;
        this.classification = classification;
        this.PauseState = false;
        this.Disabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamadge(int Damage)
    {

    }

    public void HealDamadge(int Damage)
    {

    }

    public void IncreasePower(int Power)
    {

    }

    public void DecreasePower(int Power)
    {

    }

    public void Enable()
    {

    }

    public void Disable()
    {

    }
}

public enum Classification
{
    Weapon,
    Shield,
    Thruster
}
