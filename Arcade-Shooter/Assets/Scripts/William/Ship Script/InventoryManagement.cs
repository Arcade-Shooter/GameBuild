using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagement : MonoBehaviour
{
   private List<Equipment> equipmentList = new List<Equipment>();

    public static InventoryManagement Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddEquipment(Equipment equipment)
    {
        equipmentList.Add(equipment);
    }

    public void RemoveEquipment(Equipment equipment)
    {
        equipmentList.Remove(equipment);
    }

    public Equipment GetRandomEquipment()
    {
        if (equipmentList.Count > 0)
        {
            int randomIndex = Random.Range(0, equipmentList.Count);
            return equipmentList[randomIndex];
        }

        return null;
    }
}
