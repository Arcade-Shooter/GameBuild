using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Module;

public class Snappable : MonoBehaviour, IComparable<Snappable> 
{
    [SerializeField] private SnappableOrientation orientation;
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

    public SnappableOrientation GetOrientation()
    {
        return this.orientation;
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

        if(this.orientation == SnappableOrientation.L)
        {
            module.DisableSnapNode(SnappableOrientation.R);
        }else if (this.orientation == SnappableOrientation.R)
        {
            module.DisableSnapNode(SnappableOrientation.L);
        }else if (this.orientation == SnappableOrientation.T)
        {
            module.DisableSnapNode(SnappableOrientation.B);
        }
        else if (this.orientation == SnappableOrientation.B)
        {
            module.DisableSnapNode(SnappableOrientation.T);
        }
    }


    public void Vacate()
    {
        this.IsOccupied = false;
        this.IsDisabled = false;
        module.dragStartedCallback = null;

        if (this.orientation == SnappableOrientation.L)
        {
            module.EnableSnapNode(SnappableOrientation.R);
        }
        else if (this.orientation == SnappableOrientation.R)
        {
            module.EnableSnapNode(SnappableOrientation.L);
        }
        else if (this.orientation == SnappableOrientation.T)
        {
            module.EnableSnapNode(SnappableOrientation.B);
        }
        else if (this.orientation == SnappableOrientation.B)
        {
            module.EnableSnapNode(SnappableOrientation.T);
        }

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

    public int CompareTo(Snappable other)
    {
        return this.orientation.CompareTo(other.orientation);
    }
}

public enum SnappableOrientation
{
    L,
    R,
    T,
    B
}