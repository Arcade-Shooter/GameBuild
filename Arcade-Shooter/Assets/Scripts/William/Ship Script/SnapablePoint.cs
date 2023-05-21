using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapablePoint : MonoBehaviour
{
    [SerializeField] private EquipmentType allowedEquipmentType;
    [SerializeField] private Equipment equippedEquipment;

    public bool HasEquipment()
    {   //Returns whether the point has been taken
        return equippedEquipment != null;
    }

    public void EquipEquipment(Equipment equipment)
    {     
        // Set the parent of the equipment to this snapable point
        equipment.transform.SetParent(transform);

        // Set the local position and rotation of the equipment to match the snapable point
        equipment.transform.localPosition = Vector3.zero;
        equipment.transform.localRotation = Quaternion.identity;
        equipment.Equip();
    }

    public void UnequipEquipment()
    {
        if (equippedEquipment != null)
        {
            equippedEquipment.Unequip();
            equippedEquipment = null;
        }
    }

    public EquipmentType GetAllowedEquipmentType(){
        return this.allowedEquipmentType;
    }
   
}
