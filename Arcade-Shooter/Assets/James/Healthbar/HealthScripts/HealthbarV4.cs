using UnityEngine;

public class HealthbarV4 : MonoBehaviour
{
    /**
     * Health variables will be Serialized, but private
     * so a user may set them when they are added to a scene,
     * but after they are added, they cannot be changed by external scripts
     * */
    //need maxHealth for bar to calculate percentage of bar graphic to fill
    [SerializeField] private int maxHealth = 3;
    //the main health variable (we only update this with functions, otherwise the graphics wouldnt change)
    [SerializeField] private int health;


    void Start()
    {
        health = maxHealth;
        UpdateBar();
    }

    // HEAL/DAMAGE BY AN AMOUNT:
    public void Damage(int amount)
    {
        //reduce health by amount
        health -= amount;
        if(health < 0)
        {
            //damage below 0 will just be set to 0 as a damage below 0 is impossible
            DamageFull();
        } else
        {
            UpdateBar();
            AnimateDamage();
        }
    }
    public void Heal(int amount)
    {
        //heal health by amount
        health += amount;
        if (health > maxHealth)
        {
            HealFull();
        } else
        {
            UpdateBar();
            AnimateHeal();
        }
    }

    // HEAL/DAMAGE AN ENTIRE BAR
    public void HealFull()
    {
        //set health to maxHealth
        health = maxHealth;
        UpdateBar();
        AnimateHeal();
    }
    public void DamageFull() //basically instakill
    {
        //set health to 0
        health = 0;
        UpdateBar();
        AnimateDamage();
    }

    //________________________________________________

    //PRIVATE STUFF, UPDATE VISUALS + ANIMATION:
    private void UpdateBar()
    {
        //update healthBarInner by setting fill amount to health/maxHealth (as percentage)
        Debug.Log("Updated Health: "+health);
        //-------------------
        


        //-------------------
    }
    private void AnimateDamage()
    {
        //damage animation i.e. white shake
        Debug.Log("Damage Animation!");
    }
    private void AnimateHeal()
    {
        Debug.Log("Heal Animation!");
        //heal animation i.e. grow animation

    }
}
