using UnityEngine;
using System.Collections;

public class dvdLogoV2ScreenWidth:MonoBehaviour
{
    public float speed = 5.0f;

    //---------------------------------
    //in V2, we use Screen.Width instead
    //---------------------------------
    //public float minX = -10.0f;
    //public float maxX = 10.0f;
    //public float minY = -5.0f;
    //public float maxY = 5.0f;
    float minX = -Screen.width;
    float maxX = Screen.width;
    float minY = -Screen.height;
    float maxY = Screen.height;

    //public AudioClip bounceSound;

    private Vector3 direction;

    void Start()
    {
        //random initial position & direction
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
        direction = new Vector3(1, 1);
        direction = direction.normalized;
    }

    void Update()
    {
        //move dvd logo in current direction and speed
        transform.position += direction * speed * Time.deltaTime;

        //check DVD logo reaches screen edges and update direction accordingly
        if(transform.position.x < minX || transform.position.x > maxX)
        {
            direction.x *= -1;
            //transform.Rotate(Vector3.forward * Random.Range(90, 270));
            //AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
        if(transform.position.y < minY || transform.position.y > maxY)
        {
            direction.y *= -1;
            //transform.Rotate(Vector3.forward * Random.Range(90, 270));
            //AudioSource.PlayClipAtPoint(bounceSound, transform.position);
        }
    }
}