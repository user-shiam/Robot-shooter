using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour {



	public float wdamage;
	public GameObject explationeffect;

	projecttilecontroller mypc;




	// Use this for initialization
	void Awake () {

	mypc = GetComponentInParent<projecttilecontroller> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("shootable")) {
		
			mypc.removeforec ();

			Instantiate (explationeffect, transform.position, transform.rotation);
			Destroy (gameObject);
			if (other.tag == "enemy") {
				ememyhealth hurt = other.gameObject.GetComponent<ememyhealth> ();

				hurt.adddamage (wdamage); 
			}
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("shootable")) {

			mypc.removeforec();
			Instantiate (explationeffect, transform.position, transform.rotation);
			Destroy (gameObject);
			if (other.tag == "enemy") {
				ememyhealth hurt = other.gameObject.GetComponent<ememyhealth> ();

				hurt.adddamage (wdamage);
			}
		}	
	}
}
