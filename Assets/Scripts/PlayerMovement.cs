using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    public float playerSpeed = 40;
    public float horizontalInput;
    public float verticalInput;

    // boundary variables
    public float xRange = 10f;
    public float zRange = 10f;

    // cooldown variables
    public bool isCooldown = true;
    public float cooldownTime = 1;
    public float dashDuration = 0.1f;
    public float dodgeSpeedMultiplier = 3;

    void Start()
    {
        // makes sure that the cooldown of the dash has reset 
        isCooldown = true; 
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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);

        // if the detected input is a vertical input
        // accelerate the playe on the vertical axis depending on the input eg. up or down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);

        // if cooldown is active 
        if (isCooldown)
        {
            // and left click is clicked, dash
            if (Input.GetMouseButtonDown(0))
            {
                // multiply speed by 5 
                playerSpeed = playerSpeed * dodgeSpeedMultiplier;
                // this stops the player from spamming the dash
                isCooldown = false;
                // starts the dash duration timer
                StartCoroutine(DashTime(dashDuration));
                // starts the dash cooldown timer
                StartCoroutine(DashCooldownTime(cooldownTime));
            }

        }
    }
    // dash duration timer
    IEnumerator DashTime(float dashCooldown)
    {
        // wait for the duration of 'dashCooldown' 
        yield return new WaitForSeconds(dashCooldown);
        // returns the players speed back to normal
        playerSpeed = 40; 
    }
    // dash cooldown timer
    IEnumerator DashCooldownTime(float dashCooldown)
    {
        // wait for the duration of 'dashCooldown'
        yield return new WaitForSeconds(dashCooldown);
        // turns 'isCooldown' back to true so the player can dash again 
        isCooldown = true;
    }
}
