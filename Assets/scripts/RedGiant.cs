using UnityEngine;
using System.Collections;

public class RedGiant : MonoBehaviour {
	public float rocketCollisionTime;
	// Use this for initialization
	void Start () {
		rocketCollisionTime = 0.0F;
	}
	
	// Update is called once per frame
	void Update () {
		if(GameControl.rocket.state != (int)Rocket.State.preLaunch){
			transform.position += Vector3.right * 0.5f*Time.deltaTime;
			SpriteRenderer mySr = GetComponent<SpriteRenderer>();
			SpriteRenderer sr = GameControl.rocket.GetComponent<SpriteRenderer>();
			float f1 = transform.position.x + mySr.sprite.bounds.size.x/2f;
			if(f1 > GameControl.rocket.transform.position.x){
				Debug.Log("swallowing");
				rocketCollisionTime += Time.deltaTime;
			}else{
				rocketCollisionTime = 0.0f;
			}
			if(rocketCollisionTime > 2.0f){
				GameControl.rocket.Crash();
			}
		}
	}
	/*
	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Rocket"){

		}
	}
	void OnCollisionStay2D(Collision2D other){
		if(other.gameObject.tag == "Rocket"){
			rocketCollisionTime += Time.deltaTime;
			if(rocketCollisionTime > 2.0f){
				other.gameObject.GetComponent<Rocket>().Crash();
			}
		}
	}
	void OnCollisionExit2D(Collision2D other){
		if(other.gameObject.tag == "Rocket"){
			rocketCollisionTime = 0.0f;
		}
	}
	*/
}
