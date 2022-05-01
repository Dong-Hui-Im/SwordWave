using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemyAI : MonoBehaviour
{
    // movement variables
    public GameObject player;
    private Rigidbody rbEnemy;
    public float speed;
    public float distance;
    private Vector3 offset = new Vector3(0, 0, 3);
    public Transform playerChar;

    // boundary variables
    public float xRange = 10f;
    public float zRange = 10f;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
    }

    void Update()
    {
        player = GameObject.Find("PlayerShield"); // constantly finds the player 

        // makes the enemy constantly move towards the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(lookDirection * speed);

        transform.LookAt(playerChar); // makes the enemy look towards the player

        // enemy boundaries
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
}
