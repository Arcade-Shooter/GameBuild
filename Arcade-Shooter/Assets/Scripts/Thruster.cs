using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : Module
{

    private int SpeedIncrease;

    public Thruster(int Health, int Power, int Speed)
        : base(Health, Power, Classification.Thruster)
    {
        this.SpeedIncrease = Speed;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetIncrease()
    {
        return 0;
    }
}
