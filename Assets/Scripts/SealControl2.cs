using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;
//using UnityEditor.Animations;

public class SealControl2 : NetworkBehaviour {
	// Use this for initialization

//	public GameObject healthBar;

	public int kills = 0;

	public float vSpeed;
	public bool landingSplat = false;

	[SyncVar]
	public NetworkInstanceId owner;

	[SyncVar]
	public string pname = "player";

	[SyncVar]
	public Color playerColor = Color.white;

//	public string netowner;

	public string pNumb;

	public float fatigue = 0;
	public float fatigueMax = 100f;

	public float move = 0f;

//	public float firstKeyPress = 0f;
//	public float lastKeyPress = 0f;
	public Vector2 bulletmove;

	public GameObject bulletPrefab;

	public Transform combat_bulletSpawn;

	public GameObject tail_slap_bulletPrefab;
	public GameObject nose_flip_bulletPrefab;
	public GameObject oar_chop_bulletPrefab;
	public GameObject oar_tail_bulletPrefab;
	public GameObject axe_chop_bulletPrefab;
	public GameObject axe_tail_bulletPrefab;
	public GameObject cutlass_chop_bulletPrefab;
	public GameObject cutlass_tail_bulletPrefab;

	public GameObject tailCollider;

	public float maxSpeed = 10f;

//	public bool bulletFacingRight;

//	[SyncVar(hook = "Flip")]
	[SyncVar]
	public bool facingRight = true;

	[SyncVar]
	public float facingMult = 1f;

//	[SyncVar(hook = "TailslapCallback")]
//	public bool netTailTrigger = false;

	Animator anim;

//gotomouse
	private Vector3 target;
	public float speed = 1.5f;

//end gotomouse

	public bool grounded = false;

	[SyncVar (hook = "LandingSplatCallback")]
	public bool netGrounded = false;

	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 20f;

	public bool runJumpTimer = false;
	public float jumpTimer = 1.2f;
	public float jumpTimerReset = 1.2f;

	public int jumpCount = 0;	

	public bool bullRushAirTimer = false;
	public float bullRushAirTime = 0f;

	public bool bullRushTimer = false;
	public float bullTimer = 0.5f;
	public float bullTimerReset = 0.5f;

	public float bullRushHorizontalForce = 1800f;
	public float bullRushHorizontalForceReset = 1800f;
	public float bullRushVerticalForce = 5f;

	public bool bullRushCoolDownTimer = false;
	public float bullRushCoolDown = 3f;
	public float bullRushCoolDownReset = 3f;
//	public float digLag = 0.1f; //old snowball

	public bool blocking = false;

	public float chargeLag = 0.25f;
	public float timeStamp = 1f;
	public float timeStampReset = 1f;


	public bool cutlassTailBulletTimer = false;
	public float cutlassTailBulletDelay = 0.15f;
	public float cutlassTailBulletDelayReset = 0.15f;

	public bool cutlassChopBulletTimer = false;
	public float cutlassChopBulletDelay = 0.15f;
	public float cutlassChopBulletDelayReset = 0.15f;

	public bool axeTailBulletTimer = false;
	public float axeTailBulletDelay = 0.3f;
	public float axeTailBulletDelayReset = 0.3f;

	public bool axeChopBulletTimer = false;
	public float axeChopBulletDelay = 0.3f;
	public float axeChopBulletDelayReset = 0.3f;

	public bool oarChopBulletTimer;
	public float oarChopBulletDelay = 0.5f;
	public float oarChopBulletDelayReset = 0.5f;

	public bool oarTailSlapBulletTimer = false;
	public float oarTailSlapBulletDelay = 0.25f;
	public float oarTailSlapBulletDelayReset = 0.25f;
	public float oarTailBulletLife = 0.3f;

	public float tailSlapAnimDur = 0.533f;
	public bool tailTrigger = false;

	public bool tailSlapBulletTimer = false;
	public float tailSlapBulletDelay = 0.3f;
	public float tailSlapBulletDelayReset = 0.3f;


	public float tailSlapLifeSpan = 0.2f;
	public float tailSlapRange = 0.15f;
//	public float tailSlapLag = 1f;
//	public float tailSlapLagReset = 1f;
//	public bool sealBusyTailslapping = false;

	public bool	noseFlipBulletTimer = false;
	public float noseFlipBulletDelay = 0.5f;
	public float noseFlipBulletDelayReset = 0.5f;

	public float noseFlipAnimDur = 1f;
	public float noseFlipLifeSpan = 0.25f;
/*
	public bool noseFlipPwrTimer = false;
	public float noseFlipPwr = 100f;
	public float noseFlipPwrReset = 100f;

	[SyncVar]
	public float noseFlipPwrSend = 100f;
//	public float noseFlipLag = 0.5f;
//	public float noseFlipLagReset = 0.5f;
//	public bool sealBusyNoseFlipping = false;
*/
	public bool sealBusyGrabbing = false;
	public float sealGrabLag = 0.5f;
	public float sealGrabLagReset = 0.5f;

	public bool onSnow = false;
	public Transform snowCheck;
	float snowRadius = .5f;
	public LayerMask whatIsIce;

//	public bool sealBusyDigging = false;
//	public float sealDiggingLag = 1.95f;
//	public float sealDiggingLagReset = 1.95f;
//	public bool digTimerBool = false;

