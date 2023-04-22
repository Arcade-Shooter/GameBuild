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
    protected bool PauseState;
    protected bool Disabled;
    public bool Connected;



    protected Module(int Health, int Power, Classification classification)
    {
        this.Health = Health;
        this.MaxHealth = Health;
        this.Power = Power;
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

    public void HealDamage(int Damage)
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

    public Classification GetClassification()
    {
        return this.classification;
    }


    private void OnTriggerEnter2D(Collider2D projectile)
    {
        if (projectile.tag == "Enemy")
        {
            int damage = projectile.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(projectile.gameObject);
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
