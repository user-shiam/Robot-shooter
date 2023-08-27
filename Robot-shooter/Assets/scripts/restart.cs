using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restart : MonoBehaviour {

	public float restartTime;
	bool restartNow=false;
	float resetTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (restartNow && restartTime <=Time.time) {
		
			Application.LoadLevel (Application.loadedLevel);
		}
		
	}
	public void restartGame(){
		restartNow = true;
		resetTime = Time.time + restartTime;
	
	}
}
