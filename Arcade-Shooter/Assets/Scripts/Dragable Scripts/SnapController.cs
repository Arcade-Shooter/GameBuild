using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{

    public List<Snappable> snapPoints;
    public List<Module> moduleObjects;
    public float snapRange = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Module module in moduleObjects)
        {
            module.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(Module module)
    {
        float closestDistance = -1;
        Snappable ClosestSnapPoint = null;

        foreach (Snappable snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(module.transform.position, snapPoint.transform.position);
            if ((ClosestSnapPoint == null && snapPoint.GetDisabledState() == false)|| (currentDistance < closestDistance && snapPoint.GetDisabledState() == false))
            {
                ClosestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }


        if (ClosestSnapPoint != null && closestDistance <= snapRange) 
        {
            module.transform.position = ClosestSnapPoint.transform.position;
            ClosestSnapPoint.Occupy(module);
        }
    }
}
