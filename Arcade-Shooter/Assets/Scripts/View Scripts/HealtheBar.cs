using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtheBar : MonoBehaviour
{
    public static HealtheBar instance;  //Instance of the health bar
    private Image[] hearts; //Array of the hearts

    private void Awake()
    {   //Initialize the health bar

        //initialize instance
        instance = this.gameObject.GetComponent<HealtheBar>();
        this.hearts = this.GetComponentsInChildren<Image>();
    }

    public void SetHealth(int health)
    {   //Set the health of the player
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
        Debug.Log("Set health to: " + health);
    }
}
