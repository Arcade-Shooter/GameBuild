using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedManagement : MonoBehaviour
{
    private int MaxWeaponLength = 6;

    [SerializeField] private SnapablePoint[] snapablePoints;
    [SerializeField] private Dictionary<EquipmentType, SnapablePoint> SnapPointDictionary = new Dictionary<EquipmentType, SnapablePoint>();
   
    public void Equip(Equipment equipment)
    {
        EquipmentType equipmentType = equipment.GetEquipmentType();

         if (SnapPointDictionary.ContainsKey(equipmentType))
        {
            SnapablePoint mountPoint = SnapPointDictionary[equipmentType];

            if (mountPoint.HasEquipment())
            {
                InventoryManagement.Instance.AddEquipment(equipment);
            }
            else
            {
                mountPoint.EquipEquipment(equipment);
            }
        }
        else
        {
            Debug.Log("No avaliable point found");
        }

    }

    public void UnEquipWeapon(EquipmentType equipmentType)
    {
        if (SnapPointDictionary.ContainsKey(equipmentType))
                {
                    SnapablePoint point = SnapPointDictionary[equipmentType];
                    point.UnequipEquipment();
                }    
    }

}
