using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	public Text timerText;
	public Text fuelText;
	public GameObject timerPanel;

	public void UpdateTimer(float timeLeft){
		timerText.text = timeLeft.ToString("0");
	}
	public void HideTimerPanel(){
		timerPanel.SetActive(false);
	}
	void Awake(){
		GameControl.uiControl = this;
	}
	// Use this for initialization
	void Start () {
		timerPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
