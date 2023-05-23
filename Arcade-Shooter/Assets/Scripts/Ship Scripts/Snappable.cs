using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snappable : MonoBehaviour
{

    [SerializeField] private bool IsDisabled;
    [SerializeField] private bool IsOccupied;

    [SerializeField] private bool IsInventoryPoint = false;
    [SerializeField] private Equipment equipment = null;


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

    public bool GetIsInventoryPoint(){
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
        this.equipment.Connected = true;

        //Adjust parent to be this node for movement
        this.equipment.transform.position = this.transform.position;
        this.equipment.transform.SetParent(this.transform);
        
    }

    //Vacate is a methos the releases the held state of a snap point
    public void Vacate()
    {

        //Release this as the parent node
        this.GetEquipment().transform.parent = null;

        this.IsOccupied = false;
        this.IsDisabled = false;
        this.equipment.Connected = false;
        this.equipment = null;
    }
}