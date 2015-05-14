using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {

	void Start () {
	}

    void Update() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		transform.position = ray.origin;
    }
}
