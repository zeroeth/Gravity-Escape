using UnityEngine;
using System.Collections;

public class LandStar : Star {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Rocket"){
			//check if mv is too large
			if(collision.contacts == null || collision.contacts.Length == 0){
				Debug.Log("Error: no contacts!!!");
				return;
			}
			Rigidbody2D rocketRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
			Vector2 contactNormal = collision.contacts[0].normal;
			//m times v, used to meaure impulse
			Vector2 mv = rocketRigidbody.mass * rocketRigidbody.velocity;
			
		}
	}
}
