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

    public delegate void ModuleChangeDelegate();
    public ModuleChangeDelegate ModuleChangeCallback;


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
        ModuleChangeCallback();
    }

    //Vacate is a methos the releases the held state of a snap point
    public void Vacate()
    {
        this.IsOccupied = false;
        this.IsDisabled = false;
        module.Connected = false;
        this.module = null;
        ModuleChangeCallback();
    }

    // Update is called once per frame
    void Update()
    {
        if (module) //If there is a module attached to this snap point move it with the snap point
        {
            module.transform.position = this.transform.position;
        }
    }
}