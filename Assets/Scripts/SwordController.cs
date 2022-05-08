using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    // if the sword detecds a collision with a trigger
    private void OnTriggerEnter(Collider other)
    {
        // and if that collision was with a game object that had the 'Enemy' tag
        if (other.gameObject.CompareTag("Enemy"))
        {
            // destroy the object that collided with the sword
            Destroy(other.gameObject);
        }
    }
}