	public float snowballVertOffSet = 0.5f;
	public float snowballInvokeTimer = 1.8f;

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

	[SyncVar(hook = "PowerUp_Oar_Callback")]
    public bool netHasOar = false;

    public bool hasOar = false;

	[SyncVar(hook = "PowerUp_Axe_Callback")]
    public bool netHasAxe = false;

	public bool hasAxe = false;

	[SyncVar(hook = "PowerUp_Tricorn_Callback")]
    public bool netHasTricorn = false;

	public bool hasTricorn = false;

	[SyncVar(hook = "PowerUp_Cutlass_Callback")]
    public bool netHasCutlass = false;

	public bool hasCutlass = false;

	[SyncVar(hook = "PowerUp_Frogmouth_Callback")]
	public bool netHasFrogmouth = false;

	public bool hasFrogmouth = false;

	public bool sealDamaged = false;

	Player_SyncPosition syncPos;

//	TailTriggerController tailTrig;


	public override void OnStartLocalPlayer()
    {
//        GetComponent<MeshRenderer>().material.color = Color.red;
        GetComponent<SpriteRenderer>().color = playerColor;
		Camera.main.GetComponent<CameraRunner>().target=transform; //Fix camera on "me"
    }

	void Start () 
	{
//		GameObject go = this.gameObject;
//		GameObject moo = GameObject.FindGameObjectWithTag("masterderp");
//		moo.GetComponent<MasterDerp> ().GosAdd (go);

//				gos.Add(go);
  //           m_instanceMap[go.GetInstanceID()] = go;
 
//		transform.position = new Vector2(-5, 5);
		anim = GetComponent<Animator> ();
//gotomouse	
		anim.SetLayerWeight(0,1);
		target.x = transform.position.x;
//end gotomouse

	}

	void Awake ()
	{
//		pNumb = GetComponent<NetManSimple> ().GetPlayerNumber();
        syncPos = GetComponent<Player_SyncPosition>();
//        pNumb = GetComponent<NetworkManager> ().;
//      tailTrig = GetComponent<TailTriggerController>();
//		Debug.Log (anim.GetLayerIndex);




                        
	}

	void FixedUpdate ()
		{
			if (!isLocalPlayer)
				return;

//			if (hasOar)
//			anim.SetBool ("has_oar", true);

			vSpeed = GetComponent<Rigidbody2D> ().velocity.y;

			if (vSpeed < -3)
				landingSplat = true;

			grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
			anim.SetBool ("Ground", grounded);
			anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D> ().velocity.y);
						
			move = Input.GetAxis ("Horizontal");		
			anim.SetFloat ("Speed", Mathf.Abs (move));
		
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D> ().velocity.y);	
			bulletmove = GetComponent<Rigidbody2D> ().velocity;

			if ((move > 0 && !facingRight) || (move < 0 && facingRight)) 
			{
				Flip ();
				syncPos.CmdFlipSprite(facingRight);
			}

		onSnow = Physics2D.OverlapCircle (snowCheck.position, snowRadius, whatIsIce);

		}
	void Update ()
		{
				if (!isLocalPlayer)
						return;

//				if (!NetworkServer.active)
//						return;

				// it hurts when it lands
				if (landingSplat) {
						if (grounded) 
						{
								anim.SetBool ("landingSplat", true);
								landingSplat = false;
								Cmd_LandingSplat (grounded);
						}
				}
					

				if (flipped)
						fatigue -= 1;

				if ((flipped) && (fatigue < 0)) {
						flippingBack = true;
						fatigue = 1;
				}

				if (Input.GetButtonDown ("Fire1")) { 
//						fatigue += 25;
						Cmd_Shoot ();
//						Invoke ("Cmd_Spawn_SnowBall", 1.8f);						
						Animate_Dig ();
//						Inception_Snowball ();
				}

				if (Input.GetButton ("Fire2")) {
//						fatigue += 1;
						anim.SetBool ("block", true);
						blocking = true;
				}

				if (Input.GetButtonUp ("Fire2")) {
						anim.SetBool ("block", false);
						blocking = false;
				}

				Tailslap ();	//fixed
//				DigSnowBall (); //fixed
//				NuzzleGrab ();  //fixed
				NoseFlip ();	//fixed
				BellyUp ();		//fixed
				BellyDown ();
//		MoveTimer ();

//		sealDamaged ? busyFlipping : flippingBack;
//				if (sealDamaged)
//						busyFlipping = true;
//				else
//						flippingBack = true;

//jump & doublejump
				if (grounded && Input.GetButtonDown ("Vertical")) {
						anim.SetBool ("Ground", false);
						GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));			
						runJumpTimer = true;
						jumpCount++;
				}
				//jumpTimer = 1.2, doubletab up = superjump
				if (runJumpTimer == true) {
						jumpTimer -= Time.deltaTime;
						if (Input.GetButtonDown ("Vertical")) {
								if (jumpTimer < 1.1 && jumpTimer > 0.4 && jumpCount < 2) {
										GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
										jumpCount++;
								} else if (jumpTimer < 0.4) {
								}
						}

						if ((jumpTimer < 0) && grounded) {
								runJumpTimer = false;
								jumpTimer = jumpTimerReset;
								jumpCount = 0;
						}
				}

