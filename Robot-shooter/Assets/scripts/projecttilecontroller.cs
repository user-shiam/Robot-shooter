using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttilecontroller : MonoBehaviour {
	public float bulltespeed;
	Rigidbody2D myrb;

	// Use this for initialization
	void Awake () {
		myrb = GetComponent<Rigidbody2D> ();

		if(transform.localRotation.z>0)
		myrb.AddForce (new Vector2 (-1, 0) * bulltespeed, ForceMode2D.Impulse);
		else
			myrb.AddForce (new Vector2 (1, 0) * bulltespeed, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () { 
		
	}
	public void removeforec()
	{
		myrb.velocity = new Vector2 (0, 0);
	}

}
