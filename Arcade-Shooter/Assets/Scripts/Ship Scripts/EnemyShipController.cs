using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public float Speed;
    public GameObject Bullet;
    public int ProbabilityShoot;    //range: 0 - 10
    // Start is called before the first frame update
    void Start()
    {
        EnemyShoot();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Speed * Time.deltaTime);   //update the enemy ship position.
        if (transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the enemy ship object. 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void EnemyShoot()
    {
        float Probability = Random.Range(0, 10);
        if (Probability <= ProbabilityShoot)
        {
            Instantiate(Bullet, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.Euler(0, 0, 0));   //create new Bullet object at the postion where the ship is.

        }
    }

}
