using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyAI : MonoBehaviour
{

    public GameObject player;
    private Rigidbody rbEnemy;
    public float speed;
    public float distance;
    private Vector3 offset = new Vector3(0, 0, 3);
    public Transform playerChar;

    public float xRange = 10f;
    public float zRange = 10f;

    public bool cooldown = true;
    public float cooldownTime = 10f;
    public bool playerInRange;
    public GameObject projectilePrefab;

    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        player = GameObject.Find("PlayerShield");
        cooldown = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerShield")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerShield")
        {
            playerInRange = false;
        }
    }

    void Update()
    {

        transform.LookAt(playerChar);

        if (playerInRange)
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(lookDirection * -speed);

        if (cooldown)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            StartCoroutine(ShootTime(cooldownTime));
            cooldown = false;
        }

        }
        else
        {
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            rbEnemy.AddForce(lookDirection * speed);
        }

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

    IEnumerator ShootTime(float shootCooldown)
    {
        yield return new WaitForSeconds(shootCooldown);
        cooldown = true;
    }
}
