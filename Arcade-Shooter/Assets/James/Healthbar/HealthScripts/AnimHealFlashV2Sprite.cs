using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimHealFlashV2Sprite : MonoBehaviour
{
    public Color flashColor = Color.white;
    public float interval = 1.0f; //1second
    private Color originalColor;

    private Image healthOutlineImage;

    private void Start()
    {
        healthOutlineImage = this.GetComponent<Image>();
        Debug.Log("Health Outline Image:",healthOutlineImage);
        originalColor = healthOutlineImage.color;
    }

    /**THE BASIC COMMAND*/
    public void HealFlash()
    {
        StartCoroutine(FlashWhite(1, flashColor));
    }
    /**FLASH FOR SET AMOUNT OF TIMES*/
    public void HealFlash(int repeatTimes)
    {
        StartCoroutine(FlashWhite(repeatTimes, flashColor));
    }
    /**THE ADVANCED COMMAND INCLUDING COLOR INFO*/
    public void HealFlash(int repeatTimes, Color flash_color)
    {
        StartCoroutine(FlashWhite(repeatTimes, flash_color));
    }
    private IEnumerator FlashWhite(int times, Color color)
    {
        for(int i=0;i<times;i++)
        {
            //set color
            healthOutlineImage.color = color;
            //wait interval seconds
            yield return new WaitForSeconds(interval);
            //set color back to default
            healthOutlineImage.color = originalColor;
            yield return new WaitForSeconds(interval);
        }
    }

}
