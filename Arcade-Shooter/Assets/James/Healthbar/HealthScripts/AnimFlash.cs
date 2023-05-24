using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/**
ALL WE HAVE TO DO IS CHANGE IMAGE TO SPRITE RENDERER
and it will *all work magically*


(oh also this is the replacement for AnimHealFlashV2Sprite.cs as that stuff was getting nightmarish
[it broke my Healthbar script HealthbarV8AnimHealFlashNameChanged.cs]
im just not used to github, so ive always done versioning in this awkward way
but the main thing is that it probably works now.
yay
)

*/
public class AnimFlash : MonoBehaviour
{
    public Color flashColor = Color.white;
    public float interval = 0.2f; // 0.2 seconds sounds like a good default
    private Color originalColor;

    //private Image healthOutlineImage;
    //SPRITERENDERER 1
    private SpriteRenderer healthOutlineSprite;

    private void Start()
    {
        //healthOutlineImage = this.GetComponent<Image>();
        //originalColor = healthOutlineImage.color;
        //SPRITERENDERER 2
        healthOutlineSprite = this.GetComponent<SpriteRenderer>();

        originalColor = healthOutlineSprite.color;
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
        for (int i = 0; i < times; i++)
        {
            //set color
            //healthOutlineImage.color = color;
            //SPRITERENDERER 3
            healthOutlineSprite.color = color;

            //wait interval seconds
            yield return new WaitForSeconds(interval);
            //set color back to default

            //healthOutlineImage.color = originalColor;
            //SPRITERENDERER 4 (last one)
            healthOutlineSprite.color = originalColor;


            yield return new WaitForSeconds(interval);
        }
    }

}
