using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour {

	public float fullhealth;
	public GameObject deathFX;

	public AudioClip p_hurt;
	public AudioClip pDeath;
	public restart theGamemanager;


	public Text gameover;
	public Text win;
	public Slider healthslider;

	public Image DamageScreen;
	private bool damaged;
	Color damagecolour = new Color (0f,0f,0f,0.5f);
	float smoothcolour=5f; 
	AudioSource playerA;

	float currenthelth;
	Playercontoller cm;
	void Start () {

		currenthelth = fullhealth;

		cm = GetComponent<Playercontoller> ();
		healthslider.maxValue = fullhealth;
		healthslider.value = fullhealth;

		damaged = false;
		playerA = GetComponent <AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {


		if (damaged) {
			DamageScreen.color = damagecolour;
		} else {
		
			DamageScreen.color = Color.Lerp(DamageScreen.color,Color.clear,smoothcolour*Time.deltaTime);
		}
		damaged = false;
	}

	public void addDamage(float damage){
		if (damage <= 0) {
			return;
		}
		currenthelth -= damage;
		playerA.clip = p_hurt;
		//playerA.Play();
		playerA.PlayOneShot(p_hurt);

		healthslider.value = currenthelth;

		damaged = true;

		if(currenthelth<=0){
			
			makeDaed ();

		}
	
	}
	public void addHealth(float HealthAmount){
		currenthelth += HealthAmount;
		if(currenthelth > fullhealth) currenthelth = fullhealth;
		healthslider.value = currenthelth;
	}
	public void makeDaed(){
	

		Destroy(gameObject.transform.parent.gameObject);
		AudioSource.PlayClipAtPoint (pDeath,transform.position);
		Instantiate (deathFX,transform.position,transform.rotation);


		Animator gameoveranim = gameover.GetComponent<Animator> ();
		gameoveranim.SetTrigger ("g-chack");
		theGamemanager.restartGame();
	}

	public void completeGame()
	{
		//Destroy (gameObject);
	
		Destroy(gameObject.transform.parent.gameObject);
		Animator winAnim = win.GetComponent<Animator> ();
		winAnim.SetTrigger ("win-chack");
		//theGamemanager.restartGame();
	}
}
