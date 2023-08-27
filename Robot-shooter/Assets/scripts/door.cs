using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	public Transform wsd;
	public GameObject d;
	bool active=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player" && !active) {
			active = true;
			Instantiate (d, wsd.position, Quaternion.identity);
			restart p = other.GetComponent<restart> ();
			p.restartGame();
		}
	}
}
