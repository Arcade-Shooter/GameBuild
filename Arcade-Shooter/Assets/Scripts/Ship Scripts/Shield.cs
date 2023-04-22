using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shield : Module
{

    [SerializeField] private float ShieldHealth;
    [SerializeField] private float MaxShield;
    [SerializeField] private float RechargeRate;
    private int MinActivationAmount; //Not Implimented yet
    private float ShieldDistance; //Not Implimented yet
    [SerializeField] private List<ShieldLayer> ShieldLayers;

    public Shield(int Health, int Power, float Shield, float RechargeRate, int MinActivationAmount, float Distance )
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
     
        foreach (ShieldLayer layer in ShieldLayers)
        {
            layer.CollisionCallBack = DamadgeShield;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!this.Connected) //Sets the shield health to zero when disconected
        {
            ShieldHealth = 0;
        }
        else if (!this.PauseState && ShieldHealth < MaxShield) //Increases shield health per frame
        {
            ShieldHealth += RechargeRate * Time.deltaTime;
            if (ShieldHealth > MaxShield)
            {
                ShieldHealth = MaxShield;
            }
        }




        //Determine shield visualisation (Hard Coded!!!!)

        int count = 0;
        for (; count < (int)ShieldHealth; count++) //Shield Layers on
        {
            ShieldLayer layer = ShieldLayers[count];
            layer.GetComponent<SpriteRenderer>().enabled = true;
            layer.GetComponent<BoxCollider2D>().enabled = true;
        }

        for (; count < MaxShield; count++) //Shield Layers off
        {
            ShieldLayer layer = ShieldLayers[count];
            layer.GetComponent<SpriteRenderer>().enabled = false;
            layer.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void DamadgeShield(int damadge)
    {
        this.ShieldHealth -= damadge;
        if (this.ShieldHealth < 1)
        {
            ShieldHealth = 0;
        }
    }
}
