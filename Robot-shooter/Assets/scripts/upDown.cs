using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upDown : MonoBehaviour {
	     
	public float speed;

		//public float speed=1.0f;
		Rigidbody2D myRB;
		// Use this for initialization
		void Start () {
			myRB = GetComponent<Rigidbody2D>() ;
		}
		private bool dirRight = true;

		void Update () {
			if (dirRight)
				transform.Translate (Vector2.up * speed * Time.deltaTime);
			else
			transform.Translate (-Vector2.up * speed * Time.deltaTime);

		if(transform.position.y >-7f ) {
				dirRight = false;
			}

		if(transform.position.y <-23f) {
				dirRight = true;



			}
		}
	}
