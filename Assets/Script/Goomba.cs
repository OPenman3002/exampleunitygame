using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goomba : MonoBehaviour {

	// Public variables (visible in editor)
	public float damage = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Called when trigger collides with another collider
	void OnTriggerStay2D(Collider2D other)

	{
        // attempting to get the player script from what Goomba collides with. 
        player playerscript = other.GetComponent<player>();
        // if player script exists
        if (playerscript != null) {
            playerscript.Damage(damage);
            Debug.Log("Goomba dealt damage to player =" + damage);
        }


	} // end onTriggerEnter2D	
}


