using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
     public void HandleCollision(ShipCtrl playerShip, Equipment equipment)
    {   //to get all snapable point into a list, then to find an avaibale point to put equipment on.
        EquippedManagement equippedManagement = playerShip.GetEquippedManagement();
        List<SnapablePoint> snapablePoints = equippedManagement.GetSnapablePointsList();  
        SnapablePoint availableSnapablePoint =equippedManagement.FindAvailableSnapablePoint(snapablePoints, equipment.GetEquipmentType());

        if (availableSnapablePoint != null)
        {
            availableSnapablePoint.EquipEquipment(equipment);
        }
        else
        {
            InventoryManagement.Instance.AddEquipment(equipment);
        }
    }

}
