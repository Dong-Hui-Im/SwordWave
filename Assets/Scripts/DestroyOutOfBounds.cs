using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{ 
    void Start()
    {

    }

    private float xRange = 44;
    private float zRange = 14;

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < -zRange)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > zRange)
        {
            Destroy(gameObject);
        }
    }
}
