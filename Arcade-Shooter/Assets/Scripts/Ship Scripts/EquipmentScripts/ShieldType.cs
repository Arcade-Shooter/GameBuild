using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldType : Equipment
{
    void Awake() {
        this.Name = "Shield";
        this.Description = "This is a Shield";
        this.MaxHealth = 3;
        this.Health = this.MaxHealth;
        this.Rarity = 7;
    }

    protected ShieldType()
    {
        this.Type = EquipmentType.Shield;
    }

   
}
