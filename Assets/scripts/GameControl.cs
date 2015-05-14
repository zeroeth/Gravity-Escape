using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public static Rocket rocket;
	public static PhysicsEngine physics;
	public static UIControl uiControl;
	public static GameControl self;
	public float prepTime;
	void Awake(){
		prepTime = 5f;
		self = this;
	}
	// Use this for initialization
	void Start () {
		uiControl.UpdateTimer(prepTime);
	}
	
	// Update is called once per frame
	void Update () {
		//Count 5
		if(prepTime > 0f){
			prepTime -= Time.deltaTime;
			uiControl.UpdateTimer(Mathf.Max(0f,prepTime));
			if(Input.GetKey("w")){
				rocket.thrustMagnitude += 15f ; //thrust = f*t
			}else{
				rocket.thrustMagnitude = 0f;
			}
		}else{
			if(!physics.physicsStarted){
				//before starting physics
				uiControl.HideTimerPanel();
			}
			physics.physicsStarted = true;
			if(Input.GetKey("w")){
				rocket.thrustMagnitude += 10f;
			}else if(Input.GetKeyUp("w")){
				//apply thrust
				Debug.Log("thrusting");
				rocket.thrusting = true;
			}

		}
		
	}
}
