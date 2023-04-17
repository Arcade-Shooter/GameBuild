using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    enum ProjectileType
    {
        Bullet,
        EnergyBullet,
        Missile,
        Lazer
    }

    [SerializeField] private string ProjectileName;
    [SerializeField] private ProjectileType Type;
    [SerializeField] private int Damage;
    [SerializeField] private float Speed;
    [SerializeField] private bool Paused;
    [SerializeField] private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Paused)
        {
            transform.position += (Vector3.up * this.Speed) * Time.deltaTime;

            if (transform.position.y > 5.5)
            {
                Destroy(gameObject);
            }
        }
    }

    public int GetDamage()
    {
        return Damage;
    }
}
