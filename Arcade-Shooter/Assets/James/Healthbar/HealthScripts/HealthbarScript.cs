using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("123abc");
    }
    [SerializeField] Image healthbarImage;

    [SerializeField] Player player;
    //healthbar maxHealth = 3
    //int health = maxHealth

    //when btn clicked, change healthbar by -1

    public void UpdateHealthBar()
    {
        healthbarImage.fillAmount = Mathf.Clamp(player.health / player.maxHealth, 0, 1f);
    }

}
