using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour {
	public List<string> scenes; //assign in inspector
	public int currentSceneIdx;
	
	void Awake(){
        DontDestroyOnLoad(gameObject);
        if(scenes.Count <= 0){
        	Debug.Log("No scenes in scenes list!");
        	Application.Quit();
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