//AXE CHOP
				if (Input.GetButtonDown ("Fire3") && hasAxe) {
//						fatigue += 10;
						Axe_Chop ();
						axeChopBulletTimer = true;
				}

//AXE TAIL		
				if (Input.GetButtonDown ("Tailslap") && hasAxe) {
						Axe_Tail ();
						axeTailBulletTimer = true;
				}

//CUTLASS CHOP				
				if (Input.GetButtonDown ("Fire3") && hasCutlass) {
//						fatigue += 10;
						Cutlass_Chop ();
						cutlassChopBulletTimer = true;
				}				

//CUTLASS TAIL	
				if (Input.GetButtonDown ("Tailslap") && hasCutlass) {
						Cutlass_Tail ();
						cutlassTailBulletTimer = true;
				}


//OAR CHOP
				if (Input.GetButtonDown ("Fire3") && hasOar) {
//						fatigue += 10;
//						anim.SetBool ("oar_chop", true);
						
						Oar_Chop ();
						oarChopBulletTimer = true;
//						Cmd_Fire_Oar_Chop ();//OarChopBulletDelay
				}
//OAR TAILSLAP
				if (Input.GetButtonDown ("Tailslap") && hasOar) {
//						fatigue += 8;
						Oar_Tailslap ();
						oarTailSlapBulletTimer = true;
//						Cmd_Fire_Oar_Tail ();
				}	

//NOSEGRAB
/*
				if (sealBusyGrabbing == true) {
						sealGrabLag -= Time.deltaTime;
						anim.SetBool ("Charging", true);
						if (Input.GetButtonDown ("Fire2")) {									   //buttonmashing snippet
								anim.SetBool ("Charging", true);
								anim.PlayInFixedTime ("bullrush");
								sealGrabLag = sealGrabLagReset;
						}										
				}
				if (sealGrabLag < 0) {	
						anim.SetBool (("Charging"), false);
						sealGrabLag = sealGrabLagReset;
						sealBusyGrabbing = false;
				}				
*/
//END NOSEGRAB


				if (busyFlipping == true) {
						busyFlippingLag -= Time.deltaTime;
						anim.SetBool ("busyFlipping", true);
//			anim.SetBool ("upSideDown", true);
//			Debug.Log (busyFlippingLag);
						if (busyFlippingLag < 0) {
								anim.SetBool ("upSideDown", true);
								anim.SetBool ("busyFlipping", false);
								flipped = true;
								busyFlippingLag = busyFlippingLagReset;
								busyFlipping = false;
								GetComponent<Rigidbody2D> ().gravityScale = 2f;
//				GetComponentInChildren<SealHealth>().regen = 0.05f;
								//upsideDown = true;
						}
				}

				if (flippingBack == true) {
						rollBackLag -= Time.deltaTime;

//			anim.speed = -1;
						anim.SetBool ("busyFlippingBack", true);
						anim.SetBool ("upSideDown", false);
						anim.SetBool ("busyFlipping", false);
//			Debug.Log ("rollbacktimer = " + rollBackLag);
//			anim.SetBool ("upSideDown", true);
//			anim.SetBool ("busyFlipping", false);
						if (rollBackLag < 0) {
//				anim.SetBool ("busyFlippingBack", false);
//				anim.SetBool ("upSideDown", false);
								anim.SetBool ("busyFlipping", false);
								anim.SetInteger ("idleint", 0);
//				animator.SetFloat("Forward",v);
								flipped = false;
//				Debug.Log ("flip back complete");
								rollBackLag = rollBackLagReset;
								flippingBack = false;
								GetComponent<Rigidbody2D> ().gravityScale = 1f;
//				GetComponentInChildren<SealHealth>().regen = 0.01f;
								anim.speed = 1;
						}
				}

