using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{ 
    // boundary variables
    private float xRange = 44;
    private float zRange = 14;

    // if anything happens to make it outside the boundary eg. bullets 
    // destroy the object
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
