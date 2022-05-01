using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{ 

    // boundary variables
    private float xRange = 44;
    private float zRange = 14;

    //if anything is outside the boundary, it destroys the object
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
