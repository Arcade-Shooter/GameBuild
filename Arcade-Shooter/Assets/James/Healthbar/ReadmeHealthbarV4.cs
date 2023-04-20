
using UnityEngine;
/**
README (HealthbarV4.unity):

There's just gonna be 1 healthbar script in this version of the healthbar: HealthbarV4.cs



Some notes for myself:

I'm gonna code the main functionality, damage(), heal(), and some private vars
including health (should be modified by script only) and the int maxHealth.

"maxHealth" is gonna be quite important as HealthbarV4 is gonna be designed around
the health "Bar" (i will get to the health capsules later, once i can get a basic healthbar working).

Technically this component will be a more advanced Unity Slider:
a graphical display that represents a health variable stored and updated somewhere else

Whenever the player takes damage another script will have to call HealthbarV4's "damage(int health)" function,
and in turn the HealthBar script will update the healthbar accordingly, including automatic damage/heal animations for the bar.
the healthBar could be repurposed for other variables i.e. a 2nd healthbar component representing hunger.
I should be able to give any component a healthbar by instantiating it, so this entire bar will be a prefab,
so the takeDamage() function needs to be simple to use.

*/
public class ReadmeHealthbarV4 : MonoBehaviour { }