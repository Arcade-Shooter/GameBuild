using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float Speed = 6;
    [SerializeField] private Transform Target;
    [SerializeField] private float rotationSpeed = 200f;

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        // Find all enemies
        EnemyShipController[] enemies = FindObjectsOfType<EnemyShipController>();

         if (enemies.Length > 0)
        {    
            // Find the closest enemy as target
            float minDistance = Mathf.Infinity;
            foreach (EnemyShipController enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    Target = enemy.transform;
                }
            }

            Debug.Log(Target.name + " found!");
            // Track the target
            Vector3 direction = Target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            Debug.Log("No Enemy Found!");
        }


        //Boundary detection
        if (transform.position.y > CameraBounds.TopBoundary || transform.position.y < CameraBounds.BottomBoundary ||
            transform.position.x > CameraBounds.RightBoundary || transform.position.x < CameraBounds.LeftBoundary)
        {
            Destroy(gameObject);
        }


    }
}
