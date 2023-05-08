using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
    [SerializeField] private float bearing;

    private void Start()
    {
        transform.Rotate(0, 0, -bearing);
        Rigidbody2D rigid = this.gameObject.GetComponent<Rigidbody2D>();
        rigid.AddForce(rigid.transform.up * Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Paused)
        {
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
