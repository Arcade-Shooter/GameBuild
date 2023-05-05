using UnityEngine;
using UnityEngine.UI;

/**

Healthbar V8 - AnimHealFlash.cs Name Changed:


No joke, the only reason i have to change this script
is because of my nightmare versioning: i changed the script
"AnimHealFlash.cs" to "AnimHealFlashV2Sprite.cs" (because im silly and thats just what i do)
And because I cannot create a [SerializeField] to drag in a script,
I now have to go and change the name in the AnimHealFlash in this script.

This is absolute pain, if i could put a unit test around this i would.
in fact, I would rather use Unity's built-in animation system, then i could just
drag in the appropriate animation.

For now, this is not 
*/
public class HealthbarV8AnimHealFlashNameChanged : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private int maxHealth = 3; //3 heart capsules
    [SerializeField] private int health; //only gonna update this with private methods
    
    //we used to use an image component:
    // --> public Image healthBarImage;
    //but now we're gonna grab a different component:
    public SpriteRenderer healthSpriteRenderer;

    private float spriteWidth;
    private float spriteHeight;

    private void Start()
    {
        spriteWidth = healthSpriteRenderer.size.x;
        spriteHeight = healthSpriteRenderer.size.y;
        UpdateBar();
    }

    //PUBLIC METHDS (need to access and update these with scripts, UI Buttons etc)
    //the heal() and damage() functions will change the healthbar's amount
    public void Damage(int amount)
    {
        Debug.Log("Damage a Capsule");
        health -= amount;
        if(health < 0)
        {
            //if negative health, round to 0
            DamageFull();
        } else
        {
            UpdateBar();
            AnimateDamage();
        }
    }
    public void Heal(int amount)
    {
        Debug.Log("Heal a Capsule");
        health += amount;
        if(health > maxHealth)
        {
            HealFull();
        } else
        {
            UpdateBar();
            AnimateHeal();
        }
    }
    //PRIVATE METHODS (just other weird stuff)
    //healFull and damageFull for when damage is too high/low
    private void HealFull()
    {
        health = maxHealth;
        UpdateBar();
        AnimateHeal();
    }
    private void DamageFull()
    {
        health = 0;
        UpdateBar();
        AnimateDamage();
    }
    
    
    
    //ANIMATION STUFF
    private void AnimateDamage()
    {
        GetComponent<AnimHealFlash>().HealFlash(1, Color.red);
    }
    private void AnimateHeal()
    {
        GetComponent<AnimHealFlash>().HealFlash(1, Color.gray);
    }
    //update the bar's health amount
    private void UpdateBar()
    {
        /**
        when changing the progress amount on the bar / sliced image,
        1. it must use a Sprite Renderer
        2. The Sprite Renderer's "Draw Mode" must be set to "Tiled"
        3. you will need to drag the objecct containing the sprite renderer
        onto this script's "healthSpriteRenderer" SerializeField in the inspector
         (in this case, healthBarInner (the child object of this healthbar)
         is the red hearts sprite rendering over this object
         [the script is attached to the black hearts],
         Anyways HealthBarInner should already be dragged into the field)
        */
        Debug.Log("Updated Health(Capsule)Bar");
        float healthPercent = (float)health / (float)maxHealth;
        healthSpriteRenderer.size = new Vector2(healthPercent * spriteWidth, spriteHeight);
    }
}