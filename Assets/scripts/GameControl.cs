using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour {
	public GameObject rocketPrefab;
	public static Rocket rocket;
	public static PhysicsEngine physics;
	public static UIControl uiControl;
	public static GameControl self;
	[HideInInspector]public Camera mainCamera;
	public float prepTime;
	public float maxOutOfViewportTime;
	public float outOfViewportTime;
	void Awake(){
		maxOutOfViewportTime = 3f;
		self = this;
		mainCamera = Camera.main;
		Init();
	}
	void Init(){
		prepTime = 5f;
		outOfViewportTime = 0f;
		Time.timeScale = 1.0f;
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
		
		//reset current scene
		Destroy(rocket.gameObject);
		//destroy all line renderers
		/*
		LineRenderer[] lineRenderers 
			= GameObject.FindObjectsOfType<LineRenderer>() as LineRenderer[];
		foreach(LineRenderer lr in lineRenderers){
			Destroy(lr.gameObject);
		}
		*/
		GameObject newRocket = Instantiate(rocketPrefab) as GameObject;
		rocket = newRocket.GetComponent<Rocket>();
		rocket.gameObject.name = "rocket";

		uiControl.Init();
		Init();
		
		

	}
	// Update is called once per frame
	void Update () {
		//Count 5
		if(prepTime > 0f){
			prepTime -= Time.deltaTime;
			uiControl.UpdateTimer(Mathf.Max(0f,prepTime));

		}else{
			if(!physics.physicsStarted){
				//before starting physics
				uiControl.HideTimerPanel();

				//rocket.ghostTrail.enabled = true;
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
				rocket.thrusting = true;
				rocket.ApplyThrust();
			}else {
				rocket.thrusting = false;
			}

		}
		
	}
}
