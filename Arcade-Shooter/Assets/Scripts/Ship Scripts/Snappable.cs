using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snappable : MonoBehaviour
{

    [SerializeField] private bool IsDisabled;
    [SerializeField] private bool IsOccupied;

    [SerializeField] private bool IsInventoryPoint;
    [SerializeField] private bool IsShieldPoint;
    [SerializeField] private Equipment equipment = null;

    void Awake(){
        this.IsOccupied = false;
    }

    /********************
     * Getters
    ********************/
    public bool GetDisabledState()
    {
        return IsDisabled;
    }

    public bool GetOccupiedState()
    {
        return IsOccupied;
    }

    public bool GetInventoryPoint(){
        return this.IsInventoryPoint;
    }
    public Equipment GetEquipment()
    {
        return equipment;
    }


    /********************
     * Setters
    ********************/

    public void Disable()
    {
        this.IsDisabled = true;
    }

    public void Enable() 
    {
        this.IsDisabled = false;
    }

    public void SetInventoryPoint(){
        this.IsInventoryPoint = true;
    }




    //Occupy is a method that changes the state of a snap point.
    //If the snap point is occupied it is ignored by the snap controller for attaching drag dropped modules
    public void Occupy(Equipment equipment)
    {
        this.IsDisabled = true;
        this.IsOccupied = true;
        this.equipment = equipment;

        this.equipment.transform.position = this.transform.position;
        this.equipment.transform.SetParent(this.transform);
        //Adjust parent to be this node for movement
        if(!this.IsInventoryPoint){
            this.equipment.Equip();
        }
        
    }

    //Vacate is a methos the releases the held state of a snap point
    public void Vacate()
    {

        //Release this as the parent node
        this.GetEquipment().transform.parent = null;

        this.IsOccupied = false;
        this.IsDisabled = false;
        this.equipment.Unequip();
        this.equipment = null;
    }
}