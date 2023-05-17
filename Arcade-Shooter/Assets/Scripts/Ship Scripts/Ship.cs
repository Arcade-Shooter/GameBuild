using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private static Ship instance;

 

    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private int ThrusterBoost; //An integer
    [SerializeField] private int Speed;
    [SerializeField] private GameObject Bullet;
    //private bool shoot = false;
    //private bool getThrusters = false;

    //Draggable Module Add and Remove Callbacks
    //These are supplied by the Snap Controller on start so that when the ship picks up a new module it add it to the draggable list
    public delegate void AddModuleDelegate(Module module);
    public AddModuleDelegate AddModuleCallback;

    public delegate void RemoveModuleDelegate(Module module);
    public RemoveModuleDelegate RemoveModuleCallback;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
        Shoot();    //update if player shoot
    }

    //Iterates through all the attached components and if it's a weapon, tries to shoot

    //Goes through all the attached components and if it's a thruster, increments by 1



    //Collision controller for the ship
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.tag == "EnemyBullet")
        {
            int damage = Collision.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(Collision.gameObject);
        }
        else if (Collision.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(Collision.gameObject);
        }
        else if (Collision.tag == "UnclaimedModule")
        {
            Debug.Log("PlauerDraggableHit");

            //Find empty snapPoint

            //If no spaces are available
            //Not implimented so new components don't do anything
        }
    }

    //Ship health damage
    private void TakeDamage(int damage)
    {
        this.Health -= damage;
        if (this.Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //Ship movement
    private void Move()
    {

        //get keyboard input
        float h = Input.GetAxis("Horizontal");  //"A" "D" "left" "right"
        float v = Input.GetAxis("Vertical");    //"W" "S" "up" "down"

        //the next position is that now position add the new diraction with speed * time.deltaTime.
        Vector3 NextPosition = transform.position + new Vector3(h, v, 0) * (Speed + ThrusterBoost) * Time.deltaTime ;

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
