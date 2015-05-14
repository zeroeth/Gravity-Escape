using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public static Rocket rocket;
	public static PhysicsEngine physics;
	public float prepTime;
	void Awake(){
		prepTime = 5f;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Count 5
		if(Time.time < prepTime){
			if(Input.GetKey("w")){
				rocket.thrustMagnitude += 15f ; //thrust = f*t
			}else{
				rocket.thrustMagnitude = 0f;
			}
		}else{
			if(!physics.physicsStarted){
				//before starting physics

			}
			physics.physicsStarted = true;
			//rocket.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f);

		}
		
	}
}
