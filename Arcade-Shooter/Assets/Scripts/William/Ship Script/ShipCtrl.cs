using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : MonoBehaviour
{
    [SerializeField] private float MaxHealth;   
    [SerializeField] private float Speed; 
    [SerializeField] private float CurrentHealth;

    [SerializeField] private List<Equipment> equippedItem = new List<Equipment>();

    protected ShipCtrl()
    {

    }

    void Awake() {
        this.MaxHealth = 3;
        this.Speed = 3;
        this.CurrentHealth = this.MaxHealth;
    }

    void Update() {
        Move();
    }

    public void TakeDamage(float amount){

        this.CurrentHealth -= amount;
        
        if(this.CurrentHealth <= 0 ){
            this.CurrentHealth = 0;
            Destroy(this);
        }
    }

    public void Healing(float amount){
        this.CurrentHealth += amount;
        if(this.CurrentHealth >= this.MaxHealth){
            this.CurrentHealth = this.MaxHealth;
        }
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


}
