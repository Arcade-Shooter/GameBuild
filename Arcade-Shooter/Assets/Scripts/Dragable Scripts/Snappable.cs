using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Module;

public class Snappable : MonoBehaviour
{

    [SerializeField] private bool IsDisabled;
    [SerializeField] private bool IsOccupied;
    [SerializeField] private Module module;

    public bool GetDisabledState()
    {
        return IsDisabled;
    }

    public bool GetOccupiedState()
    {
        return IsOccupied;
    }

    public void Occupy(Module module)
    {
        this.IsDisabled = true;
        this.IsOccupied = true;
        this.module = module;
        module.dragStartedCallback = Vacate;
    }


    private void Vacate()
    {
        this.IsOccupied = false;
        this.IsDisabled = false;
        module.dragStartedCallback = null;
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
