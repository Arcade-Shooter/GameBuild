using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldLayer : MonoBehaviour
{
    //Callback supplied by it's parent shield module
    //This callback is for the shield damadge method
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

    //Collision controller for the shield layers
    private void OnTriggerEnter2D(Collider2D projectile)
    {
        if (projectile.tag == "EnemyBullet") {
            Debug.Log(this.name + " has collision with" + projectile.tag);
            // int damage = projectile.gameObject.GetComponent<Projectile>().GetDamage();
            // CollisionCallBack(damage);
            // Destroy(projectile.gameObject);
        }else if (projectile.tag == "Enemy")
        {
            CollisionCallBack(1);
        }
    }
}
