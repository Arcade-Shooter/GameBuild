using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipCtrl : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int Speed; 
    
    [SerializeField] private int Health;
    [SerializeField] private GameObject Bullet;

    protected ShipCtrl()
    {
        this.MaxHealth = 3;
        this.Speed = 3;
    }
    protected ShipCtrl(int health, int maxHealth, int speed, GameObject bullet) : this()
    {
        this.Bullet = bullet;
        this.Health = health;
    }

    public void Move()
    {
        //get keyboard input
        float h = Input.GetAxis("Horizontal");  //"A" "D" "left" "right"
        float v = Input.GetAxis("Vertical");    //"W" "S" "up" "down"

        //the next position is that now position add the new diraction with speed * time.deltaTime.
        Vector3 NextPosition = transform.position + new Vector3(h, v, 0) * Speed * Time.deltaTime;

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
    abstract public void fire();

}
