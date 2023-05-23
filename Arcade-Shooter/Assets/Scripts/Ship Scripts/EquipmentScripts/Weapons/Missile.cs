using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float Speed = 6;
    [SerializeField] private Transform Target;


    // Update is called once per frame
    void Update()
    {
        transform.up = Vector3.Slerp(transform.up, Target.position - transform.position,
                       0.5f / Vector2.Distance(this.transform.position, Target.position));
        transform.position += transform.up * Speed * Time.deltaTime;

        if (transform.position.y > 5.53f || transform.position.y < -6.0f)
        {
            Destroy(gameObject);    //kill the bullet object. 
        }
    }

    public void SetTarget(Transform target){
        this.Target = target;
    }
}
