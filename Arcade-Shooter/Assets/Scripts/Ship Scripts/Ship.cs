using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{


    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private List<Snappable> SnapPoints; 
    [SerializeField] private int ThrusterBoost; //An integer
    [SerializeField] private int Speed;
    private bool shoot = false;
    private bool getThrusters = false;
    
    
    







    // Start is called before the first frame update
    void Start()
    {
        foreach (var snappable in SnapPoints)
        {
            snappable.ModuleChangeCallback = ModuleChange;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            FireWeapons();
            shoot = false;
        }

        if (getThrusters)
        {
            DetectThrusters();
            getThrusters = false;
        }

        Move();     //update ship position
        Shoot();    //update if player shoot
    }

    public void FireWeapons()
    {
        foreach (Snappable snappable in SnapPoints)
        {
            Module module = snappable.GetModule();
            if ( module != null && module.GetClassification() == Classification.Weapon)
            {
                ((Weapon)module).FireWeapon(); //Transform module into a weapon and shoot it
            }
        }
    }

    private int DetectThrusters()
    {
        int thrusters = 0;
        foreach (Snappable snappable in SnapPoints)
        {
            Module module = snappable.GetModule();
            if (module != null)
            {
                if (module.IsThruster())
                {
                    thrusters++;
                }
            }
        }

        Debug.Log("" + thrusters);
        return thrusters;

    }


    private void OnTriggerEnter2D(Collider2D projectile)
    {
        if (projectile.tag == "EnemyBullet")
        {
            int damage = projectile.gameObject.GetComponent<Projectile>().GetDamage();
            this.TakeDamage(damage);
            Destroy(projectile.gameObject);
        }
        else if (projectile.tag == "Enemy")
        {
            this.TakeDamage(1);
            Destroy(projectile.gameObject);
        }
    }

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print("Space key has been pressed");
            shoot = true;

        }
    }

    //Module Change
    private void ModuleChange()
    {
        ThrusterBoost = DetectThrusters(); //When modules change check if the number of thrusters has changed
    }
}
