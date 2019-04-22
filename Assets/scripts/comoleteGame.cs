using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comoleteGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			
			playerhealth player = other.GetComponent<playerhealth> ();
			player.completeGame ();
		}

	}
}
