using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour {
	public float mass;
	public float thrustMagnitude;
	public float fuel;
	public Vector2 flyingDirection;
	public bool thrusting;
	public Vector2 currentThrust;
	public Vector2 combinedGravitation;
	void Awake(){
		GameControl.rocket = this;
		thrustMagnitude = 0f;
		fuel = 1000f;
		flyingDirection = Vector2.up;
		currentThrust = Vector2.zero;
		combinedGravitation = Vector2.zero;
		GetComponent<Rigidbody2D>().mass = mass;
	}
	public void ApplyThrust(){
		if(thrustMagnitude > 0f){
			float deltaThrust = Mathf.Min(10f, thrustMagnitude);
			thrustMagnitude -= deltaThrust;
			currentThrust = flyingDirection * deltaThrust;
			GetComponent<Rigidbody2D>().AddForce(currentThrust);
			flyingDirection = GetComponent<Rigidbody2D>().velocity;
			flyingDirection.Normalize();
		}else{
			thrusting = false;
			currentThrust = Vector2.zero;
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
