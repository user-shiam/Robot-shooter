using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour {

	public float damage;
	public float damagerate;
	public float pushBackForec;


	float nextdamage;
	// Use this for initialization
	void Start () {
		nextdamage = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay2D(Collider2D other){
	
		if((other.tag=="Player") && nextdamage<Time.time){
			playerhealth thePlayerh = other.gameObject.GetComponent<playerhealth>();
			thePlayerh.addDamage (damage);
			nextdamage = Time.time + damagerate;
			pushBack (other.transform);
		}
	
	}
	void pushBack(Transform pushObject){
	
		Vector2 pushDirection = new Vector2 (0,(pushObject.position.x-transform.position.x)).normalized;
		pushDirection *= pushBackForec;

		Rigidbody2D PushRB = pushObject.gameObject.GetComponent<Rigidbody2D> ();
		PushRB.velocity = Vector2.zero;
		PushRB.AddForce (pushDirection,ForceMode2D.Impulse);
	}
}
