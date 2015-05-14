using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour {
	public float mass;
	public float thrustMagnitude;
	public Vector2 flyingDirection;
	public bool thrusting;
	void Awake(){
		GameControl.rocket = this;
		thrustMagnitude = 0f;
		flyingDirection = Vector2.up;
		GetComponent<Rigidbody2D>().mass = mass;
	}
	public void ApplyThrust(){
		if(thrustMagnitude > 0f){
			float deltaThrust = Mathf.Min(10f, thrustMagnitude);
			thrustMagnitude -= deltaThrust;
			GetComponent<Rigidbody2D>().AddForce(flyingDirection * deltaThrust);
			flyingDirection = GetComponent<Rigidbody2D>().velocity;
			flyingDirection.Normalize();
		}else{
			thrusting = false;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(thrusting){
			ApplyThrust();
		}
	}
}
