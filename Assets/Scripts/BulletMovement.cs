using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // bullet speed variable
    public float bulletSpeed = 30;

    void Update()
    {
        // moves the bullet forwards
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // reverses the speed of the bullet if it collides with anything with the sword tag
        if (other.gameObject.CompareTag("Sword"))
        {
            bulletSpeed *= -1;
        }
        // if the detected trigger has the tag 'Enemy', destroy both the bullet and the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        // if the detected trigger has the tag 'Player', destroy both the bullet and the player
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