//		if (flipped == false) 
//		{
//			anim.speed = 1;
//		}
/*
				//variable noseflip pwr for snowball
				if (Input.GetButton ("Fire3") && !flipped && !hasOar)
					noseFlipPwrTimer = true;

				if (noseFlipPwrTimer)
					noseFlipPwr += 20f;

				if (Input.GetButtonUp ("Fire3") && !flipped && !hasOar) 
				{
					noseFlipPwrSend = noseFlipPwr;
					noseFlipPwr = noseFlipPwrReset;
					noseFlipPwrTimer = false;
				}
*/
//**************************************CLUNKY BULLET TIMERS **************************************
				if (tailSlapBulletTimer)
						tailSlapBulletDelay -= Time.deltaTime;
				
				if (tailSlapBulletDelay < 0) {
						Cmd_Fire_Tail_Slap ();
						tailSlapBulletDelay = tailSlapBulletDelayReset;
						tailSlapBulletTimer = false;	
				}

				if (noseFlipBulletTimer)
						noseFlipBulletDelay -= Time.deltaTime;

				if (noseFlipBulletDelay < 0) {
						Cmd_Fire_Nose_Flip ();
						noseFlipBulletDelay = noseFlipBulletDelayReset;
						noseFlipBulletTimer = false;
				}

				if (oarChopBulletTimer)
						oarChopBulletDelay -= Time.deltaTime;

				if (oarChopBulletDelay < 0) {
						Cmd_Fire_Oar_Chop ();
						oarChopBulletDelay = oarChopBulletDelayReset;
						oarChopBulletTimer = false;
				}

				if (oarTailSlapBulletTimer)
						oarTailSlapBulletDelay -= Time.deltaTime;

				if (oarTailSlapBulletDelay < 0) {
						Cmd_Fire_Oar_Tail ();
						oarTailSlapBulletDelay = oarTailSlapBulletDelayReset;
						oarTailSlapBulletTimer = false;
				}

				if (axeChopBulletTimer)
						axeChopBulletDelay -= Time.deltaTime;

				if (axeChopBulletDelay < 0) {
						Cmd_Fire_Axe_Chop ();
						axeChopBulletDelay = axeChopBulletDelayReset;
						axeChopBulletTimer = false;
				}

				if (axeTailBulletTimer)
						axeTailBulletDelay -= Time.deltaTime;

				if (axeTailBulletDelay < 0) {
						Cmd_Fire_Axe_Tail ();
						axeTailBulletDelay = axeTailBulletDelayReset;
						axeTailBulletTimer = false;
				}

				if (cutlassChopBulletTimer)
						cutlassChopBulletDelay -= Time.deltaTime;

				if (cutlassChopBulletDelay < 0) {
						Cmd_Fire_Cutlass_Chop ();
						cutlassChopBulletDelay = cutlassChopBulletDelayReset;
						cutlassChopBulletTimer = false;
				}

				if (cutlassTailBulletTimer)
						cutlassTailBulletDelay -= Time.deltaTime;

				if (cutlassTailBulletDelay < 0) {
						Cmd_Fire_Cutlass_Tail ();
						cutlassTailBulletDelay = cutlassTailBulletDelayReset;
						cutlassTailBulletTimer = false;
				}

//**************************************END CLUNKY BULLET TIMERS **************************************
//	public bool bullRushTimer = false;
//	public float bullTimer = 0.25f;
//	public float bullTimerReset = 0.25f;

//	public int bullCount = 0;

//	public bool bullRushAirTimer = false;
//	public float bullRushAirTime = 0f;


				if (Input.GetButtonUp ("Horizontal") && !bullRushTimer) {
				//		if (move < 0) 
				//			firstKeyPress = -1;
				//		else
				//			firstKeyPress = 1;

						bullRushTimer = true;
						Debug.Log ("buttonuphorizontal");

//						bullCount++;
				}

				if (bullRushTimer)
						bullTimer -= Time.deltaTime;


				if (Input.GetButtonDown ("Horizontal") && bullRushTimer && !bullRushCoolDownTimer) {
						bullRushTimer = false;
				//		if (move < 0)
				//			lastKeyPress = -1;
				//		else
				//			lastKeyPress = 1;

				//		if (firstKeyPress != lastKeyPress)
				//			return;

						if (!grounded)
							bullRushHorizontalForce = bullRushHorizontalForce * 2;


						if ((bullTimer > 0) && (bullTimer < 0.5)) {							//	GetComponent<Rigidbody2D> ().velocity = new Vector2 (move * maxSpeed * 100, GetComponent<Rigidbody2D> ().velocity.y);	
								if (facingRight) {
									
										GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bullRushHorizontalForce, bullRushVerticalForce));
										//	Debug.Log ("bullrush right!");	
//										bullRushAirTimer = true;
										bullRushHorizontalForce = bullRushHorizontalForceReset;
										bullRushCoolDownTimer = true;
										//	GetComponent<Rigidbody2D> ().isKinematic = false;
								} else {
										GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bullRushHorizontalForce * -1, bullRushVerticalForce));
										//	Debug.Log ("bullrush left!!!");
//										bullRushAirTimer = true;
										bullRushHorizontalForce = bullRushHorizontalForceReset;
										bullRushCoolDownTimer = true;
										//	GetComponent<Rigidbody2D> ().isKinematic = false;
								}
						}
//				if (bullRushAirTimer)
//					bullRushAirTime += Time.deltaTime;
				}

				if (bullRushCoolDownTimer)
						bullRushCoolDown -= Time.deltaTime;

				if (bullRushCoolDown < 0) {
						bullRushCoolDownTimer = false;
						bullRushCoolDown = bullRushCoolDownReset;
				}
//				if (bullRushAirTime > 3) 
//				{
//					bullRushAirTimer = false;
//					bullRushAirTime = 0;
				//	GetComponent<Rigidbody2D> ().isKinematic = true;
//				}

				if (bullTimer < 0) { // key timer for bullrush
						bullRushTimer = false;
						bullTimer = bullTimerReset;
				}
