using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Rocket : MonoBehaviour {
	public float mass;
	public float thrustMagnitude;
	void Awake(){
		GameControl.rocket = this;
		thrustMagnitude = 0f;
		GetComponent<Rigidbody2D>().mass = mass;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
