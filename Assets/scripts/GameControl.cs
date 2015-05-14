using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public static Rocket rocket;
	public static PhysicsEngine physics;
	public static UIControl uiControl;
	public static GameControl self;
	[HideInInspector]public Camera mainCamera;
	public float prepTime;
	public float maxOutOfViewportTime;
	public float outOfViewportTime;
	void Awake(){
		prepTime = 5f;
		maxOutOfViewportTime = 3f;
		outOfViewportTime = 0f;
		self = this;
		mainCamera = Camera.main;
	}
	// Use this for initialization
	void Start () {
		uiControl.UpdateTimer(prepTime);
	}
	void RocketInViewportTest(){
		Vector2 rocketInViewport 
			= mainCamera.WorldToViewportPoint(rocket.transform.position);
		if(rocketInViewport.x < 0f || rocketInViewport.x > 1f 
			|| rocketInViewport.y < 0f || rocketInViewport.y > 1f){
			//start counting 3 seconds
			outOfViewportTime += Time.deltaTime;
		}else{
			outOfViewportTime = 0f;
		}
	}
	void OnGameOver(){
		Time.timeScale = 0f;
		physics.physicsStarted = false;
		//start playing back trails

	}
	// Update is called once per frame
	void Update () {
		//Count 5
		if(prepTime > 0f){
			prepTime -= Time.deltaTime;
			uiControl.UpdateTimer(Mathf.Max(0f,prepTime));
			if(Input.GetButton("Fire1")){
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
			//if rocket is out of sight for more than 3 seconds
			//game over
			
			RocketInViewportTest();
			if(outOfViewportTime >= maxOutOfViewportTime){
				OnGameOver();
				return;
			}
			if(Input.GetButton("Fire1")){
				rocket.thrustMagnitude += 10f;
			}else if(Input.GetButtonUp("Fire1")){
				//apply thrust
				Debug.Log("thrusting");
				rocket.thrusting = true;
			}

		}
		
	}
}
