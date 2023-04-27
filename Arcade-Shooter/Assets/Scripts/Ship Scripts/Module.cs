using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{



    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    private int Power; // Not Implimented
    [SerializeField] private Classification classification;
    protected bool Paused;
    protected bool Disabled;
    public bool Connected;


    public void TakeDamage(int Damage) //Method for reducing health amount
    {
        this.Health -= Damage;
        if (this.Health <= 0) //Destroy if health is zero
        {
            Destroy(this.gameObject);
        }
    }

    public void HealDamage(int Damage) //Heal is never called but is available as an option
    {
        this.Health += Damage;
        if (this.Health <= 0.1 * this.MaxHealth) //Disable if lower then n% health
        {
            this.Disabled = true;
        }
    }

    //Changing Power level by increments
    public void IncreasePower(int Power)
    {
        this.Power += Power;
    }

    public void DecreasePower(int Power)
    {
        this.Power -= Power;
    }

    //Changing Disabled state
    public void Enable()
    {
        this.Disabled = false;
    }

    public void Disable()
    {
        this.Disabled = true;
    }

    //Classification getter
    public Classification GetClassification()
    {
        return this.classification;
    }

    //Collision function for 
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag == "Enemy")
        {
            int damage = Collision.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(Collision.gameObject);
        }
    }

    /******************************************
     This Section is for the dragable functionality
    ******************************************/

    // Delegate for snapping to a Snappable point and occupying it
    public delegate void DragEndedDelegate(Module module);
    public DragEndedDelegate dragEndedCallback;

    public delegate void DragStartedDelegate();
    public DragStartedDelegate dragStartedCallback;

    public Snappable HeldSnappable;


    [SerializeField] private bool isDraggable = true;
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRenderer2;

    private void OnMouseDown()
    {
        if (HeldSnappable)
        {
            HeldSnappable.Vacate();
            HeldSnappable = null;
        }

        if (isDraggable == true)
        {
            dragStartedCallback();
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
        if (isDraggable == true)
        {
            isDragged = false;
            spriteRenderer.sortingOrder = 0;
            spriteRenderer2.sortingOrder = 1;
            dragEndedCallback(this);
        }
    }

    internal bool IsThruster()
    {
        return this.classification == Classification.Thruster;
    }
}

public enum Classification
{
    Weapon,
    Shield,
    Thruster
}
