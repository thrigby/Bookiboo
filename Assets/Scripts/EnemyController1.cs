using UnityEngine;
using System.Collections;

public class EnemyController1 : MonoBehaviour {

		// Use this for initialization
		public float maxSpeed = 10f;
		public bool facingRight = true;

		Animator anim;

		public bool grounded = false;
		public Transform groundCheck;
		float groundRadius = 0.2f;
		public LayerMask whatIsGround;
		public float jumpForce = 20f;
		public float digLag = 0.1f;
		public float chargeLag = 0.25f;
		public float timeStamp = 1f;
		public float timeStampReset = 1f;

		public float eTailSlapLag = 1f;
		public float eTailSlapLagReset = 1f;
		public bool eSealBusyTailslapping = false;

		public float noseFlipLag = 0.5f;
		public float noseFlipLagReset = 0.5f;
		public bool sealBusyNoseFlipping = false;

		public bool sealBusyGrabbing = false;
		public float sealGrabLag = 0.5f;
		public float sealGrabLagReset = 0.5f;
		public bool sendingNoseGrab = false; //boolean link to nosegrabber.cs

		public bool onSnow = false;
		public Transform snowCheck;
		float snowRadius = 1f;
		public LayerMask whatIsIce;


		public bool sealBusyDigging = false;
//		public bool sealDigTimerOn = false;
		public float sealDiggingLag = 1.95f;
		public float sealDiggingLagReset = 1.95f;

		public float busyFlippingLag = 2f;
		public float busyFlippingLagReset = 2f;

		public bool upSideDown = false;
		public bool busyFlipping = false;
		public bool flipped = false;
		public bool flippingBack = false;

		//	public bool stealth = false;
		public float rollBackLag = 1.8f;
		public float rollBackLagReset = 1.8f;
		//	public bool sealBusy = false;

		public int zero = 0;

		public float bootHeadForce = 100;
		public float noseFlipForce = 100;

		public bool inMelee = false;
		public float distancex = 0f;
		public float distancey = 0f;
		public float initiativeTimer = 1f;
		public float initiativeTimerReset = 1f;

//		public float miscRand1 = 1f;
//		public float miscRand2 = 1f;
//		public float miscRand3 = 1f;
//		public float miscRand4 = 1f;
//		public float miscRand5 = 1f;
//		public float miscRand6 = 1f;


		public bool following = false;
		public float followTimer = 0.5f;
		public float followTimerReset = 0.5f;

		public float timeInMelee = 0f;
		public float timeInMeleeReset = 0f;

		public float attackDelay = 2f;
		public bool snowballtrigger = false;

		public bool sealDamaged = false;

		//TheType myArray = new TheType[lengthOfArray];  // declaration
//		public  fireControl = new var[4];


//propulsion

		public float move = 0f;

		public float startDelay = 5.0f;
		public float startDelayReset = 5.0f;
		public bool startTimer = true;

		public bool eFacingRight = false;

		void OnTriggerEnter2D (Collider2D col)
		{
				if (col.gameObject.tag == "Player") {
//						Debug.Log ("Player v Enemy!!!!!!*************");
						move = 0;
						inMelee = true;

				}
		}
//end propulsion
/*getting hit
			if (col.gameObject.tag == "tailslap") 
			{
				if (!GameObject.Find ("Character").GetComponent<SealControl2> ().facingRight) 
				{
					Debug.Log ("tailslap enemy facing right");
					bootHeadForce *= -1;
				} 
				else if (GameObject.Find ("Character").GetComponent<SealControl2> ().facingRight) 
				{
					Debug.Log ("tailslap enemy facing left");
				}
					GetComponent<Rigidbody2D>().AddForce (Vector2.right * bootHeadForce, ForceMode2D.Force);
					Debug.Log ("delivering boot the head vector");
					if (bootHeadForce < 0)
				{
					bootHeadForce *= -1;	
					Debug.Log ("bootHeadForce reset");
				}
			}
				if (col.gameObject.tag == "nose") 
				{
					GetComponent<Rigidbody2D>().AddForce (Vector2.up * noseFlipForce, ForceMode2D.Force);
					Debug.Log ("noseflip triggered.");
				}
		}

		void OnTriggerExit2D (Collider2D col)
		{
			if (col.gameObject.tag == "Player") {
//				Debug.Log ("Melee = False");
//				move = 0;
//				inMelee = false;
				}
		}
		
//end getting hit
*/
		void Start () 
		{
			anim = GetComponent<Animator> ();
			initiativeTimer = Random.Range (5, 10);
			initiativeTimerReset = initiativeTimer;
			
//			miscRand1 = Random.Range (1, 3);
//			miscRand2 = Random.Range (1, 3);
//			miscRand3 = Random.Range (1, 3);
//			miscRand4 = Random.Range (1, 3);
//			miscRand5 = Random.Range (1, 3);
//			miscRand6 = Random.Range (1, 3);
			followTimer = Random.Range (1,3);
			followTimerReset = Random.Range (1,3);
//			Debug.Log ("Random.Range (1, 10) = " + initiativeTimer);
		}