/*
				if (bullRushAirTime > 3 && !grounded && bullRushAirTimer)
						GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, bullRushVerticalForce * -0.5f));

				if (bullRushAirTime > 5) {
						bullRushAirTimer = false;
						bullRushAirTime = 0;
				}

				if (grounded) 
				{
					bullRushAirTimer = false;
					bullRushAirTime = 0;
				}
*/

				//FLYING TAILSLAP
				if ((Input.GetButtonDown ("Tailslap") || Input.GetButtonDown ("Fire3")) && !grounded && !bullRushCoolDownTimer) {
				float attackLuck = UnityEngine.Random.Range (1,4);
						if (facingRight) {
								GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bullRushHorizontalForce * attackLuck, bullRushVerticalForce));
								bullRushHorizontalForce = bullRushHorizontalForceReset;
								bullRushCoolDownTimer = true;
						} else {
								GetComponent<Rigidbody2D> ().AddForce (new Vector2 (bullRushHorizontalForce * -1 * attackLuck, bullRushVerticalForce));
								bullRushHorizontalForce = bullRushHorizontalForceReset;
								bullRushCoolDownTimer = true;
						}
				}
}			//******* end update *****               ******* end update ******				****** end update *****

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

	public void Tailslap ()
	{
		if (Input.GetButtonDown ("Tailslap")&& !flipped && !hasOar && !hasAxe && !hasCutlass)	
		{
//			fatigue += 5;
			tailSlapBulletTimer = true;
//			Cmd_Fire_Tail_Slap ();//tailSlapBulletDelay
//			anim.PlayInFixedTime ("tailslap");
			GetComponent<SpriteRenderer> ().sortingOrder = 1;
			anim.SetBool ("Tailslap", true);
			Invoke ("Stop_Tailslap_Anim", tailSlapAnimDur);
		}
	}


