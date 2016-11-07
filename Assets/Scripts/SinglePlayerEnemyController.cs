using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SinglePlayerEnemyController : MonoBehaviour {


//	[SyncVar]
//	public NetworkInstanceId owner;

	public GameObject target;

	public float distancex;
	public float distancey;

	public bool grounded = false;
	public Animator anim;
	public GameObject groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float move;
	public float jumpForce = 250f;
	public float maxSpeed = 10f;

	public float initiativeTimer = 1f;
	public float initiativeTimerReset = 1f;

	public bool following = false;
	public float followTimer = 0.5f;
	public float followTimerReset = 0.5f;

	public int followvar;

	public float attackDelay = 2f;
	public float timeInMelee = 0f;
	public float timeInMeleeReset = 0f;

	public bool jumpTimer = false;
	public float jumpTimerDelay = 0.5f;
//	public bool jumpTimerDelayReset = 0.5f;

//	public bool following = false;
	public bool inMelee = false;

//	public bool onSnow = false;
//	public GameObject snowCheck;
//	float snowRadius = .5f;
//	public LayerMask whatIsIce;


//	[SyncVar]
	public bool facingRight = true;

//	[SyncVar]
	public float facingMult = 1f;

//propulsion

//		public float move = 0f;

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

	// Use this for initialization
	void Start () {
//		Debug.Log ("SINGLE PLAYER ENEMY CONTROLLER ACTIVATED");
		target = GameObject.FindGameObjectWithTag("Player");
		groundCheck = GameObject.FindGameObjectWithTag("groundcheck");
		anim = GetComponentInParent<Animator> ();
//		snowCheck = GameObject.FindGameObjectWithTag("onSnowCheck");
	}

	void FixedUpdate () 
		{
			grounded = Physics2D.OverlapCircle (groundCheck.transform.position, groundRadius, whatIsGround);
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

//			onSnow = Physics2D.OverlapCircle (snowCheck.transform.position, snowRadius, whatIsIce);
		}


	// Update is called once per frame
	void Update ()
		{
//**********PROPULSION**********

				if (startTimer == true) {
						startDelay = initiativeTimer -= Time.deltaTime;				
				}
//				Debug.Log ("startDelay = " + startDelay);

				distancex = transform.position.x - target.GetComponent<Transform> ().position.x;
				distancey = transform.position.y - target.GetComponent<Transform> ().position.y;
//			Debug.Log ("DISTANCE: " + distance);
			
				if (startDelay < 0) {
						startTimer = false;
						move = -.2f;
						startDelay = startDelayReset;
				}
//find the character's translate component, compare x coordinates, adjust facing.
//				if (GetComponent<transform.position.x>() < GameObject.Find ("Character").GetComponent<transform.position.x> ())

//			Debug.Log ("Enemy.x = " + transform.position.x);//
//			Debug.Log ("Player.x = " + GameObject.Find ("Character").GetComponent<Transform>().position.x);
//			Debug.Log ("inMelee = " + inMelee);

				if (transform.position.x < target.GetComponent<Transform> ().position.x) {
//						Debug.Log ("Player is to the right of Enemy 1");
						eFacingRight = true;
						if (!facingRight)
								Flip ();
//				move = .2f;
//				Follow (true):
				} else {						
//						Debug.Log ("Player is to the left of Enemy 1");
						eFacingRight = false;
						if (facingRight)
								Flip ();
//				move = -0.2f;
//				Follow (true):
				}

//				if ((distancex > 1) || (distancex < -1)) {
//						following = true;
//						Debug.Log ("FOLLOWING");
				followvar = Random.Range (1, 40);
				if (distancex > followvar)
						move = -0.2f;						
				if (distancex < (followvar *= -1))
						move = 0.2f;			
//				}
//follow
//distance = 1.86 @ contact
// melee = true, melee = not true
//				public bool following = false;
//				public float followTimer = 0.5f;
//				public float followTimerReset = 0.5f;


				if (grounded && !startTimer) { //@!Melee
						if (distancex < -3) {
								followTimer -= Time.deltaTime;
								if (followTimer < 0) {
										move = 0.2f;
										following = true;
										followTimer = followTimerReset;
								}
						} else if (distancex > 3) {
								followTimer -= Time.deltaTime;
								if (followTimer < 0) {
										move = -0.2f;
										following = true;
										followTimer = followTimerReset;
								}
						}
				}
				//distance = enemy - player
				// e 10 player 11 = -1
				// e 10	player 9  =  1
//	public bool jumpTimer = false;
//	public bool jumpTimerDelay = 0.5f;
//	public bool jumpTimerDelayReset = 0.5f;



				if ((distancey < 0) && (!jumpTimer))
				{
					jumpTimer = true;
					jumpTimerDelay = Random.Range (0,3);
//					GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));		
				}

				if (jumpTimer)
				{
					jumpTimerDelay -= Time.deltaTime;
					if (jumpTimerDelay < 0)
					{
						jumpForce = 250f;
						GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
						jumpTimer = false;
					}
				}
//FIRE CONTROL
		if (inMelee == true)
		{
			attackDelay -= Time.deltaTime;					//TIME BETWEEN ATTACKS
			timeInMelee += Time.deltaTime;
			if (attackDelay < 0)								//ATTACK!!!
			{
//				DoAttack ();				
				initiativeTimer = initiativeTimerReset;
				attackDelay = Random.Range (2,4);
			}
		}
//end FIRE CONTROL


	}
/*
	public void DoAttack() {
//				if (flipped || sealDamaged) 
//				{
//						BellyUp ();
//						busyFlipping = true;
//				}
//				else 
				switch (Random.Range (0, 4)) 
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
//						BellyUp ();
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
*/
	public void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		facingMult *= -1;
//		Vector3 healthBarScale = healthBar.transform.localScale; //derp
//		healthBarScale.x *= -1; //derp
	}

//	public void Follow (true)
//	{
//		int followDelay = Random.Range (1,5);
//
//	}

}