		void FixedUpdate () 
		{
			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool("Ground", grounded);
			anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

//			float move = Input.GetAxis ("Horizontal");
//			int move = -1;

			anim.SetFloat("Speed", Mathf.Abs (move));
			
			GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);	
			
			if (move > 0 && !facingRight)
				Flip ();
			else if (move < 0 && facingRight)
				Flip ();	

			onSnow = Physics2D.OverlapCircle (snowCheck.position, snowRadius, whatIsIce);
		}


		void Update () 
		{

//**********PROPULSION**********

			if (startTimer == true) 
			{
				startDelay = initiativeTimer -= Time.deltaTime;				
			}
//				Debug.Log ("startDelay = " + startDelay);

			distancex = transform.position.x - GameObject.Find ("Character").GetComponent<Transform> ().position.x;
			distancey = transform.position.y - GameObject.Find ("Character").GetComponent<Transform> ().position.y;
//			Debug.Log ("DISTANCE: " + distance);
			
			if (startDelay < 0) 
			{
				startTimer = false;
				move = -.2f;
				startDelay = startDelayReset;
			}
//find the character's translate component, compare x coordinates, adjust facing.
//				if (GetComponent<transform.position.x>() < GameObject.Find ("Character").GetComponent<transform.position.x> ())

//			Debug.Log ("Enemy.x = " + transform.position.x);//
//			Debug.Log ("Player.x = " + GameObject.Find ("Character").GetComponent<Transform>().position.x);
//			Debug.Log ("inMelee = " + inMelee);

			if (transform.position.x < GameObject.Find ("Character").GetComponent<Transform> ().position.x) 
			{
//				Debug.Log ("Player is to the right of Enemy 1");
				eFacingRight = true;
				if (!facingRight)
				Flip ();
//				Follow ():
			} 
			else 
			{						
//				Debug.Log ("Player is to the left of Enemy 1");
				eFacingRight = false;
				if (facingRight)
				Flip ();
//				Follow ():
			}
//follow
//distance = 1.86 @ contact
// melee = true, melee = not true
//				public bool following = false;
//				public float followTimer = 0.5f;
//				public float followTimerReset = 0.5f;


			if (grounded && !startTimer) //@!Melee
				if (distancex < -3)
				{
					followTimer -= Time.deltaTime;
					if (followTimer < 0)
					{
						move = 0.2f;
						following = true;
					}
					}	

				else if (distancex > 3)										
				{
					followTimer -= Time.deltaTime;
					if (followTimer < 0)
					{
						move = -0.2f;
						following = true;
					}
				}



//**********END PROPULSION**********
			//each function call checks outside of update for a boolean. if that boolean is true, run the code inside of update corresponding to the boolean. the question is... 
			Tailslap ();	//fixed
			DigSnowBall ();
			NuzzleGrab ();
			NoseFlip ();
			BellyUp (); //fix me!
//			BellyDown ();
//			MoveTimer ();
//			Follow ();

//FIRE CONTROL
			if (inMelee == true)
			{
				attackDelay -= Time.deltaTime;					//TIME BETWEEN ATTACKS
				timeInMelee += Time.deltaTime;
				if (attackDelay < 0)								//ATTACK!!!
				{
					DoAttack ();				
					initiativeTimer = initiativeTimerReset;
					attackDelay = Random.Range (2,4);
				}
			}
//end FIRE CONTROL

//			if (grounded && Input.GetButtonDown ("Vertical")) 
//			{
//				anim.SetBool ("Ground", false);
//				GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpForce));
//			}

//NOSEFLIP
/*
			if (sealBusyNoseFlipping == true)
			{
				noseFlipLag -= Time.deltaTime;
				anim.SetBool ("NoseFlip", true);
				if (Input.GetButtonDown ("Fire3")) 
				{									   //buttonmashing snippet
					anim.SetBool ("NoseFlip", true);
					anim.PlayInFixedTime ("noseflip");
					noseFlipLag = noseFlipLagReset;
				}										
			}
			if (noseFlipLag < 0)
			{	
				anim.SetBool (("NoseFlip"), false);
				noseFlipLag = noseFlipLagReset;
				sealBusyNoseFlipping = false;
			}				
*/	
//END NOSEFLIP

//NOSEGRAB
/*
			if (sealBusyGrabbing == true)
			{
				sendingNoseGrab = true;
				sealGrabLag -= Time.deltaTime;
				anim.SetBool ("Charging", true);
				if (Input.GetButtonDown ("Fire2")) 
				{									   //buttonmashing snippet
					anim.SetBool ("Charging", true);
					anim.PlayInFixedTime ("bullrush");
					sealGrabLag = sealGrabLagReset;
				}										
			}
			if (sealGrabLag < 0)
			{	
				anim.SetBool (("Charging"), false);
				sealGrabLag = sealGrabLagReset;
				sealBusyGrabbing = false;
			}				

//END NOSEGRAB
*/
//DIG SNOWBALL
/*
			if (sealBusyDigging == true)
			{
				sealDiggingLag -= Time.deltaTime;
				anim.SetBool ("Digtrigger", true);

//				if (Input.GetButtonDown ("Fire1")) 
//				{						buttonmashing snippet
//					anim.SetBool ("Digtrigger", true);
//					anim.PlayInFixedTime ("digging");
//					sealDiggingLag = sealSiggingLagReset;
//				}										
			}
			if (sealDiggingLag < 0)
			{	
				anim.SetBool (("Digtrigger"), false);
				sealDiggingLag = sealDiggingLagReset;
				sealBusyDigging = false;
			}				
*/
//END DIG SNOWBALL




				//		if (flipped == false) 
				//		{
				//			anim.speed = 1;
				//		}

		}											//END UPDATE

		public void DoAttack() {
				if (flipped || sealDamaged) 
				{
						BellyUp ();
						busyFlipping = true;
				}
				else switch (Random.Range (0, 4)) 
				{
				case 0:
						Tailslap();
						eSealBusyTailslapping = true;
//						Debug.Log ("Tailslap!");
						break;
				case 1: 
						DigSnowBall ();
						sealBusyDigging = true;
//						Debug.Log ("DigSnowball!");
						break;
				case 2: 
						BellyUp ();
						busyFlipping = true;
//						Debug.Log ("Belly Up!");
//						NuzzleGrab();
//						Debug.Log ("NuzzleGrab!");
						break;
				case 3: 
						sealBusyNoseFlipping = true;
						NoseFlip(); 
//						Debug.Log ("NoseFlip!");
						break;
				default:
						//						Tailslap();
//						Debug.Log ("DerpDerp!");
						break;
				}
		}


		public void Flip ()
		{
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}

		public void Tailslap ()
		{
			if (eSealBusyTailslapping == true)
			{
//						Debug.Log ("tailslapfunction true");
				
						eTailSlapLag -= Time.deltaTime;
//						Debug.Log ("counter works");
						anim.SetBool ("Tailslap", true);
//			if (Input.GetButtonDown ("Tailslap")) 
//				{									   //buttonmashing snippet
//				anim.SetBool ("Tailslap", true);
//				anim.PlayInFixedTime ("tailslap");
//				tailSlapLag = tailSlapLagReset;
//				}										
//			}
				if (eTailSlapLag < 0) 
				{	
					anim.SetBool (("Tailslap"), false);
					eTailSlapLag = eTailSlapLagReset;
					eSealBusyTailslapping = false;
				}
			}
			
				//END TAILS				LAP
		}

		public void DigSnowBall ()
		{
			if (sealBusyDigging && onSnow) 
			{
				anim.SetBool ("Digtrigger", true);
			}

			if (sealBusyDigging) 
			{
				sealDiggingLag -= Time.deltaTime;
			}

			if (sealDiggingLag < 0) 
			{									
				anim.SetBool (("Digtrigger"), false);
				sealDiggingLag = sealDiggingLagReset;
				sealBusyDigging = false;
			}				
		}


		public void NuzzleGrab ()
		{
			if (sealBusyGrabbing == true)
			{
				sendingNoseGrab = true;
				sealGrabLag -= Time.deltaTime;
				anim.SetBool ("Charging", true);
				if (Input.GetButtonDown ("Fire2")) 
				{									   //buttonmashing snippet
					anim.SetBool ("Charging", true);
					anim.PlayInFixedTime ("bullrush");
					sealGrabLag = sealGrabLagReset;
				}										
			}
			if (sealGrabLag < 0)
			{	
				anim.SetBool (("Charging"), false);
				sealGrabLag = sealGrabLagReset;
				sealBusyGrabbing = false;
			}				


//				if (Input.GetButtonDown ("Fire2")) 
//				{
//						anim.SetBool ("Charging", true);
//						timeStamp = Time.time + chargeLag;
//				}
		}

		public void NoseFlip ()
		{
			if (sealBusyNoseFlipping == true)
			{
				noseFlipLag -= Time.deltaTime;
				anim.SetBool ("NoseFlip", true);
//				if (Input.GetButtonDown ("Fire3")) 
//				{									   //buttonmashing snippet
//					anim.SetBool ("NoseFlip", true);
//					anim.PlayInFixedTime ("noseflip");
//					noseFlipLag = noseFlipLagReset;
//				}										
			
			if (noseFlipLag < 0)
				{	
				anim.SetBool (("NoseFlip"), false);
				noseFlipLag = noseFlipLagReset;
				sealBusyNoseFlipping = false;
				}				

//				if (Input.GetButtonDown ("Fire3")) 
//				{
//					anim.SetBool ("NoseFlip", true);
//					timeStamp = Time.time + noseFlipLag;
//				}
			}
		}

		public void BellyUp ()
		{
				if (busyFlipping && !flipped) {
						busyFlippingLag -= Time.deltaTime;
						anim.SetBool ("busyFlipping", true);
//						anim.SetBool ("upSideDown", true);
//						Debug.Log (busyFlippingLag);
						if (busyFlippingLag < 0) {
								anim.SetBool ("upSideDown", true);
								anim.SetBool ("busyFlipping", false);
								flipped = true;
								busyFlippingLag = busyFlippingLagReset;
								busyFlipping = false;
								GetComponent<Rigidbody2D>().gravityScale = 2f;
								GetComponentInChildren<EnemyHealth>().regen = 0.05f;
//								upsideDown = true;
						}
				}

				if (busyFlipping && flipped) {
						rollBackLag -= Time.deltaTime;
//						anim.speed = -1;
						anim.SetBool ("busyFlippingBack", true);
						anim.SetBool ("upSideDown", false);
						anim.SetBool ("busyFlipping", false);
//						Debug.Log ("rollbacktimer = " + rollBackLag);
//						anim.SetBool ("upSideDown", true);
//						anim.SetBool ("busyFlipping", false);
						if (rollBackLag < 0) {
//							anim.SetBool ("busyFlippingBack", false);
//							anim.SetBool ("upSideDown", false);
							anim.SetBool ("busyFlipping", false);
							anim.SetInteger ("idleint", zero);
//							animator.SetFloat("Forward",v);
							flipped = false;
//							Debug.Log ("flip back complete");
							rollBackLag = rollBackLagReset;	
							busyFlipping = false;
							flippingBack = false;
							GetComponent<Rigidbody2D>().gravityScale = 1f;
							GetComponentInChildren<EnemyHealth>().regen = 0.01f;

							anim.speed = 1;
						}
				}
		}
//		public void BellyDown ()
//		{
//				if (busyFlipping && flipped) 
//				{
//						Debug.Log ("DERPDPERPERPERPDERPEPD");
//						flippingBack = true;
//				}
//		}


//		public void MoveTimer ()
//		{
//				if (timeStamp <= Time.time) {
//						anim.SetBool ("Digtrigger", false);
//						anim.SetBool ("Charging", false);
//						anim.SetBool ("Tailslap", false);
//						anim.SetBool ("NoseFlip", false);
						//			anim.SetBool ("busyFlipping", false);
						//			anim.SetBool ("busyFlippingBack", false);
//						timeStamp = timeStampReset;
						//			Debug.Log ("game time is " + Time.time);
						//			Debug.Log ("TIMESTAMP" + timeStamp);
//				}

//		}
		//problem with the colliders
		/*	public void FlipY ()
	{
		rigidbody2D.AddForce (Vector2.up * flipBump, ForceMode2D.Force);
		Vector3 yScale = transform.localScale;
		yScale.y *= -1;
		transform.localScale = yScale;
		Debug.Log ("FLIP Y ACTIVATED");
		Flip ();
	}
*/

}