//	public void NuzzleGrab ()//instead of sending collider, maybe make collider bigger?
//	{
//		if (Input.GetButtonDown ("Fire2") && !flipped) 
//		{
//			sealBusyGrabbing = true;
//			anim.SetBool ("Charging", true);
//			timeStamp = Time.time + chargeLag;
//		}
//	}

	public void NoseFlip ()
	{
		if (Input.GetButtonDown ("Fire3") && !flipped && !hasOar && !hasAxe && !hasCutlass) 
		{
//			fatigue += 5;
			noseFlipBulletTimer = true;
//			Cmd_Fire_Nose_Flip ();//noseFlipBulletDelay
			GetComponent<SpriteRenderer> ().sortingOrder = 1;
			anim.SetBool ("NoseFlip", true);
			Invoke ("Stop_Nose_Flip", noseFlipAnimDur);
		}
	}

	public void BellyUp ()
	{
		if ((Input.GetButton ("Fire3")) && (Input.GetButton ("Fire2")) || (fatigue > fatigueMax))
		{
			busyFlipping = true;
		}
	}

	public void BellyDown ()
	{
		if ((Input.GetButton ("Fire3")) && (Input.GetButton ("Fire2")) && (flipped == true)) 
		{
//			Debug.Log ("DERPDPERPERPERPDERPEPD");
			flippingBack = true;
		}
		
	}

	[Command]
	public void Cmd_LandingSplat (bool grounded)
	{
		netGrounded = grounded;
		anim.SetBool ("landingSplat", true);
		Invoke ("Stop_LandingSplat", 0.167f);	
	}

	public void	LandingSplatCallback (bool grounded)
	{
		netGrounded = grounded;
		anim.SetBool ("landingSplat", true);
		Invoke ("Stop_LandingSplat", 0.167f);	
	}

	public void Stop_LandingSplat ()
	{
		anim.SetBool ("landingSplat", false);
	}

	[Command]
	public void Cmd_Shoot()
 	{
		Invoke ("Cmd_Spawn_SnowBall", snowballInvokeTimer);	
 	}

 	[Command]
 	void Cmd_Spawn_SnowBall ()
	{
//			float vertOffSet = 0.5f;
// 										create server-side instance
			Vector3 derp;
			bool der = GetComponent<Player_SyncPosition>().netFacingRight;
			derp = der ? Vector3.right : Vector3.left;
//			message = health > 0 ? "Player is Alive" : "Player is Dead";
			Vector3 snowBallBirthLoc = transform.position + derp + (Vector3.up * snowballVertOffSet);
			GameObject obj = (GameObject)Instantiate (bulletPrefab, snowBallBirthLoc, Quaternion.identity);
		// 											spawn on the clients
			NetworkServer.Spawn(obj);
	}

	public void Animate_Dig ()	//now only **client initiated/client side** animation doesn't work. 3/4 work.
	//(and yet old fashioned tail slap works on all 4...
	{

		anim.SetBool ("Digtrigger", true);
		Invoke ("Stop_Animate_Dig", 1.8f);
	}

	public void Stop_Animate_Dig ()
	{
		anim.SetBool ("Digtrigger", false);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
				if (col.gameObject.tag == "oarpowerup") {	
						hasOar = true;
						hasAxe = false;
						hasCutlass = false;
//						anim.SetBool ("has_oar", true);
						Debug.Log ("hasOar");
						anim.SetLayerWeight (0, 0);
						anim.SetLayerWeight (1, 1);
						anim.SetLayerWeight (2, 0);
						anim.SetLayerWeight (4, 0);
						Cmd_PowerUp_Oar (hasOar);
				}
				if (col.gameObject.tag == "axepowerup") {
						hasAxe = true;
						hasOar = false;
						hasCutlass = false;
//						anim.SetLayerWeight(1,1);
//						anim.SetBool ("has_axe", true);
						Debug.Log ("hasAxe");
						anim.SetLayerWeight (0, 0);
						anim.SetLayerWeight (1, 0);
						anim.SetLayerWeight (2, 1);
						anim.SetLayerWeight (4, 0);
						Cmd_PowerUp_Axe (hasAxe);

				}
				if (col.gameObject.tag == "tricorn") {
						hasTricorn = true;
						hasFrogmouth = false;
						anim.SetLayerWeight (3, 1);
						anim.SetLayerWeight (5, 0);
						Debug.Log ("tricorn");
						Cmd_PowerUp_Tricorn (hasTricorn);
				}
				if (col.gameObject.tag == "cutlass") {
						hasCutlass = true;
						hasOar = false;
						hasAxe = false;
						anim.SetLayerWeight (0, 0);
						anim.SetLayerWeight (1, 0);
						anim.SetLayerWeight (2, 0);
						anim.SetLayerWeight (4, 1);
						Debug.Log ("cutlass");
						Cmd_PowerUp_Cutlass (hasCutlass);
				}
				if (col.gameObject.tag == "frogmouth") {
						hasFrogmouth = true;
						hasTricorn = false;
						anim.SetLayerWeight (5, 1);
						anim.SetLayerWeight (3, 0);
						Debug.Log ("frogmouth");
						Cmd_PowerUp_Frogmouth (hasFrogmouth);
				}


	} 

	[Command]
	public void Cmd_PowerUp_Oar (bool hasOar)
	{
		netHasOar = hasOar;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 1);
		anim.SetLayerWeight (2, 0);
		anim.SetLayerWeight (4, 0);
	}

	public void PowerUp_Oar_Callback (bool hasOar)
	{
		netHasOar = hasOar;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 1);
		anim.SetLayerWeight (2, 0);
		anim.SetLayerWeight (4, 0);

	}

	[Command]
	public void Cmd_PowerUp_Axe (bool hasAxe)
	{
		netHasAxe = hasAxe;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 0);
		anim.SetLayerWeight (2, 1);
		anim.SetLayerWeight (4, 0);
	}

	public void PowerUp_Axe_Callback (bool hasAxe)
	{
		netHasAxe = hasAxe;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 0);
		anim.SetLayerWeight (2, 1);
		anim.SetLayerWeight (4, 0);

	}

	[Command]
	public void Cmd_PowerUp_Tricorn (bool hasTricorn)
	{
		netHasTricorn = hasTricorn;
		anim.SetLayerWeight (3, 1);	
		anim.SetLayerWeight (5, 0);
	}

	public void PowerUp_Tricorn_Callback (bool hasTricorn)
	{
		netHasTricorn = hasTricorn;
		anim.SetLayerWeight (3, 1);
		anim.SetLayerWeight (5, 0);
	}

	[Command]
	public void Cmd_PowerUp_Cutlass (bool hasCutlass)
	{
		netHasCutlass = hasCutlass;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 0);
		anim.SetLayerWeight (2, 0);
		anim.SetLayerWeight (4, 1);
	}

	public void PowerUp_Cutlass_Callback (bool hasCutlass)
	{
		netHasCutlass = hasCutlass;
		anim.SetLayerWeight (0, 0);
		anim.SetLayerWeight (1, 0);
		anim.SetLayerWeight (2, 0);
		anim.SetLayerWeight (4, 1);

	}

	[Command]
	public void Cmd_PowerUp_Frogmouth (bool hasFrogmouth)
	{
		netHasFrogmouth = hasFrogmouth;
		anim.SetLayerWeight (5, 1);	
		anim.SetLayerWeight (3, 0);
	}

	public void PowerUp_Frogmouth_Callback (bool hasFrogmouth)
	{
		netHasFrogmouth = hasFrogmouth;
		anim.SetLayerWeight (5, 1);
		anim.SetLayerWeight (3, 0);
	}



	public void Axe_Chop ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
		anim.SetBool ("NoseFlip", true);
		Invoke ("Stop_Axe_Chop", 0.583f);
		if (axeChopBulletTimer) { 
			anim.PlayInFixedTime ("seal_chop_axe", 2);
			axeChopBulletDelay = axeChopBulletDelayReset;
		}
				
	}

	public void Stop_Axe_Chop ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("NoseFlip", false);

	}

	public void Axe_Tail ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
		anim.SetBool ("Tailslap", true);
		Invoke ("Stop_Axe_Tail", 0.51f);
		if (axeTailBulletTimer) { 
				anim.PlayInFixedTime ("seal_tail_axe", 2);
				axeTailBulletDelay = axeTailBulletDelayReset;
		}

	}

	public void Stop_Axe_Tail ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("Tailslap", false);
	}

	public void Cutlass_Chop ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
		anim.SetBool ("NoseFlip", true);
		Invoke ("Stop_Cutlass_Chop", 0.583f);
		if (cutlassChopBulletTimer) { 
			anim.PlayInFixedTime ("seal_chop_cutlass", 4);
			cutlassChopBulletDelay = cutlassChopBulletDelayReset;
		}

	}

	public void Stop_Cutlass_Chop ()
	{
	//old api renderer.sortingOrder
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("NoseFlip", false);

	}

	public void Cutlass_Tail ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
		anim.SetBool ("Tailslap", true);
		Invoke ("Stop_Cutlass_Tail", 0.51f);

	}

	public void Stop_Cutlass_Tail ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("Tailslap", false);
	}


	public void Oar_Chop ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
