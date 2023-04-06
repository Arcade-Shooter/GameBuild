using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{


    [SerializeField] private int ShipHP;
    [SerializeField] private List<Snappable> SnapPoints; 
    [SerializeField] private int ThrusterBoost; //An integer

    
    
    







    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireWeapons()
    {
        foreach (Snappable snappable in SnapPoints)
        {
            Module module = snappable.GetModule();
            if ( module != null)
            {
                module.FireWeapons();
            }
        }
    }

    private int DetectThrusters()
    {
        int thrusters = 0;
        foreach (Snappable snappable in SnapPoints)
        {
            Module module = snappable.GetModule();
            if (module != null)
            {
                thrusters += module.DetectThrusters();
            }
        }

        return thrusters;

    }
}
