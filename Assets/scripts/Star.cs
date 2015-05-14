using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	//F = GMm/(r^2)
	public float gravityConst;
	public float mass;
	// Use this for initialization
	public Vector2 CalculateGravity(){
		float dist = Vector2.Distance(
			GameControl.rocket.transform.position,
			transform.position
		);
		Vector2 dir = transform.position - GameControl.rocket.transform.position;
		dir.Normalize();
		return dir * gravityConst * mass * (GameControl.rocket.mass) / (dist * dist);
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
