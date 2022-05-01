using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // bullet speed variable
    public float bulletSpeed = 40;

    // moves the bullet
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    // reverses the speed of the bullet if it collides with anything with the sword tag
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            bulletSpeed *= -1;
        }
    }
}
