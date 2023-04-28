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


    //Method for taking damage
    public void TakeDamage(int Damage)
    {
        this.Health -= Damage;
        if (this.Health <= 0.1 * this.MaxHealth) //Disable if lower then n% health
        {
            this.Disabled = true;
        }
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Method for healing damage
    public void HealDamage(int Damage)
    {
        this.Health += Damage;
        if (this.Health <= 0.1 * this.MaxHealth) //Disable if lower then n% health
        {
            this.Disabled = true;
        }
    }

    //Methods for adjusting power
    public void IncreasePower(int Power)
    {
        this.Power += Power;
    }

    public void DecreasePower(int Power)
    {
        this.Power -= Power;
    }

    //Methods for toggling disabled state
    public void Enable()
    {
        this.Disabled = false;
    }

    public void Disable()
    {
        this.Disabled = true;
    }

    //Method to return the Classification of the module
    public Classification GetClassification()
    {
        return this.classification;
    }

    //Method to control Collisions with modules
    private void OnTriggerEnter2D(Collider2D Collsion)
    {
        if (Collsion.tag == "EnemyBullet")
        {
            int damage = Collsion.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(Collsion.gameObject);
        }
        else if (Collsion.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(Collsion.gameObject);
        }
    }

    /******************************************
     This Section is for the dragable functionality
    ******************************************/

    //This is a callback method supplied by Snappable Controller
    //This callback gets the snappable controller to check for the cloases snap point and if it's within the range occupy that module
    public delegate void DragEndedDelegate(Module module);
    public DragEndedDelegate dragEndedCallback;


    //This callback is Method is supplied by Snappable Controller
    //This callback is only here to show the snappoints when a module start being dragged
    public delegate void DragStartedDelegate();
    public DragStartedDelegate dragStartedCallback;

    public Snappable HeldSnappable; //If the module is attatched it has a reverence to the snap point it ocupys 

    //Dragabke variables
    [SerializeField] private bool isDraggable = true;
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    //Sprite renderers to increase the draw height of the modules components so when dragged they are visible over ship components rather than behind
    [SerializeField] private SpriteRenderer Square;
    [SerializeField] private List<SpriteRenderer> Decoration;

    private void OnMouseDown()
    {
        if (HeldSnappable) //If this module occupys a snap point, vacate it
        {
            HeldSnappable.Vacate(this);
        }

        if (isDraggable == true) //Show nodes, increase draw height, collect starting positions
        {
            dragStartedCallback();
            isDragged = true;
            Square.sortingOrder = 5;
            foreach (SpriteRenderer sprite in Decoration)
            {
                sprite.sortingOrder = 6;
            }
            

            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.localPosition;
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable == true) //Draw module at mouse position, offset by the difference in starting postion (Makes it look more natural)
        {
            transform.localPosition = spriteDragStartPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isDraggable == true) //set draw order back to original, call the snap comtroller method to check for nearby snap points
        {
            isDragged = false;
            Square.sortingOrder = 0;
            foreach (SpriteRenderer sprite in Decoration)
            {
                sprite.sortingOrder = 1;
            }
            dragEndedCallback(this);
        }
    }

    internal bool IsThruster() //Simple method used in detect thrusters
    {
        return this.classification == Classification.Thruster;
    }


    //Setters for the modules drag controls
    public void EnableDrag()
    {
        this.isDraggable = true;
    }

    public void DisableDrag()
    {
        this.isDraggable = false;
    }
}

//Module classifications
public enum Classification 
{
    Weapon,
    Shield,
    Thruster
}
