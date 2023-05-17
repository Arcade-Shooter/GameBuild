using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackChange : MonoBehaviour
{
    public float BackHigh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -BackHigh)
        {
            transform.position = new Vector3(transform.position.x, BackHigh, transform.position.z);
        }
    }
}
