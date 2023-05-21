using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapablePoint : MonoBehaviour
{
    public EquipmentType allowedEquipmentType;
    private Equipment equippedEquipment;

    public bool HasEquipment()
    {
        return equippedEquipment != null;
    }

    public void EquipEquipment(Equipment equipment)
    {
        equippedEquipment = equipment;
        equipment.transform.SetParent(transform);
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
   
}
