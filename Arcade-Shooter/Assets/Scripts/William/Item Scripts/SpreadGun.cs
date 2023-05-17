using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadGun : WeaponType
{
    //[SerializeField] private int BulletNum = 3;
    //[SerializeField] private float BulletAngle;
    [SerializeField] private GameObject Bullet;
    private List<Vector3> Directions;
    public SpreadGun( ) 
        : base("Spread Gun", "This gun shoot 3 bullets spreadly",60 , 10, 100, 3)
    {
        
    }

    private void Update()
    {
        fire();
    }

    public override void fire()
    {
        Directions.Add(new Vector3(0, -15, 0));
        Directions.Add(new Vector3(0, 0, 0));
        Directions.Add(new Vector3(0, 15, 0));

        //foreach (Vector3 i in Directions)
        //{
        //    Instantiate(Bullet,new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.Euler(i));

        //}

        for (int i = 0; i < Directions.Count; i++)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.Euler(Directions[i]));

        }
    }



    public override void useItem(GameObject player)
    {
    }

}
