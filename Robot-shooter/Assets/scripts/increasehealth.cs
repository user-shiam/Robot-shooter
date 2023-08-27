using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasehealth : MonoBehaviour {
	public float healthAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			playerhealth theHealth = other.gameObject.GetComponent<playerhealth> ();
			theHealth.addHealth (healthAmount);
			Destroy (gameObject);
	}
	
	}
}
