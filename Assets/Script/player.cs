using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	public float speed = 5;
	public float health = 100;
    public float invulDuration = 1;
    public float blinkDuration = 0.25f;
    private float invulEndTime = 0;
    private float blinkEndTime = 0;
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
