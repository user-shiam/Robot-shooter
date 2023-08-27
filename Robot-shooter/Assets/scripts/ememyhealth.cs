using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ememyhealth : MonoBehaviour {

	public float enemymaxhealth;
	public AudioClip deathsound;
	public GameObject enemydeathFX;

	public Slider enemyslider;
	public bool drop;
	public GameObject theDrop;

	float currenthealth;
	// Use this for initialization

	void Start () {
		currenthealth = enemymaxhealth;
		enemyslider.maxValue = currenthealth;
		enemyslider.value = currenthealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void adddamage(float  damage){
		enemyslider.gameObject.SetActive (true);
		currenthealth -= damage;

		enemyslider.value = currenthealth;

		if (currenthealth <= 0)
			makedead();
	}

	void makedead(){
		Destroy(gameObject.transform.parent.gameObject);
		AudioSource.PlayClipAtPoint (deathsound,transform.position);
		Instantiate (enemydeathFX, transform.position, transform.rotation);
		if (drop)
			Instantiate (theDrop,transform.position,transform.rotation);

	}
}
