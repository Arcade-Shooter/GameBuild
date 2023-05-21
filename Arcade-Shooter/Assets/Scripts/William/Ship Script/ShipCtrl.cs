using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Speed;
    [SerializeField] private float CurrentHealth;

    private EquippedManagement equippedManagement;
    private InventoryManagement inventoryManagement;
    private CollisionSystem collisionSystem;

    private void Start()
    {
        // Initialize the basic properties of the ship
        this.MaxHealth = 3;
        this.Speed = 3;
        this.CurrentHealth = this.MaxHealth;
        this.equippedManagement = GetComponent<EquippedManagement>();
        this.equippedManagement.gameObject.SetActive(true);
        if (this.equippedManagement == null)
        {
            Debug.LogError("EquippedManagement is null");
        }
        this.inventoryManagement = GetComponent<InventoryManagement>();
        this.inventoryManagement.gameObject.SetActive(true);
        if (this.inventoryManagement == null)
        {
            Debug.LogError("inventoryManagement is null");
        }
        this.collisionSystem = GetComponent<CollisionSystem>();
        this.collisionSystem.gameObject.SetActive(true);

        if (collisionSystem == null)
        {
            Debug.LogError("No CollisionSystem found in the scene!");
        }
    }

    private void Update()
    {

        Move(); // update movement every frame

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Check if 1 has benn pressed, then change to next weapon.
            this.equippedManagement.SwitchToNextEquipment(EquipmentType.Weapon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.equippedManagement.SwitchToNextEquipment(EquipmentType.Shield);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.equippedManagement.SwitchToNextEquipment(EquipmentType.Thruster);
        }

    }

    public void TakeDamage(float amount)
    {
        //Receive damage values
        this.CurrentHealth -= amount;

        if (this.CurrentHealth <= 0)
        {
            this.CurrentHealth = 0;
            Destroy(this);
        }
    }

    public void Healing(float amount)
    {
        //Receive the healing value
        this.CurrentHealth += amount;
        if (this.CurrentHealth >= this.MaxHealth)
        {
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
         * if the camera position has been moved, then the value MUST be changed!
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();

            if (bullet != null)
            {
                TakeDamage(1);
            }
        }

        if (collision.CompareTag("Equipment"))
        {   
            Debug.Log("collision with Equipment");
            Equipment equipment = collision.GetComponent<Equipment>();

            if (equipment != null)
            {
                this.collisionSystem.HandleCollision(this, equipment);
            }
        }
    }

    public EquippedManagement GetEquippedManagement()
    {
        return this.equippedManagement;
    }
}
