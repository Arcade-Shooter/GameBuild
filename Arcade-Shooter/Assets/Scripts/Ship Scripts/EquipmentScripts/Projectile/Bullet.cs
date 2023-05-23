using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] Vector3 Direction;

    void Update() {
        move();
    }

    private void move(){
        transform.Translate(Direction * Speed * Time.deltaTime);   //update the bullet position.
        if (transform.position.y > CameraBounds.TopBoundary || transform.position.y < CameraBounds.BottomBoundary || 
            transform.position.x > CameraBounds.RightBoundary || transform.position.x < CameraBounds.LeftBoundary)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 direction){
        this.Direction = direction;
    }

}
