using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManagement : MonoBehaviour
{
    private List<Equipment> equipmentList = new List<Equipment>();

    public static InventoryManagement Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddEquipment(Equipment equipment)
    {   //Add equipment
        equipmentList.Add(equipment);
    }

    public void RemoveEquipment(Equipment equipment)
    {   //Remove Equipment
        equipmentList.Remove(equipment);
    }


    ///
    /// Get Methods: returns a specified type of equipment
    ///
  
    public Equipment[] GetWeapons()
    {   //Get weapons
        List<Equipment> weapons = new List<Equipment>();

        foreach (Equipment equipment in equipmentList)
        {
            if (equipment.GetEquipmentType() == EquipmentType.Weapon)
            {
                weapons.Add(equipment);
            }
        }

        return weapons.ToArray();
    }

    public Equipment[] GetShields()
    {   //Get Shields
        List<Equipment> shields = new List<Equipment>();

        foreach (Equipment equipment in equipmentList)
        {
            if (equipment.GetEquipmentType() == EquipmentType.Shield)
            {
                shields.Add(equipment);
            }
        }

        return shields.ToArray();
    }

    public Equipment[] GetThrusters()
    {   //Get Thrusters
        List<Equipment> thrusters = new List<Equipment>();

        foreach (Equipment equipment in equipmentList)
        {
            if (equipment.GetEquipmentType() == EquipmentType.Thruster)
            {
                thrusters.Add(equipment);
            }
        }

        return thrusters.ToArray();
    }
}
