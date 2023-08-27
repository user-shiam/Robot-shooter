using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

	public Transform target;
	public float smooth;

	Vector3 offset;
	float lowY;
	// Use this for initialization
	void Start () {

		offset = transform.position - target.position;

		lowY = transform.position.y;
		
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (transform != null) {
		
			Vector3 targetcamp = target.position + offset;
			if (transform != null) {
				transform.position = Vector3.Lerp (transform.position, targetcamp, smooth * Time.deltaTime);
				if (transform.position.y < lowY)
					transform.position = new Vector3 (transform.position.x, lowY, transform.position.z);
	
			}
		}
	}
}