//		GetComponent<SpriteRenderer> ().sortingLayerName = "ocean_front";
//		anim.PlayInFixedTime ("Noseflip"); //buttonmashing derp?
		anim.SetBool ("NoseFlip", true);
		Invoke ("Stop_Oar_Chop", 0.65f);
	}

	public void Stop_Oar_Chop ()
	{
	//old api renderer.sortingOrder
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("NoseFlip", false);

	}

	public void Oar_Tailslap ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 1;
//		anim.PlayInFixedTime ("oar_tail_slap");
		anim.SetBool ("Tailslap", true);
		Invoke ("Stop_Oar_Tailslap", 1f);
	}

	public void Stop_Oar_Tailslap ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("Tailslap", false);
	}

	public void Stop_Nose_Flip ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("NoseFlip", false);
	}

//	public void Run_Tailslap_Anim ()
//	{
//		anim.SetBool ("Tailslap", true);
//	}

	public void Stop_Tailslap_Anim ()
	{
		GetComponent<SpriteRenderer> ().sortingOrder = 0;
		anim.SetBool ("Tailslap", false);
	}



	[Command]
	public void Cmd_Fire_Tail_Slap ()
	{
//		Vector3 derp;
		bool der = GetComponent<Player_SyncPosition>().netFacingRight;
//		derp = der ? Vector3.right : Vector3.left;
//		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (derp * tailSlapRange);
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position;
		var bullet = (GameObject)Instantiate (tail_slap_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);  
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<tailslap_bullet_script> ().bulletFacingRight = der;
		owner = netId;
		bullet.GetComponent<tailslap_bullet_script> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, tailSlapLifeSpan);
	}

//		Vector3 snowBallBirthLoc = transform.position + derp + (Vector3.up * snowballVertOffSet);
//		GameObject obj = (GameObject)Instantiate (bulletPrefab, snowBallBirthLoc, Quaternion.identity);


	[Command]
	public void Cmd_Fire_Nose_Flip ()
	{	
//		Vector3 derp;
		bool der = GetComponent<Player_SyncPosition>().netFacingRight;
//		derp = der ? Vector3.right : Vector3.left;
//		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (derp * tailSlapRange);
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position;
		var bullet = (GameObject)Instantiate (nose_flip_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
//		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 1.3f * facingMult;
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<noseflip_bullet_script> ().bulletFacingRight = der;
		owner = netId;
		bullet.GetComponent<noseflip_bullet_script> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
//		Time.timeScale = 0f;
		Destroy(bullet, noseFlipLifeSpan);
	}

	[Command]
	public void Cmd_Fire_Oar_Chop ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (bulletPlacementVar * 1.4f);
//		Vector3 bulletSpawnLoc = combat_bulletSpawn.position;
		var bullet = (GameObject)Instantiate (oar_chop_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<oar_chop_bullet_script> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<oar_chop_bullet_script> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, 0.5f);
	}

	[Command]
	public void Cmd_Fire_Oar_Tail ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + bulletPlacementVar;
//		Vector3 bulletSpawnLoc = combat_bulletSpawn.position;
		var bullet = (GameObject)Instantiate (oar_tail_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);
//		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * 6 * facingMult;
//		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<Rigidbody2D>().velocity = bulletmove;
		bullet.GetComponent<oar_tail_bullet_script> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<oar_tail_bullet_script> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
       	Destroy(bullet, oarTailBulletLife);
	}

	[Command]
	public void Cmd_Fire_Axe_Chop ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (bulletPlacementVar * 1.4f);
		var bullet = (GameObject)Instantiate (axe_chop_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<axe_chop_bullet> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<axe_chop_bullet> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, 0.5f);
	}

	[Command]
	public void Cmd_Fire_Axe_Tail ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (bulletPlacementVar * 1.4f);
		var bullet = (GameObject)Instantiate (axe_tail_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<axe_tail_bullet> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<axe_tail_bullet> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, 0.5f);
	}

	[Command]
	public void Cmd_Fire_Cutlass_Chop ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (bulletPlacementVar * 1.4f);
		var bullet = (GameObject)Instantiate (cutlass_chop_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<cutlass_chop_bullet> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<cutlass_chop_bullet> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, 0.5f);

	}


	[Command]
	public void Cmd_Fire_Cutlass_Tail ()
	{
		Vector3 bulletPlacementVar;
		bool facingTempVar = GetComponent<Player_SyncPosition>().netFacingRight;
		bulletPlacementVar = facingTempVar ? Vector3.right : Vector3.left;
		Vector3 bulletSpawnLoc = combat_bulletSpawn.position + (bulletPlacementVar * 1.4f);
		var bullet = (GameObject)Instantiate (cutlass_tail_bulletPrefab, bulletSpawnLoc, combat_bulletSpawn.rotation);    	
		bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * move * 1.5f;
		bullet.GetComponent<cutlass_tail_bullet> ().bulletFacingRight = facingTempVar;
		owner = netId;
		bullet.GetComponent<cutlass_tail_bullet> ().bulletOwner = owner;		  	  	
		NetworkServer.Spawn(bullet);
	    Destroy(bullet, 0.5f);

	}
}
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


