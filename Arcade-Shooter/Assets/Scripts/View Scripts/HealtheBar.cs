using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtheBar : MonoBehaviour
{
    public static HealtheBar instance;
    private Image[] hearts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        this.hearts = this.GetComponentsInChildren<Image>();
    }

    public void SetHealth(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }


}
