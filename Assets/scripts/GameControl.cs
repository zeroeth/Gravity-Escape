using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	public static Rocket rocket;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w")){
			Debug.Log("hit w");
		}
	}
}
