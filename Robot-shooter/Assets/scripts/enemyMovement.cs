using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour {

	public float Espeed;
	public GameObject EnemyG;
	public float chrgeTime;

	Animator Eanim;
	bool camFlip= true;
	bool facingRignt= false;
	float flipTime=10f;
	float nxtFlip=0f;

	float startChargeTime;
	bool charge;
	Rigidbody2D enemyRB;
	// Use this for initialization
	void Start () {
		Eanim = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nxtFlip) {
			if (Random.Range (0, 10) > 5)
				flipFace ();
			nxtFlip = Time.time + flipTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if (facingRignt && other.transform.position.x < transform.position.x) {
				flipFace ();
			}else if(!facingRignt && other.transform.position.x > transform.position.x){
				flipFace ();
			}
			camFlip = false;
			charge = true;
			startChargeTime = Time.time + chrgeTime;
		}
	}
	void OnTriggerStay2D(Collider2D other)
	{

		if (other.tag == "Player") {
			if(startChargeTime < Time.time){
				if (!facingRignt)
					enemyRB.AddForce (new Vector2 (-1, 0) * Espeed);
				else
					enemyRB.AddForce (new Vector2 (1, 0) * Espeed);
				Eanim.SetBool ("ischarge",charge);
			}
		}

	}
	void OnTriggerExit2D(Collider2D other)
	{

		if (other.tag == "Player") {
		
			camFlip = true;
			charge = false;
			enemyRB.velocity = new Vector2 (0f,0f);
			Eanim.SetBool ("ischarge", charge);
		
		}
	}
	void flipFace ()
	{
		if (!camFlip)
			return;
		float factinX = EnemyG.transform.localScale.x;
		factinX *= -1f;
		EnemyG.transform.localScale = new Vector3 (factinX,EnemyG.transform.localScale.y,EnemyG.transform.localScale.z);
		facingRignt =! facingRignt;

	
	
	}

}
