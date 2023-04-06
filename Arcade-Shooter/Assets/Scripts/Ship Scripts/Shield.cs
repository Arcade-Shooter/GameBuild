using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Module
{

    private int ShieldHealth;
    private int MaxShield;
    private int RechargeRate;
    private int MinActivationAmount;
    private float ShieldDistance;

    public Shield(int Health, int Power, int Shield, int RechargeRate, int MinActivationAmount, float Distance )
        : base(Health, Power, Classification.Shield)
    {
        this.ShieldHealth = Shield;
        this.MaxShield = Shield;
        this.RechargeRate = RechargeRate;
        this.MinActivationAmount = MinActivationAmount;
        this.ShieldDistance = Distance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamadgeShield()
    {

    }

    public override void FireWeapons()
    {
        //Check For attatched modules
        foreach (Snappable snappable in this.SnapPoints)
        {
            Module module = snappable.GetModule();
            if (module != null)
            {
                module.FireWeapons();
            }
        }

    }
}
