using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    public float speed = 40;
    public float horizontalInput;
    public float verticalInput;

    // boundary variables
    public float xRange = 10f;
    public float zRange = 10f;

    // cooldown variables
    public bool cooldown = true;
    public float cooldownTime = 1f;

    void Start()
    {
        cooldown = true; // makes sure that the cooldown of the dash has reset 
    }


    void Update()
    {
        //player boundaries
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

        //player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // if cooldown is active and left click is clicked, dash
        if (cooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = speed * 5;
                StartCoroutine(DashTime(cooldownTime)); // starts the cooldown timer
                cooldown = false; // this stops the player from spamming the dash
            }

        }
    }
    // cooldown timer
    IEnumerator DashTime(float dashCooldown)
    {
        yield return new WaitForSeconds(dashCooldown);
        speed = 40; // returns the players speed back to normal
        cooldown = true;
    }
}
