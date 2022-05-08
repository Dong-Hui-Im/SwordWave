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
        // makes sure that the cooldown of the dash has reset 
        cooldown = true; 
    }


    void Update()
    {
        // player boundaries
        // if the player is outside of the given boundaries
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

        // player movement
        // if the detected input is a horizontal input
        // accelerate the player on the horizontal axis depending on the input eg. left or right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // if the detected input is a vertical input
        // accelerate the playe on the vertical axis depending on the input eg. up or down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // if cooldown is active and left click is clicked, dash
        if (cooldown)
        {
            if (Input.GetMouseButtonDown(0))
            {
                speed = speed * 5;
                // starts the cooldown timer
                StartCoroutine(DashTime(cooldownTime));
                // this stops the player from spamming the dash
                cooldown = false; 
            }

        }
    }
    // cooldown timer
    IEnumerator DashTime(float dashCooldown)
    {
        yield return new WaitForSeconds(dashCooldown);
        // returns the players speed back to normal
        speed = 40; 
        // resets the dash cooldown so that the dash can be used again
        cooldown = true;
    }
}
