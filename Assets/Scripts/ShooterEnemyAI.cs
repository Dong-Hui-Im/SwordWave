using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyAI : MonoBehaviour
{
    // movement variables
    private GameObject player;
    private Rigidbody rbEnemy;
    public float enemySpeed;
    private Vector3 posOffset = new Vector3(0, 0, 2);
    public Transform playerChar; 

    // boundary variables
    public float xRange = 44f;
    public float zRange = 14f;

    // cooldown/shooting variables
    public bool isCooldown = true;
    public float cooldownTime = 2;
    public bool playerInRange;
    public GameObject projectilePrefab;

    void Start()
    {
        // gets the rigidbody of whatever is using this script for later use
        rbEnemy = GetComponent<Rigidbody>();
        // makes sure that the cooldown of the shooting has reset 
        isCooldown = true; 
    }

    // detects any triggers that the enemy collides with
    private void OnTriggerEnter(Collider other)
    {
        // if the detected trigger is 'PlayerShield', 'playerInRange' is true
        if(other.tag == "PlayerShield")
        {
            playerInRange = true;
        }
        // if the detected trigger is not 'PlayerShield', 'playerInRange' is false
        if (other.tag != "PlayerShield")
        {
            playerInRange = false;
        }

        // Destroys the player if it comes in contact with the enemy
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        // locates the position of the player every frame
        player = GameObject.Find("Player");

        // makes the enemy look at the player every frame
        transform.LookAt(playerChar); 

        // if 'playerInRange' is true
        if (playerInRange)
        {
            // move away from the player
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(moveDirection * -enemySpeed);
        }
        // else move towards the player
        else
        {
            Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(moveDirection * enemySpeed);
        }
        // if cooldown is active then shoot at the player
        if (isCooldown)
        {
            // creates the bullet at the current position of the enemy
            Instantiate(projectilePrefab, transform.position + posOffset, transform.rotation);
            // starts the shoot cooldown
            StartCoroutine(ShootTime(cooldownTime));
            // sets the cooldown to false to stop the enemy from shooting more than once at a time
            isCooldown = false; 
        }
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
    // shooting cooldown timer
    IEnumerator ShootTime(float shootCooldown)
    {
        // waits for the duration of 'shoolCooldown'
        yield return new WaitForSeconds(shootCooldown);
        // sets 'cooldown' to true to reset the cooldown
        isCooldown = true;
    }
}
