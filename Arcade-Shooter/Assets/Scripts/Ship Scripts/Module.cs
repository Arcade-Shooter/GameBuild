using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{

    //Module classifications
    public enum Classification 
    {
        equipment,
        droppedItem
    }


    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private Classification classification;



    //Method to return the Classification of the module
    public Classification GetClassification()
    {
        return this.classification;
    }



}
