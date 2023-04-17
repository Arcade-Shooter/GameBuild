using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLayer : MonoBehaviour
{

    public delegate void CollisionDelegate(int damadge);
    public CollisionDelegate CollisionCallBack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D projectile)
    {
        //projectile.GameObject.GetComponent<Projectile>().GetDamage();
        //Collision();
    }
}
