using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    enum ProjectileType
    {
        Bullet,
        EnergyBullet,
        Lazer
    }

    private string ProjectileName;
    private ProjectileType Type;
    private int Damage;
    private float Speed;
    private bool Paused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
