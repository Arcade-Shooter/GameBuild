/**
 * When I changed the name of my AnimHealFlash.cs script to AnimHealFlashV2Sprite.cs
 * it caused a major headache in coding as my Healthbar script didnt like it, 
 * so for now im just gonna use the original AnimHealFlash.cs script,
 * and comment out all this code and im praying unity wont complain.
 * Will probably delete this later
 * */
using UnityEngine;
public class AnimHealFlashV2Sprite : MonoBehaviour { }




//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


///**
//ALL WE HAVE TO DO IS CHANGE IMAGE TO SPRITE RENDERER
//and it will *all work magically*

//*/
//public class AnimHealFlashV2Sprite : MonoBehaviour
//{
//    public Color flashColor = Color.white;
//    public float interval = 1.0f; //1second
//    private Color originalColor;

//    //private Image healthOutlineImage;
//    //SPRITERENDERER 1
//    private SpriteRenderer healthOutlineSprite;

//    private void Start()
//    {
//        //healthOutlineImage = this.GetComponent<Image>();
//        //originalColor = healthOutlineImage.color;
//        //SPRITERENDERER 2
//        healthOutlineSprite = this.GetComponent<SpriteRenderer>();
//        Debug.Log("our new sprite renderer  -->");
//        Debug.Log(healthOutlineSprite);

//        originalColor = healthOutlineSprite.color;
//    }

//    /**THE BASIC COMMAND*/
//    public void HealFlash()
//    {
//        StartCoroutine(FlashWhite(1, flashColor));
//    }
//    /**FLASH FOR SET AMOUNT OF TIMES*/
//    public void HealFlash(int repeatTimes)
//    {
//        StartCoroutine(FlashWhite(repeatTimes, flashColor));
//    }
//    /**THE ADVANCED COMMAND INCLUDING COLOR INFO*/
//    public void HealFlash(int repeatTimes, Color flash_color)
//    {
//        StartCoroutine(FlashWhite(repeatTimes, flash_color));
//    }
//    private IEnumerator FlashWhite(int times, Color color)
//    {
//        for(int i=0;i<times;i++)
//        {
//            //set color
//            //healthOutlineImage.color = color;
//            //SPRITERENDERER 3
//            healthOutlineSprite.color = color;
            
//            //wait interval seconds
//            yield return new WaitForSeconds(interval);
//            //set color back to default

//            //healthOutlineImage.color = originalColor;
//            //SPRITERENDERER 4 (last one)
//            healthOutlineSprite.color = originalColor;


//            yield return new WaitForSeconds(interval);
//        }
//    }

//}
