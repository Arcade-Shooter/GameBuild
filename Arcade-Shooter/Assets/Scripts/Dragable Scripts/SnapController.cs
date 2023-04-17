using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnapController : MonoBehaviour
{

    public List<Snappable> snapPoints;
    public List<Module> moduleObjects;
    public float snapRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Snappable");
        foreach (GameObject go in gos)
        {
            snapPoints.Add((Snappable) go.GetComponent(typeof(Snappable)));
        }

        gos = GameObject.FindGameObjectsWithTag("PlayerDraggable");
        foreach (GameObject go in gos)
        {
            moduleObjects.Add((Module)go.GetComponent(typeof(Module)));
        }

        foreach (Module module in moduleObjects)
        {
            module.dragEndedCallback = OnDragEnded;
            module.dragStartedCallback = ShowSnaps;
        }
    }

    private void ShowSnaps()
    {
        foreach (Snappable snappable in snapPoints) 
        {
            snappable.GetComponent<Renderer>().enabled = true;
        }
    }

    private void HideSnaps()
    {
        foreach (Snappable snappable in snapPoints)
        {
            snappable.GetComponent<Renderer>().enabled = false;
        }
    }

    private void OnDragEnded(Module module)
    {
        float closestDistance = -1;
        Snappable ClosestSnapPoint = null;


        // Find the closest snap point
        foreach (Snappable snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(module.transform.position, snapPoint.transform.position);
            if ((ClosestSnapPoint == null && snapPoint.GetDisabledState() == false) || (currentDistance < closestDistance && snapPoint.GetDisabledState() == false))
            {
                ClosestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if (ClosestSnapPoint != null && closestDistance <= snapRange)
        {
            module.transform.position = ClosestSnapPoint.transform.position;
            ClosestSnapPoint.Occupy(module);
            module.HeldSnappable = ClosestSnapPoint;
            module.Connected = true;
        }

        HideSnaps();
    }
}
