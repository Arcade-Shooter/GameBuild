using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapController : MonoBehaviour
{

    public List<Snappable> snapPoints;
    public List<Module> moduleObjects;
    [SerializeField] public Ship PlayerShip;
    [SerializeField] private Snappable Bin;
    public float snapRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

        //At the start of the game it collect all Snappoints and PlayerDraggable elements and adds them to the lists
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Snappable");
        foreach (GameObject go in gos)
        {
            snapPoints.Add((Snappable) go.GetComponent(typeof(Snappable)));
        }

        this.PlayerShip.AddModuleCallback = AddDraggable;
        this.PlayerShip.RemoveModuleCallback = RemoveDraggable;



        //For each module in the list set it's module callbacks to the correct methods
        foreach (Module module in moduleObjects)
        {
            module.dragEndedCallback = OnDragEnded;
            module.dragStartedCallback = ShowSnaps;
        }

        HideSnaps();
    }


    //For adding draggable modules to the list on ship pickup
    public void AddDraggable(Module module)
    {
        this.moduleObjects.Add(module);
        module.dragEndedCallback = OnDragEnded;
        module.dragStartedCallback = ShowSnaps;
        PlayerShip.ModuleChange();
    }

    public void RemoveDraggable(Module module)
    {
        this.moduleObjects.Remove(module);
        module.dragEndedCallback = null;
        module.dragStartedCallback = null;
    }


    //Small function that sets all snappoints to be visible
    private void ShowSnaps()
    {
        foreach (Snappable snappable in snapPoints) 
        {
            snappable.GetComponent<Renderer>().enabled = true;
        }
    }

    //Small function that sets all snappoints to be invisible
    private void HideSnaps()
    {
        foreach (Snappable snappable in snapPoints)
        {
            snappable.GetComponent<Renderer>().enabled = false;
        }
    }


    //Main method of the snap controller
    //This method is called whenever a dragable module has been dropped
    private void OnDragEnded(Module module)
    {
        float closestDistance = -1;
        Snappable ClosestSnapPoint = null;

        Module draggedModule = module;
        Snappable OriginalSnapPoint = module.HeldSnappable;


        // Find the closest snap point to where it was dropped
        foreach (Snappable snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(module.transform.position, snapPoint.transform.position);
            if ((ClosestSnapPoint == null) || (currentDistance < closestDistance))
            {
                ClosestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        //Check if the closes snap point is in range and if so, occupy it with the given module
        if (ClosestSnapPoint != null && closestDistance <= snapRange)
        {
            if (ClosestSnapPoint == Bin) //If component is dragged onto the bin
            {
                Destroy(module.gameObject);
            }
            else if (ClosestSnapPoint.GetOccupiedState() == false) //If there was no module in the closest snappable, swap to it
            { 
                OriginalSnapPoint.Vacate(draggedModule);
                ClosestSnapPoint.Occupy(draggedModule);
                HideSnaps();
                PlayerShip.ModuleChange();
            }
            else //If already occupied, swap modules
            {
                Module swappingModule = ClosestSnapPoint.GetModule(); //The module that the draged module will swap with

                //If swapping module is a shield, reset it to avoid exploitation
                if (swappingModule.GetClassification() == Classification.Shield)
                {
                    ((Shield)swappingModule).ResetShield();
                }

                //Vacate both snappables
                OriginalSnapPoint.Vacate(draggedModule);
                ClosestSnapPoint.Vacate(swappingModule);
                
                //Occupy both snappables with the opposite modules
                OriginalSnapPoint.Occupy(swappingModule);
                ClosestSnapPoint.Occupy(draggedModule);
                HideSnaps();
                PlayerShip.ModuleChange();
            }
        }
        else {
            //If no snapPoints in range, return to original position;
            OriginalSnapPoint.Occupy(draggedModule);
            HideSnaps();
        }
    }
}
