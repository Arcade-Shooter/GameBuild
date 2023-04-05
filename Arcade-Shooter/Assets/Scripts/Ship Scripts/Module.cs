using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Module : MonoBehaviour
{

    

    private int Healh;
    private int MaxHealth;
    private int Power;
    private int MaxPower;
    private Classification classification;
    private bool PauseState;
    private bool Disabled;
    [SerializeField] private List<Snappable> snappables;



    protected Module(int Health, int Power, Classification classification)
    {
        this.Healh = Health;
        this.MaxHealth = Healh;
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

    }

    public void HealDamadge(int Damage)
    {

    }

    public void IncreasePower(int Power)
    {

    }

    public void DecreasePower(int Power)
    {

    }

    public void Enable()
    {

    }

    public void Disable()
    {

    }








    // Delegate for snapping to a Snappable point and occupying it
    public delegate void DragEndedDelegate(Module module);
    public DragEndedDelegate dragEndedCallback;

    // Delegate for releasing a Snappable point
    public delegate void DragStartedDelegate();
    public DragStartedDelegate dragStartedCallback;

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private void OnMouseDown()
    {
        if (dragStartedCallback != null) 
        {
            dragStartedCallback();
        }

        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallback(this);
    }


}

public enum Classification
{
    Weapon,
    Shield,
    Thruster
}
