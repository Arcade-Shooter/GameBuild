using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shield : Equipment
{

    [SerializeField] private float ShieldHealth;
    [SerializeField] private float MaxShield;
    [SerializeField] private float RechargeRate;
    private int MinActivationAmount; //Not Implimented yet
    private float ShieldDistance; //Not Implimented yet
    [SerializeField] private List<ShieldLayer> ShieldLayers;

    // Start is called before the first frame update
    void Start()
    {
     
        //This gives each of the shield layers the callback method for damage shield
        foreach (ShieldLayer layer in ShieldLayers)
        {
            layer.CollisionCallBack = DamageShield;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!this.Connected) //Sets the shield health to zero when disconected to avoid exploitation
        {
            ShieldHealth = 0;
        }
        else if (!this.Paused && ShieldHealth < MaxShield) //Increases shield health per frame
        {
            ShieldHealth += RechargeRate * Time.deltaTime;
            if (ShieldHealth > MaxShield)
            {
                ShieldHealth = MaxShield; //Reached max shield health
            }
        }




        //Determine shield visualisation (Hard Coded!!!!)
        //These two for loops determine if things should be turned on or off
        //The first for loop counts from 0 up to current health, turning on the relevant shield layers
        //The second for loop cound from current health to max health turning off the relevant shield layers

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

    //Setter for shield health damage
    public void DamageShield(int damadge)
    {
        this.ShieldHealth -= damadge;
        if (this.ShieldHealth < 1)
        {
            ShieldHealth = 0;
        }
    }

    //Anti cheat method so that moving the shield can't be exploited
    public void ResetShield()
    {
        this.ShieldHealth = 0;
    }
}
