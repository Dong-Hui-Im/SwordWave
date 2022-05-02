using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyAI : MonoBehaviour
{
    // movement variables
    private GameObject player;
    private Rigidbody rbEnemy;
    public float speed;
    public float distance;
    private Vector3 offset = new Vector3(0, 0, 3);
    public Transform playerChar; 

    // boundary variables
    public float xRange = 10f;
    public float zRange = 10f;

    // cooldown/shooting variables
    public bool cooldown = true;
    public float cooldownTime = 10f;
    public bool playerInRange;
    public GameObject projectilePrefab;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        cooldown = true; // makes sure that the cooldown of the shooting has reset 
    }

    // detects if the enemy is in the range of the player
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerShield")
        {
            playerInRange = true;
        }
    }
    // detects if the enemy is not in the range of the player
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerShield")
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        player = GameObject.Find("Player"); // locates the position of the player

        transform.LookAt(playerChar); // makes the enemy look at the player

        // if the enemy is in the range of the player, move away from the player
        if (playerInRange)
        {
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(moveDirection * -speed);
        }
        // else move towards the player
        else
        {
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(moveDirection * speed);
        }
        // if cooldown is active then shoot at the player
        if (cooldown)
        {
            Instantiate(projectilePrefab, transform.position + offset, transform.rotation); // shoots the bullet
            StartCoroutine(ShootTime(cooldownTime)); // starts the cooldown for shooting
            cooldown = false; // stops the enemy from shooting more than one at a time
        }
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
    // cooldown timer
    IEnumerator ShootTime(float shootCooldown)
    {
        yield return new WaitForSeconds(shootCooldown);
        cooldown = true;
    }
}
