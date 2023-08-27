using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_right : MonoBehaviour {
	public float speed;
	Rigidbody2D myRB;
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>() ;
	}
	private bool dirRight = true;
	//public float speed = 10.0f;

	void Update () {
		if (dirRight)
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		else
			transform.Translate (-Vector2.right * speed * Time.deltaTime);

		if(transform.position.x >= -11.11f) {
			dirRight = false;
		}

		if(transform.position.x <= -27.32f) {
			dirRight = true;



		}
	}
}
