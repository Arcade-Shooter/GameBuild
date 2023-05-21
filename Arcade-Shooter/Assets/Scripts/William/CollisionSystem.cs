using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
     public void HandleCollision(ShipCtrl playerShip, Equipment equipment)
    {
        EquippedManagement equippedManagement = playerShip.GetEquippedManagement();
        // SnapablePoint[] snapablePoints = equippedManagement.GetEquippedPointsByEquipmentType(equipment.GetEquipmentType());
        SnapablePoint[] snapablePoints = equippedManagement.GetSnapablePointsList().ToArray();
        SnapablePoint availableSnapablePoint = FindAvailableSnapablePoint(snapablePoints, equipment.GetEquipmentType());

        if (availableSnapablePoint != null)
        {
            availableSnapablePoint.EquipEquipment(equipment);
        }
        else
        {
            InventoryManagement.Instance.AddEquipment(equipment);
        }
    }

    private SnapablePoint FindAvailableSnapablePoint(SnapablePoint[] snapablePoints, EquipmentType type)
    {   //find an available snapable point
        foreach (SnapablePoint snapablePoint in snapablePoints)
        {
            if (!snapablePoint.HasEquipment())  //check it's taken or not
            {
                if(snapablePoint.GetAllowedEquipmentType() == type){
                    //check the point allowed equipment type
                    return snapablePoint;
                }
            }
        }

        return null;
    }

}