/*												goto mouse
		if (Input.GetMouseButtonDown (0)) 
		{ 
			if (EventSystem.current.IsPointerOverGameObject ()) 
			{
//			Debug.Log ("left-click over a GUI element!");
				anim.SetBool ("run", false);
//			speed = 0f;
			} 
			else 
			{
//			Debug.Log("just a left-click!");
				target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//			target.x = transform.position.x;
				anim.SetBool ("run", true);
				speed = 1.5f;
			}
		}

		transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);

		if (target.x == transform.position.x) 
		{
			speed = 0f;
			anim.SetBool ("run", false);
		}

		if (target.x < transform.position.x && facingRight)
			Flip ();
		else if (target.x > transform.position.x && !facingRight)
			Flip ();
//											end goto mouse
*/
/*				
	public void GlassDigSnowBall () //new
	{
		sealBusyDigging = true;												//animation
		GetComponentInChildren<SnowballLauncher> ().digtrigger = true;		//collider
	}

	public void GlassTailslap()
	{
		sealBusyTailslapping = true;										//animation
		GetComponentInChildren<TailTriggerController>().tailTrigger = true;	//collider
	}
	
	public void GlassNoseGrab ()
	{
		sealBusyGrabbing = true;
	}

		public void GlassNoseFlip ()
	{
		sealBusyNoseFlipping = true;										//animation
		GetComponentInChildren<NoseFlip>().noseTrigger = true;				//collider
	}

		public void GlassBellyUp()
	{
		busyFlipping = true;
	}

	public void GlassBellyDown()
	{
		flippingBack = true;
	}


//TAILSLAP
/*				if (sealBusyTailslapping == true) {
						
						tailSlapLag -= Time.deltaTime;
//			GetComponentInChildren<myTail> ().SetActive(true);
						anim.SetBool ("Tailslap", true);
						if (Input.GetButtonDown ("Tailslap")) {									   //buttonmashing snippet
								anim.SetBool ("Tailslap", true);
								anim.PlayInFixedTime ("tailslap");
								tailSlapLag = tailSlapLagReset;
						}										
				}

				if (tailSlapLag < 0) {	
						anim.SetBool (("Tailslap"), false);
						tailSlapLag = tailSlapLagReset;
						sealBusyTailslapping = false;
				}				
*/
//END TAILSLAP

//NOSEFLIP
/*
				if (sealBusyNoseFlipping == true) {
						noseFlipLag -= Time.deltaTime;
						anim.SetBool ("NoseFlip", true);
						if (Input.GetButtonDown ("Fire3")) {									   //buttonmashing snippet
								anim.SetBool ("NoseFlip", true);
								anim.PlayInFixedTime ("noseflip");
								noseFlipLag = noseFlipLagReset;
						}										
				}
				if (noseFlipLag < 0) {	
						anim.SetBool (("NoseFlip"), false);
						noseFlipLag = noseFlipLagReset;
						sealBusyNoseFlipping = false;
				}				
*/
//END NOSEFLIP

/*	public void Enable_Tailslap ()
	{

		tailCollider.GetComponent<BoxCollider2D> ().enabled = true;
	}

	public void Disable_Tailslap ()
	{
		tailTrigger = false;
		Stop_Tailslap_Anim ();
		tailCollider.GetComponent<BoxCollider2D> ().enabled = false;
	}

	[Command]
	public void Cmd_Enable_Tailslap ()
	{
		Debug.Log ("Cmd_Tailslap");
		tailCollider.GetComponent<BoxCollider2D> ().enabled = true;
	}

	[Command]
	public void Cmd_Disable_Tailslap ()
	{
		Stop_Tailslap_Anim ();
		tailTrigger = false;
		tailCollider.GetComponent<BoxCollider2D> ().enabled = false;
	}

	void TailslapCallback (bool netTailTrigger)
	{
		Debug.Log ("tailslap callback");
		netTailTrigger = tailTrigger;
		Run_Tailslap_Anim ();
		Invoke ("Enable_Tailslap", 0.25f);
		Invoke ("Disable_Tailslap", 0.53f);
		Invoke ("Stop_Tailslap_Anim", 0.53f);
	}
*/
//DIG SNOWBALL
/*
		if (sealBusyDigging == true) {
			digTimerBool = true;
			anim.SetBool ("Digtrigger", true);
			}

		if (digTimerBool) {
			sealDiggingLag -= Time.deltaTime;
			}

//			Debug.Log ("Dig Snowball!");
//			if (Input.GetButtonDown ("Fire1")) 
//			{						buttonmashing snippet
//				anim.SetBool ("Digtrigger", true);
//				anim.PlayInFixedTime ("digging");
//				sealDiggingLag = sealSiggingLagReset;
//			}										
		
		if (sealDiggingLag < 0)
		{	
			anim.SetBool (("Digtrigger"), false);
			sealDiggingLag = sealDiggingLagReset;
			sealBusyDigging = false;
			digTimerBool = false;
		}				

//END DIG SNOWBALL
*/
/*	public void MoveTimer ()
	{
		if (timeStamp <= Time.time) {
//			anim.SetBool ("Digtrigger", false);
//			anim.SetBool ("Charging", false);
//			anim.SetBool ("Tailslap", false);
//			anim.SetBool ("NoseFlip", false);
//			anim.SetBool ("busyFlipping", false);
//			anim.SetBool ("busyFlippingBack", false);
			timeStamp = timeStampReset;
			//			Debug.Log ("game time is " + Time.time);
			//			Debug.Log ("TIMESTAMP" + timeStamp);
		}

	}
*/

//}
