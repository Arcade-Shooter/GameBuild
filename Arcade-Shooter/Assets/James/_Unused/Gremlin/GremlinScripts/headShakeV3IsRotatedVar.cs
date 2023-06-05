using UnityEngine;
using System.Collections;

/** A 2-frame anime-style head shake.
     * Basically, we wanna rotate left 45degrees, wait 1 second,
     * flip rotation, wait 1 second, etc
     * so its a 2 frame animation
     * and 2 is the exact num of possible boolean vars would ya know
     * can we increment a boolean with ++? im not sure, will try that too
     * but for now we're good
    */
public class headShakeV3IsRotatedVar:MonoBehaviour
{
    public float shakeAngle = 45.0f; //turn this number of degrees left right
    public float waitTime = 1.0f; //delay between head shakes
    //timers are soo tedious and long! i just wanna use time.wait() but cant do that in an update loop, oh well
    private float timer = 0.0f;
    
    //flag tracks rotation direction
    private bool rotateLeft = false;

    void Update()
    {
        //NEW CODE
        timer += Time.deltaTime;
        if(timer >= waitTime)
        {
            if(rotateLeft)
            {
                //rotate left
                Debug.Log("Headshake Left!");
                transform.rotation = Quaternion.Euler(0, 0, -shakeAngle);
            } else
            {
                //rotate right
                Debug.Log("Headshake Right!");
                transform.rotation = Quaternion.Euler(0, 0, shakeAngle);
            }

            //we flip the value so next rotation will be opposite
            rotateLeft = !rotateLeft;
            timer = 0.0f;
        }
    }
}