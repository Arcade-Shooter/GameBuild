using UnityEngine;
using UnityEngine.UI;

/**

Healthbar V12

This is a major version,
maybe i shouldve called it Healthbar V2.0 (sounds bigger?)
maybe "Healthbar Series X"?
anyway, gonna add a setHealth() method and a setMaxHealth() method.

I also wanna delete a buncha methods!
I think i only need
- setCurrentHealth(),
- setMaxHealth(),
- UpdateBar()

might still need these old functions though:
- Start()
- AnimateHeal()
- Heal()
- Damage()

So I can only really delete
- HealFull()
- DamageFull()


Old System:
the Healthbar stores the current health value, and when a player/capsule takes damage it will call Healthbar.
It will receive back a value of whether the healthbar still has health.
If the healthbar is empty, the player/capsule would destroy itself (in its own script, not the healthbar script).

Old System Requirements:
Heal()
Damage()
UpdateBar()


New System: (NOPE! WERE GOING BACK TO OLD SYSTEM)
The Healthbar DOESNT store health...?
Basically, if we use the new system, the Healthbar wouldnt store any health,
instead it would rely on each player/capsule to store it's own health.

New System Requirements

Writing out the New System, it kinda sounds ridiculous. I think I'd rather just store maxHealth in here,
that way i can change it with a SerializeField
*/
public class Healthbar : MonoBehaviour
{
    //############  Variables  ###############
    //COOL SETTTINGS:
    [SerializeField] private int maxHealth = 3; //3 heart capsules, but this can change
    public SpriteRenderer healthSpriteRenderer;

    //(((super private, machine settings))):
    private int currentHealth; //only gonna update this with private methods
    private float spriteWidth;
    private float spriteHeight;

    private void Start()
    {
        Debug.Log("I AM A HEALTHBAR!");
        spriteWidth = healthSpriteRenderer.size.x;
        spriteHeight = healthSpriteRenderer.size.y;
        UpdateBar();
    }

    //############  Methods  ###############
    //-------------Public Methods-------------
    //  Set Health Value/s

    //OLD HEALTH METHODS
    public void Damage(int amount)
    {
        Debug.Log("DAMAGE!");
        currentHealth -= amount;
        if(currentHealth < 0) { DamageFull();} //  if negative health, round to 0
        else
        {
            UpdateBar();
            AnimateDamage();
        }
    }
    public void Heal(int amount)
    {
        Debug.Log("HEAL!");
        currentHealth += amount;
        if(currentHealth > maxHealth) { HealFull(); }
        else
        {
            UpdateBar();
            AnimateHeal();
        }
    }
    
    //NEW HEALTH METHODS
    public void setCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
        UpdateBar();
        AnimateHeal();
    }
    
    /**
    setMaxHealth()

    This should be called when the player/enemy is 1st created,
    but by default this script is gonna be attached to a 3-heart bar
    so we'll just leave it as is for now
    */
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        UpdateBar();
    }

    //-------------Private Methods-------------
    private void HealFull()
    {
        currentHealth = maxHealth;
        UpdateBar();
        AnimateHeal();
    }
    private void DamageFull()
    {
        currentHealth = 0;
        UpdateBar();
        AnimateDamage();
    }
    
    
    
    //  Animation Stuff
    private void AnimateDamage()
    {
        //the 1 means "flash once" not "flash for 1 second" (this is a personal oops i made)
        //its brown, not red anymore, so you can read the amount of damage as the animation plays. less interfery
        Color darkRed = new Color(0.8f, 0.4f, 0); 
        GetComponent<AnimFlash>().HealFlash(1, darkRed); 
    }
    private void AnimateHeal()
    {
        GetComponent<AnimFlash>().HealFlash(1, Color.gray);
    }
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
        float healthPercent = (float)currentHealth / (float)maxHealth;
        healthSpriteRenderer.size = new Vector2(healthPercent * spriteWidth, spriteHeight);
    }
}