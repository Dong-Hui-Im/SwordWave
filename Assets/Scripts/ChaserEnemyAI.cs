using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyAI : MonoBehaviour
{
    // movement variables
    public GameObject player;
    private Rigidbody rbEnemy;
    public float enemySpeed;
    public Transform playerChar;

    // boundary variables
    public float xRange = 44f;
    public float zRange = 14f;

    void Start()
    {
        // gets the rigidbody of whatever is using this script for later use
        rbEnemy = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // finds the location of the player every frame
        player = GameObject.Find("PlayerShield");

        // makes the enemy move towards the player every frame
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(lookDirection * enemySpeed);

        // makes the enemy look towards the player
        transform.LookAt(playerChar); 

        // enemy boundaries
        // if the enemy is outside of the given boundaries
        // return them back to the edge of the boundary they were trying to leave from
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
    // Destroys the player if it comes in contact with the enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
