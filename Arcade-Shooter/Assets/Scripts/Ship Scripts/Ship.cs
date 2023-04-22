using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{


    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private List<Snappable> SnapPoints; 
    [SerializeField] private int ThrusterBoost; //An integer
    [SerializeField] private bool shoot = false;
    [SerializeField] private bool getThrusters = false;
    
    
    







    // Start is called before the first frame update
    void Start()
    {
        
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
}
