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




    public void Occupy(Module module)
    {
        this.IsDisabled = true;
        this.IsOccupied = true;
        this.module = module;
    }


    public void Vacate()
    {
        this.IsOccupied = false;
        this.IsDisabled = false;
        this.module = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (module)
        {
            module.transform.position = this.transform.position;
        }
    }
}