using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private static Ship instance;

    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private Snappable InventorySlot;
    private Snappable[,] ModuleSnapPoints = new Snappable[3, 3];
    [SerializeField] private int CursorPositionX, CursorPositionY;
    [SerializeField] private Transform CursorTransform;
    [SerializeField] private int ThrusterBoost; //An integer
    [SerializeField] private int Speed;
    [SerializeField] private GameObject Bullet;

    //private bool shoot = false;
    private bool getThrusters = false;


    //Because the 2D array cannot be serialized this list is here to hold onto the snap points
    public List<Snappable> snaps;

    void Awake()
    {
        //initialize the player ship
        if (instance == null)
        {
            instance = this;
        }
        this.MaxHealth = 3;
        this.Speed = 3;
        this.Health = 3;

        HealtheBar.instance.SetHealth(this.Health);
        //Get all the snap points
        Snappable[] allSnapPoints = this.transform.GetComponentsInChildren<Snappable>();

        this.snaps.AddRange(allSnapPoints); //Add all the snap points to the list

        int counter = 0;
        for (int i = 0; i < 3; i++) 
        {   //Loop through the 2D array and add the snap points to the array
            for (int n = 0; n < 3; n++)
            {
                this.ModuleSnapPoints[n, i] = this.snaps[counter];
                counter++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        Move();     //update ship position
        MoveCursor();
        UseCursor();
        Shoot();    //update if player shoot
    }


    //Collision controller for the ship
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        
        if (Collision.tag == "EnemyBullet")
        {
            // int damage = Collision.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(1);
            Destroy(Collision.gameObject);
        }
        else if (Collision.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(Collision.gameObject);
        }
        else if (Collision.tag == "UnclaimedModule")
        {
            Debug.Log("Player Module Hit");

            if (!InventorySlot.GetOccupiedState()) //If the inventory is unocupied
            {
                //change the tag
                gameObject.tag = "PlayerModule";
                //InventorySlot.occupy()
                InventorySlot.Occupy(Collision.GetComponent<Equipment>());
            }
        }
    }

    //Ship health damage
    private void TakeDamage(int damage)
    {
        this.Health -= damage;
        HealtheBar.instance.SetHealth(this.Health);
        if (this.Health <= 0)
        {
            OnDestroy();
            this.Health = 0;
        }
    }

    //Ship movement
    private void Move()
    {
        //get keyboard input
        float h = Input.GetAxis("Horizontal");  //"A" "D"
        float v = Input.GetAxis("Vertical");    //"W" "S"

        //the next position is that now position add the new diraction with speed * time.deltaTime.
        Vector3 NextPosition = transform.position + new Vector3(h, v, 0) * (Speed + ThrusterBoost) * Time.deltaTime;

        // Gets the boundaries of the camera
        Bounds cameraBounds = CameraBounds.GetCameraBounds();

        // Get the boundaries of the character by BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        Bounds playerBounds = collider.bounds;

        // Make sure the new position doesn't extend the character's boundaries beyond the camera's boundaries
        float adjustedX = Mathf.Clamp(NextPosition.x, cameraBounds.min.x + playerBounds.extents.x, cameraBounds.max.x - playerBounds.extents.x);
        float adjustedY = Mathf.Clamp(NextPosition.y, cameraBounds.min.y + playerBounds.extents.y, cameraBounds.max.y - playerBounds.extents.y);
        NextPosition = new Vector3(adjustedX, adjustedY, NextPosition.z);


        transform.position = NextPosition;
    }

    //play explosion animation and sound effect when player ship is destroyed  
    private void OnDestroy()
    {
        ShipSoundEffect.instance.PlayExplosionSound();
        Destroy(gameObject);
    }

    private void MoveCursor()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { //Horisontal
            if (CursorPositionX > 0)
            {
                CursorPositionX--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (CursorPositionX < 2)
            {
                CursorPositionX++;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        { //Vertical
            if (CursorPositionY > 0)
            {
                CursorPositionY--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CursorPositionY < 2)
            {
                CursorPositionY++;
            }
        }

        CursorTransform.position = ModuleSnapPoints[CursorPositionX, CursorPositionY].transform.position;// Move cursor box

    }

    private void UseCursor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ModuleSnapPoints[CursorPositionX, CursorPositionY].GetOccupiedState()) //if the cursor position is occupied
            {
                Equipment equipment = ModuleSnapPoints[CursorPositionX, CursorPositionY].GetEquipment();
                ModuleSnapPoints[CursorPositionX, CursorPositionY].Vacate();
                Destroy(equipment.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Equipment equipment = InventorySlot.GetEquipment();

            if (equipment.GetEquipmentType() == EquipmentType.Shield)
            {
                ModuleSnapPoints[1, 1].Occupy(equipment);
            }
            else
            {
            }

            Snappable snapPoint = ModuleSnapPoints[CursorPositionX, CursorPositionY];

            if (snapPoint.GetOccupiedState() == false && snapPoint.GetDisabledState() == false && InventorySlot.GetOccupiedState() == true) //if the cursor position is unocupied and there's one in the inventory
            {

                InventorySlot.Vacate();
                ModuleSnapPoints[CursorPositionX, CursorPositionY].Occupy(equipment);
            }
        }
    }

    //ship shoot
    private void Shoot()
    {
        //check if the "Space" has been pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //play shoot sound effect
            ShipSoundEffect.instance.PlayShootSound();
            //Instantiate a new Bullet object
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(0, 0, 0));   //create new Bullet object at the postion where the ship is.
        }
    }
}
