using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontoller : MonoBehaviour {
	public float maxspeed;

	bool grounded= false;

	float groundCR = 0.4f;
	public LayerMask groundlayer;
	public Transform groundchack;
	public float jumph;


	Rigidbody2D myRB;
	Animator myanim;
	bool fecingright;

	//p-s
	public Transform gunt;
	public GameObject bullte;
	float firer= 0.5f;
	float nxtf=1f;


	private string  rightFingerID = "";
	private string  leftFingerID  = "";

	private int JUMP = 0;
	private int FIRE = 0;


	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>() ;
		myanim = GetComponent<Animator> ();
		fecingright = true;
	}

	// Update is called once per frame

	void Update () {

		TouchFire();
		TouchJump();


		#if UNITY_EDITOR && !(UNITY_ANDROID || UNITY_IOS)
		if (grounded && Input.GetAxis ("Jump") > 0) {

			grounded = false;
			myanim.SetBool ("isground", false);
			myRB.AddForce (new Vector2 (0,jumph));
		}

		if (Input.GetAxisRaw("Fire1") > 0) {
			myanim.SetBool ("fire", true);
			firebulte ();
		} 
		else if (Input.GetAxisRaw ("Fire1")==0)
		{  
			myanim.SetBool ("fire", false);
		}
		#endif

		#if (UNITY_ANDROID || UNITY_IOS)
		if (grounded && JUMP > 0) {

			grounded = false;
			myanim.SetBool ("isground", false);
			myRB.AddForce (new Vector2 (0,jumph));
		}

		if (FIRE > 0) {
			myanim.SetBool ("fire", true);
			firebulte ();
		} 
		else if (FIRE == 0)
		{  
			myanim.SetBool ("fire", false);
		}
		#endif

	}


	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundchack.position, groundCR, groundlayer);

		myanim.SetBool ("isground", grounded);
		myanim.SetFloat ("vspeed",myRB.velocity.y);



		float move = Input.GetAxis("Horizontal");
		myanim.SetFloat ("speed", Mathf.Abs (move));
		myRB.velocity = new Vector2 (move * maxspeed, myRB.velocity.y);

		if (move > 0 && !fecingright) {
			flip ();
		} 
		else if (move <0&& fecingright) {
			flip ();
		}

	}
	void flip()
	{
		fecingright = !fecingright;
		Vector3 thescale = transform.localScale;
		thescale.x *= -1;
		transform.localScale = thescale;
	}

	void firebulte ()
	{  

		if (Time.time > nxtf) {
			nxtf = Time.time + firer;
		}
		if (fecingright) {
			Instantiate (bullte,gunt.position,Quaternion.Euler(new Vector3(0,0,0)));
		} else if (!fecingright) {
			Instantiate (bullte, gunt.position, Quaternion.Euler (new Vector3 (0, 0, 180f)));

		}
	}

	void TouchFire(){
		for(int i = 0; i < Input.touchCount; i++){
			int id = new int();
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				if(Input.GetTouch(i).position.x < Screen.width/2)
				{
					if(leftFingerID == "")
					{
						leftFingerID = Input.GetTouch(i).fingerId.ToString();
						FIRE = 1;
					}
				}
			}

			if(Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
			{
				if(int.TryParse(leftFingerID, out id))
				{
					if(Input.GetTouch(i).fingerId == int.Parse(leftFingerID))
					{
						if(leftFingerID != "")
						{
							leftFingerID = "";
							FIRE = 0;
						}
					}
				}
			}
		}    
	}

	void TouchJump(){
		for(int i = 0; i < Input.touchCount; i++){
			int id = new int();
			if(Input.GetTouch(i).phase == TouchPhase.Began)
			{
				if(Input.GetTouch(i).position.x < Screen.width/2)
				{
					if(leftFingerID == "")
					{
						leftFingerID = Input.GetTouch(i).fingerId.ToString();
						JUMP = 1;
					}
				}
			}

			if(Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
			{
				if(int.TryParse(leftFingerID, out id))
				{
					if(Input.GetTouch(i).fingerId == int.Parse(leftFingerID))
					{
						if(leftFingerID != "")
						{
							leftFingerID = "";
							JUMP = 0; 
						}
					}
				}
			}
		}    
	}
}  
