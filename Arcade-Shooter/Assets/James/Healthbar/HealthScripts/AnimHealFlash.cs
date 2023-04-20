using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimHealFlash : MonoBehaviour
{
    public Color flashColor = Color.white;
    public float interval = 1.0f; //1second
    private Color originalColor;

    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        originalColor = image.color;
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
            image.color = color;
            //wait interval seconds
            yield return new WaitForSeconds(interval);
            //set color back to default
            image.color = originalColor;
            yield return new WaitForSeconds(interval);
        }
    }

}
