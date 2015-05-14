using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsEngine : MonoBehaviour {
	public bool physicsStarted;
	public List<Star> stars;
	
	void Awake(){
		physicsStarted = false;
		GameObject[] starArr = GameObject.FindGameObjectsWithTag("Star");
		foreach(GameObject g in starArr){
			stars.Add(g.GetComponent<Star>());
		}
		GameControl.physics = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate(){
		if(!physicsStarted){
			return;
		}
		Rocket rocket = GameControl.rocket;
		
		foreach(Star s in stars){
			Vector2 forceOnRocket = s.CalculateGravity();
			rocket.GetComponent<Rigidbody2D>().AddForce(forceOnRocket);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
