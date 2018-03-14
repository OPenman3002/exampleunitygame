using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {


	public float speed = 5;
	public float health = 100;
    public float invulDuration = 1;

    private float invulEndTime = 0;

	// Use this for initialization
	void start() {
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D ourRigidBody = GetComponent<Rigidbody2D> ();

		ourRigidBody.velocity = Vector2.right * speed;
	} 
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
