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
    //private bool getThrusters = false;


    //Because the 2D array cannot be serialized this list is here to hold onto the snap points
    public List<Snappable> snaps;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        this.MaxHealth = 3;
        this.Speed = 3;
        this.Health = this.MaxHealth;

          //Initialise the 2D array |||HARD CODED|||
        ModuleSnapPoints[0, 0] = snaps[0];
        ModuleSnapPoints[1, 0] = snaps[1];
        ModuleSnapPoints[2, 0] = snaps[2];
        ModuleSnapPoints[0, 1] = snaps[3];
        ModuleSnapPoints[1, 1] = snaps[4];
        ModuleSnapPoints[2, 1] = snaps[5];
        ModuleSnapPoints[0, 2] = snaps[6];
        ModuleSnapPoints[1, 2] = snaps[7];
        ModuleSnapPoints[2, 2] = snaps[8];
        Debug.Log(ModuleSnapPoints);
    }

    //Called at the start
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        //if (shoot)
        //{
        //    FireWeapons();
        //    //shoot = false;
        //}

        //if (getThrusters)
        //{
        //    DetectThrusters();
        //    //getThrusters = false;
        //}

        Move();     //update ship position
        MoveCursor();
        UseCursor();
        Shoot();    //update if player shoot
    }

    //Iterates through all the attached components and if it's a weapon, tries to shoot
    // public void FireWeapons()
    // {
    //     foreach (Snappable snappable in ModuleSnapPoints)
    //     {
    //         Equipment equipment = snappable.GetEquipment();
    //         if (equipment != null && equipment.GetEquipmentType() == EquipmentType.Weapon)
    //         {
    //             equipment.FireWeapon(); //Transform module into a weapon and shoot it
    //         }
    //     }
    // }

    //Goes through all the attached components and if it's a thruster, increments by 1
    private int DetectThrusters()
    {
        int thrusters = 0;
        foreach (Snappable snappable in ModuleSnapPoints)
        {
            Equipment equipment = snappable.GetEquipment();
            if (equipment != null)
            {
                if (equipment.GetEquipmentType() == EquipmentType.Thruster)
                {
                    thrusters++;
                }
            }
        }
        Debug.Log("" + thrusters);
        return thrusters;
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
                Collision.gameObject.tag = "PlayerModule";
                //InventorySlot.occupy()
                InventorySlot.Occupy(Collision.GetComponent<Equipment>());
            }
            //else do nothing
        }
    }

    //Ship health damage
    private void TakeDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
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

        /*
         * the boarder are setted by camera range, and this is NOT a dynamic value,
         * if the camera has been moved, then the value MUST be changed!
         */

        //check the x of next postion stil in the range of caremra
        if (NextPosition.x > 8.0f || NextPosition.x < -8.0f)
        {
            NextPosition.x = transform.position.x;
        }

        //check the y of next postion stil in the range of caremra
        if (NextPosition.y > 4.4f || NextPosition.y < -4.4f)
        {
            NextPosition.y = transform.position.y;
        }

        transform.position = NextPosition;
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
            Snappable snapPoint = ModuleSnapPoints[CursorPositionX, CursorPositionY];
            if (snapPoint.GetOccupiedState() == false && snapPoint.GetDisabledState() == false && InventorySlot.GetOccupiedState() == true) //if the cursor position is unocupied and there's one in the inventory
            {
                Equipment equipment = InventorySlot.GetEquipment();
                InventorySlot.Vacate();
                ModuleSnapPoints[CursorPositionX, CursorPositionY].Occupy(equipment);
            }
        }
    }

    //ship shoot
    private void Shoot()
    {
        //check if the "Space" has been pressed
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(0, 0, 0));   //create new Bullet object at the postion where the ship is.
            //print("Space key has been pressed");
            //shoot = true;

        }
    }

    //Module Change callback method
    //This is called by the SnapController when a change has occured with the draggable modules
    public void ModuleChange()
    {
        ThrusterBoost = DetectThrusters(); //When modules change check if the number of thrusters has changed
    }

    public static Ship GetInstance()
    {
        return instance;
    }

    private static void SetInstance(Ship ship)
    {
        instance = ship;
    }
}
