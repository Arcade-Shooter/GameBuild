using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Module;

public class Snappable : MonoBehaviour
{

    [SerializeField] private bool IsDisabled;
    [SerializeField] private bool IsOccupied;
    [SerializeField] private Module module = null;


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

    public Module GetModule()
    {
        return module;
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



    //Occupy is a method that changes the state of a snap point.
    //If the snap point is occupied it is ignored by the snap controller for attaching drag dropped modules
    public void Occupy(Module module)
    {
        this.IsDisabled = true;
        this.IsOccupied = true;
        this.module = module;
        module.HeldSnappable = this;
        module.Connected = true;

        //Adjust parent to be this node for movement
        module.transform.position = this.transform.position;
        module.transform.SetParent(this.transform);
        
    }

    //Vacate is a methos the releases the held state of a snap point
    public void Vacate(Module module)
    {
        this.IsOccupied = false;
        this.IsDisabled = false;
        module.Connected = false;
        this.module = null;


        //Release this as the parent node
        module.transform.parent = null;
        
    }
}