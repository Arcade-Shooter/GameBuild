using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the bullet position.
        if (transform.position.y > 5.53f || transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the bullet object. 
        }
        //DestroyBullet();    //kill this object if it's out of boarder.
    }

    private void DestroyBullet()
    {

        /*
        * this function only checked the bullet is going out of the highest range of the camera,
        * if any other new from of weapen has been developed, then may need to add more boarder check.
        */

        /*
         * the boarder are setted by camera range, and this is NOT a dynamic value,
         * if the camera has been moved, then the value MUST be changed!
         */

        //check if the bullet sitll in the range of camera,and kill the object if not.
        if (transform.position.y > 6.0f || transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the bullet object. 
        }

        //
        //if (transform.position.x > -8.4f || transform.position.x < -18.69f)
        //{
        //    Destroy(gameObject);
        //}
    }

}
