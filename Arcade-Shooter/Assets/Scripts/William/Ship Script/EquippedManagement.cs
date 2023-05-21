using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedManagement : MonoBehaviour
{
    private List<SnapablePoint> SnapablePointsList = new List<SnapablePoint>(); // to store all the snapable points
    [SerializeField] private SnapablePoint[] EquippedPoints;    //to store all equipped points
    [SerializeField] private Dictionary<EquipmentType, SnapablePoint> EquippedPointDictionary = new Dictionary<EquipmentType, SnapablePoint>();

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
    {   //put the equipment on a snapable point
        EquipmentType equipmentType = equipment.GetEquipmentType();
        List<SnapablePoint> availablePoints = new List<SnapablePoint>();

        // 检查所有挂载点，找到空的可用类型的挂载点
        foreach (SnapablePoint point in SnapablePointsList)
        {
            if (point.GetAllowedEquipmentType() == equipmentType && !point.HasEquipment())
            {
                availablePoints.Add(point);
            }
        }

        if (availablePoints.Count > 0)
        {
            // 找到可用的挂载点，将装备挂载到第一个可用的挂载点上
            SnapablePoint point = availablePoints[0];
            point.EquipEquipment(equipment);
        }
        else
        {
            // 没有可用的挂载点，将装备添加到背包中
            InventoryManagement.Instance.AddEquipment(equipment);
        }

    }

    public void UnEquipWeapon(EquipmentType equipmentType)
    {
        if (this.EquippedPointDictionary.ContainsKey(equipmentType))
        {
            SnapablePoint point = this.EquippedPointDictionary[equipmentType];
            point.UnequipEquipment();
        }
    }

    public SnapablePoint[] GetEquippedPointsByEquipmentType(EquipmentType equipmentType)
    {   //Find all equipped point of the same type
        List<SnapablePoint> snapablePointsOfType = new List<SnapablePoint>();

        foreach (SnapablePoint snapablePoint in EquippedPoints)
        {
            if (snapablePoint.GetAllowedEquipmentType() == equipmentType)
            {
                snapablePointsOfType.Add(snapablePoint);
            }
        }

        return snapablePointsOfType.ToArray();
    }

    private void SwitchToNextEquipment(EquipmentType equipmentType)
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

    public List<SnapablePoint> GetSnapablePointsList () {
        return this.SnapablePointsList;
    }

}
