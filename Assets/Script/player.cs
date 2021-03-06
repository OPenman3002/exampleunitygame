﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private float jumps = 0;
	public float speed = 5;
    public float jumpSpeed = 10;
	public float health = 100;
    public float invulDuration = 1;
    public float blinkDuration = 0.25f;
    private float invulEndTime = 0;
    private float blinkEndTime = 0;
    private bool hasDoubleJump = false;
	// Use this for initialization
	void start() {
	}
	
	// Update is called once per frame
	void Update () {

		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();
        // Get the current horizontal input (left/ right arrows) - between -1 and 1.
        float horizontal = Input.GetAxis("Horizontal");

        //Get the current Velocity from the physics system 
		Vector2 Velocity = ourRigidBody.velocity;

        //Set our Velocity based on the input and our speed value
        Velocity.x = horizontal * speed;

        // Determine if touching ground 
        // Get the collider attached to this object
        Collider2D ourCollider = GetComponent<Collider2D>();

        // Get the LayerMask for the ground layer - we need this for the next function call
        LayerMask groundLayer = LayerMask.GetMask("Ground");

        //Ask the collider if we are touching this layer
        bool isTouchingGround = ourCollider.IsTouchingLayers(groundLayer);
        
        // if were touching the ground reset our double jump to false
        if (isTouchingGround == true)
             hasDoubleJump = false;
        // Jump logic
       

        bool jumpPressed = Input.GetButtonDown("Jump");

        bool allowedToJump = isTouchingGround;
        if (isTouchingGround == false && hasDoubleJump == false)
            allowedToJump = true;
        

        if (jumpPressed == true && allowedToJump == true)
        {


            Velocity.y = jumpSpeed;
            if (isTouchingGround == false)
                hasDoubleJump = true;
        }


        ourRigidBody.velocity = Velocity;

        //handle blinking while invulnerable:
        //Get our sprite renderer component attached to this object
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        //are we done being invulnerable?
        if (Time.time >= invulEndTime) {
            // if NOT invulnerable

            // Set the renderer to enabled
            renderer.enabled = true;
        } else {

            // If yes to invulnerable

            // If it is time to blink
            if (Time.time >= blinkEndTime)
            {
                // set our rendered enabled value to the opposite of what it currently is (toggle it)
                renderer.enabled = !renderer.enabled;
                //Set the next time we should blink to our current time plus the blink duration
                blinkEndTime = Time.time + blinkDuration;
            } // end if (Time.time >= blinkEndTime)
        }// end if (Time.time >= invulnerableEndTime)
             
        
       
         
	} //end update()
	public void Damage(float damageToDeal)
	{
        if (Time.time >= invulEndTime) {
            // reducting health
            health = health - damageToDeal;

            //TODO: Handle Death

            //Set us as invurnerable for a set duration
            invulEndTime = Time.time + invulDuration;

            // Log the result of the function
            Debug.Log("Damage was dealth");
            Debug.Log("damageTodeal =" + damageToDeal);
            Debug.Log("health = " + health);
        }
        
	} // end damage 
}
