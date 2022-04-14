using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public float bulletSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            bulletSpeed *= -1;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            bulletSpeed *= -1;
        }
    }
}
