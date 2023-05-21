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
    
    //The counters for the current equipment list loop
    private int currenctWeaponIndex = 0;
    private int currentShieldIndex = 0;
    private int currentThrusterIndex = 0;


    private void Start() {
        // Initialize the basic properties of the ship
        this.MaxHealth = 3;
        this.Speed = 3;
        this.CurrentHealth = this.MaxHealth;
        this.equippedManagement = GetComponent<EquippedManagement>();
        this.inventoryManagement = GetComponent<InventoryManagement>();
    }

    private void Update() {
        
        Move(); // update movement every frame

        if(Input.GetKeyDown(KeyCode.Alpha1)){
            //Check if 1 has benn pressed, then change to next weapon.
            SwitchToNextEquipment(EquipmentType.Weapon);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SwitchToNextEquipment(EquipmentType.Shield);
        }
          if(Input.GetKeyDown(KeyCode.Alpha3)){
            SwitchToNextEquipment(EquipmentType.Thruster);
        }
   
    }

    public void TakeDamage(float amount){
        //Receive damage values
        this.CurrentHealth -= amount;
        
        if(this.CurrentHealth <= 0 ){
            this.CurrentHealth = 0;
            Destroy(this);
        }
    }

    public void Healing(float amount){
        //Receive the healing value
        this.CurrentHealth += amount;
        if(this.CurrentHealth >= this.MaxHealth){
            this.CurrentHealth = this.MaxHealth;
        }
    }

    private void SwitchToNextEquipment(EquipmentType equipmentType)
    {
        //Get the corresponding type of equipment
        Equipment[] equipmentList = null;

        switch(equipmentType){
                case EquipmentType.Weapon:
                    //Get a list of weapons
                    equipmentList = this.inventoryManagement.GetWeapons();
                    //Determine if the weapon list is empty or not
                    if(equipmentList.Length > 0){
                        //Verify that the current index does not exceed the array length
                        if(currenctWeaponIndex >= equipmentList.Length){
                            currenctWeaponIndex = 0;
                        }else{
                            currenctWeaponIndex += 1;
                        }
                        equippedManagement.Equip(equipmentList[currenctWeaponIndex]);
                    }
                break;
                case EquipmentType.Shield:
                    //Get a list of Shields
                    equipmentList = this.inventoryManagement.GetShields();
                    //Determine if the weapon list is empty or not
                    if(equipmentList.Length > 0){
                        //Verify that the current index does not exceed the array length
                        if(currentShieldIndex >= equipmentList.Length){
                            currentShieldIndex = 0;
                        }else{
                            currentShieldIndex += 1;
                        }
                        equippedManagement.Equip(equipmentList[currenctWeaponIndex]);
                    }
                break;
                case EquipmentType.Thruster:
                    //Get a list of Thrusters
                    equipmentList = this.inventoryManagement.GetThrusters();
                    //Determine if the weapon list is empty or not
                    if(equipmentList.Length > 0){
                        //Verify that the current index does not exceed the array length
                        if(currentThrusterIndex >= equipmentList.Length){
                            currentThrusterIndex = 0;
                        }else{
                            currentThrusterIndex += 1;
                        }
                        equippedManagement.Equip(equipmentList[currenctWeaponIndex]);
                    }
                break;
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

}
