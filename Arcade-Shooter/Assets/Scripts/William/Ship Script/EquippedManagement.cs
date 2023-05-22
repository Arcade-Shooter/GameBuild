using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedManagement : MonoBehaviour
{
    private List<SnapablePoint> SnapablePointsList = new List<SnapablePoint>(); // to store all the snapable points
    private InventoryManagement inventoryManagement;

    //The counters for the current equipment list loop
    private int currenctWeaponIndex = 0;
    private int currentShieldIndex = 0;
    private int currentThrusterIndex = 0;

    private void Start()
    {
        this.inventoryManagement = InventoryManagement.Instance;
        // find all snapable point in scene, then save it in the list
        SnapablePoint[] allSnapablePoints = FindObjectsOfType<SnapablePoint>();
        this.SnapablePointsList.AddRange(allSnapablePoints);
    }

    public void Equip(Equipment equipment)
    {
        //put the equipment on a snapable point
        SnapablePoint AvailablePoint = FindAvailableSnapablePoint(SnapablePointsList, equipment.GetEquipmentType());

        if (AvailablePoint != null)
        {
            // Find an available snapable point and mount the equipment to the available point
            AvailablePoint.EquipEquipment(equipment);
        }
        else
        {
            // No snapable points available, add to the inventory
            InventoryManagement.Instance.AddEquipment(equipment);
        }

    }

    public void UnEquipWeapon(Equipment equipment)
    {
        foreach (SnapablePoint point in SnapablePointsList)
        {
            if (point.GetEquippedEquipment() == equipment)
            {
                point.UnequipEquipment();
            }
        }
    }

    public SnapablePoint FindAvailableSnapablePoint(List<SnapablePoint> snapablePoints, EquipmentType type)
    {   //find an available snapable point
        foreach (SnapablePoint snapablePoint in snapablePoints)
        {
            if (!snapablePoint.HasEquipment())  //check it's taken or not
            {
                if (snapablePoint.GetAllowedEquipmentType() == type)
                {
                    //check the point allowed equipment type
                    return snapablePoint;
                }
            }
        }

        return null;
    }

    // public SnapablePoint[] GetEquippedPointsByEquipmentType(EquipmentType equipmentType)
    // {   //Find all equipped point of the same type
    //     List<SnapablePoint> snapablePointsOfType = new List<SnapablePoint>();

    //     foreach (SnapablePoint snapablePoint in SnapablePointsList)
    //     {
    //         if (snapablePoint.GetAllowedEquipmentType() == equipmentType)
    //         {
    //             snapablePointsOfType.Add(snapablePoint);
    //         }
    //     }

    //     return snapablePointsOfType.ToArray();
    // }

    public void SwitchToNextEquipment(EquipmentType equipmentType)
    {
        //Get the corresponding type of equipment
        Equipment[] equipmentList = null;

        switch (equipmentType)
        {
            case EquipmentType.Weapon:
                //Get a list of weapons
                equipmentList = this.inventoryManagement.GetWeapons();
                //Determine if the weapon list is empty or not
                if (equipmentList.Length > 0)
                {
                    //Verify that the current index does not exceed the array length
                    if (currenctWeaponIndex >= equipmentList.Length)
                    {
                        currenctWeaponIndex = 0;    //reset to 0 when find last equipment in the list
                    }
                    else
                    {
                        currenctWeaponIndex += 1;   //add 1 for next equipment
                    }
                    this.Equip(equipmentList[currenctWeaponIndex]);
                }
                break;
            case EquipmentType.Shield:
                //Get a list of Shields
                equipmentList = this.inventoryManagement.GetShields();
                //Determine if the weapon list is empty or not
                if (equipmentList.Length > 0)
                {
                    //Verify that the current index does not exceed the array length
                    if (currentShieldIndex >= equipmentList.Length)
                    {
                        currentShieldIndex = 0;
                    }
                    else
                    {
                        currentShieldIndex += 1;
                    }
                    this.Equip(equipmentList[currenctWeaponIndex]);
                }
                break;
            case EquipmentType.Thruster:
                //Get a list of Thrusters
                equipmentList = this.inventoryManagement.GetThrusters();
                //Determine if the weapon list is empty or not
                if (equipmentList.Length > 0)
                {
                    //Verify that the current index does not exceed the array length
                    if (currentThrusterIndex >= equipmentList.Length)
                    {
                        currentThrusterIndex = 0;
                    }
                    else
                    {
                        currentThrusterIndex += 1;
                    }
                    this.Equip(equipmentList[currenctWeaponIndex]);
                }
                break;
        }
    }

    public List<SnapablePoint> GetSnapablePointsList()
    {
        return this.SnapablePointsList;
    }

}
