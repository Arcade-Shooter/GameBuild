using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{


    
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int Power;
    [SerializeField] private int MaxPower;
    private Classification classification;
    private bool PauseState;
    private bool Disabled;
    [SerializeField] protected List<Snappable> SnapPoints;



    protected Module(int Health, int Power, Classification classification)
    {
        this.Health = Health;
        this.MaxHealth = Health;
        this.Power = Power;
        this.MaxPower = Power;
        this.classification = classification;
        this.PauseState = false;
        this.Disabled = false;
    }
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamadge(int Damage)
    {
        this.Health -= Damage;
        if(this.Health <= 0.1*this.MaxHealth) //Disable if lower then n% health
        {
            this.Disabled = true;
        }
    }

    public void HealDamadge(int Damage)
    {
        this.Health += Damage;
        if (this.Health <= 0.1 * this.MaxHealth) //Disable if lower then n% health
        {
            this.Disabled = true;
        }
    }

    public void IncreasePower(int Power)
    {
        this.Power += Power;
    }

    public void DecreasePower(int Power)
    {
        this.Power -= Power;
    }

    public void Enable()
    {
        this.Disabled = false;
    }

    public void Disable()
    {
        this.Disabled = true;
    }




    /******************************************
     This Section is for the dragable functionality
    ******************************************/




    // Delegate for snapping to a Snappable point and occupying it
    public delegate void DragEndedDelegate(Module module);
    public DragEndedDelegate dragEndedCallback;

    // Delegate for releasing a Snappable point
    public delegate void DragStartedDelegate();
    public DragStartedDelegate dragStartedCallback;

    public List<Snappable> HeldSnappables;


    [SerializeField] private bool isDraggable = true;
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    [SerializeField]  private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer2;

    private void OnMouseDown()
    {
        if (HeldSnappables.Count != 0)
        {
            foreach (Snappable heldSnappable in  HeldSnappables)
            {
                heldSnappable.Vacate();
            }
            HeldSnappables.Clear();
        }

        foreach (Snappable child in SnapPoints)
        {
            if (child.GetModule() != null)
            {
                isDraggable = false;
                break;
            }
            else
            {
                isDraggable = true;
            }
        }

        if (isDraggable == true) 
        {
            isDragged = true;
            spriteRenderer.sortingOrder = 5;
            spriteRenderer2.sortingOrder = 6;
            
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.localPosition;
        } 
    }

    private void OnMouseDrag()
    {
        if (isDraggable == true)
        {
            transform.localPosition = spriteDragStartPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isDraggable == true) {
            isDragged = false;
            spriteRenderer.sortingOrder = 0;
            spriteRenderer2.sortingOrder = 1;
            dragEndedCallback(this);
        }
    }

    public void DisableSnapNode(SnappableOrientation orientation)
    {
        foreach (Snappable snap in SnapPoints)
        {
            if (snap.GetOrientation() == orientation) 
            {
                snap.Disable();
            }
        }
    }

    public void EnableSnapNode(SnappableOrientation orientation)
    {
        foreach (Snappable snap in SnapPoints)
        {
            if (snap.GetOrientation() == orientation)
            {
                snap.Enable();
            }
        }
    }

    public abstract void FireWeapons();

    internal int DetectThrusters()
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
        if (this.classification == Classification.Thruster)
        {
            return thrusters++;
        }
        return thrusters;
    }
}

public enum Classification
{
    Weapon,
    Shield,
    Thruster
}
