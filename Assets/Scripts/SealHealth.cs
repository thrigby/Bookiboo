using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class SealHealth : NetworkBehaviour {

//	public Slider slider;
//	public Image Fill;

	public const int maxHealth = 100;
    public bool destroyOnDeath;

//    public float knockbackHitForce = 100f;
	public float knockbackBumpForce = 50f;

//    public bool collisionListener = true;
//    public float collisionTimer = 1f;
//    public float collisionTimerReset = 1f;


    public float gettingHitTimer = 2f;
    public float gettingHitTimerReset = 2f;

    public bool isBlocking = false;
   
//    public GameObject colO;

    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    [SyncVar(hook = "StopHit")]
	public bool gettingHit = false;

	[SyncVar(hook = "Dying")]
	public bool dying = false;

	[SyncVar(hook = "Dead")]
	public bool dead = false;

	[SyncVar]
	public NetworkInstanceId lastHitBy;


	[SyncVar]
	public GameObject murderer;

	public GameObject killer;
//	[SyncVar (hook = "KnockbackCallback")]
	public bool gettingKnockedback = false;

    public RectTransform healthBar;
//    public float lockPos = 0f;

    private NetworkStartPosition[] spawnPoints;	

    public float dyingTimer = 2f;
    public float dyingTimerReset = 2f;
//   public bool dying = false;

    public float deadTimer = 2f;
    public float deadTimerReset = 2f;
//    public bool dead = false;

    Animator anim;

//    public RectTransform Richard;
//it just might be time for Physics.OverlapSphere(player.transform+(player.transform.forward*range),range, LayerMask.GetMask("player","zombie","destructible"))
//var distance = Vector3.Distance(object1.transform.position, object2.transform.position);


/*    void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "tailslap" && collisionListener) 
		{
			colO = col.gameObject;
			Debug.Log (colO);
			collisionListener = false;
			TakeDamage (10);
			anim.SetBool ("take_damage", true);
			if (col.gameObject.GetComponentInParent<Player_SyncPosition> ().netFacingRight == true) 
			{
				GetComponent<Rigidbody2D> ().AddForce (Vector2.right * tailslapHitForce, ForceMode2D.Force);
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * tailslapBumpForce, ForceMode2D.Force);
			} 
			else 
			{
				GetComponent<Rigidbody2D> ().AddForce (Vector2.left * tailslapHitForce, ForceMode2D.Force);
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * tailslapBumpForce, ForceMode2D.Force);
			}
		}
	}
*/
	void Awake ()
	{
		anim = GetComponentInParent<Animator> ();


	}


    void Start ()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
    }

    void Update ()
		{		

				isBlocking = GetComponentInParent<SealControl2> ().blocking;

//		Richard.pivot = Vector2.zero;
//	     	transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, lockPos, lockPos);

//		slider.value = currentHealth;


				if (dying == true) 
				{
						dyingTimer -= Time.deltaTime;
//						anim.SetBool ("take_damage", false);
//						anim.SetBool ("dying", true);
						Dying (dying);
				}
				if (dyingTimer < 0) 
				{
						dying = false;
						dyingTimer = dyingTimerReset;
						dead = true;
				}

				if (dead == true) 
				{
						deadTimer -= Time.deltaTime;
//						anim.SetBool ("take_damage", false);
//						anim.SetBool ("dying", false);
//						anim.SetBool ("dead", true);
						Dead (dead);
				}

				if (deadTimer < 0) 
				{
						anim.SetBool ("dead", false);
						deadTimer = deadTimerReset;
						dead = false;
						gettingHit = false;
						if (destroyOnDeath) 
						{
							Destroy (gameObject);
						} 
						else 
						{
//							Debug.Log ("NETID: " + GetComponent<NetworkIdentity> ().netId);
							currentHealth = maxHealth;
							RpcRespawn ();
						}

				}

		if (gettingHit == true) 
		{
			gettingHitTimer -= Time.deltaTime;
		}

		if (gettingHitTimer < 0) 
		{
//			anim.SetBool ("take_damage", false);
			gettingHit = false;
			gettingHitTimer = gettingHitTimerReset;
		}
	}


	public void TakeDamage (int amount)
	{
		if (!isServer) 
			return; 

		if (isBlocking)
			return;

        currentHealth -= amount;
		Debug.Log ("public void take damage");
		gettingHit = true;
		Debug.Log ("takedamage: " + amount);
        if (currentHealth <= 0)
        {
            if (destroyOnDeath)
            {
//           	DeathScene1 ();
				Debug.Log ("BANG");
//                Destroy(gameObject);
            } 
            else
            {
  				dying = true;
                // called on the Server, invoked on the Clients
//				currentHealth = maxHealth;
//              RpcRespawn();

            }
        }
    }

	public void HitBy (NetworkInstanceId bulletOwner)
	{
		lastHitBy = bulletOwner;
	}


//    [ClientRpc]
//	public void RpcHitBy (int bulletOwner)
//	{
//		Debug.Log ("SealHealth RPC bulletOwner = " + bulletOwner);
//	}

/*
	void DeathScene1 ()
	{
		anim.SetBool ("dying", true);
		Invoke ("Dead1", 0.4f);
	}

	void Dead1 ()
	{
		anim.SetBool ("dead", true);
		Invoke ("DestroySeal", 0.5f);
	}

	void DestroySeal ()
	{
		Destroy(gameObject);
		currentHealth = maxHealth;
		GetComponent<SealControl2> ().hasOar = false;
		RpcRespawn();
	}
*/
    void OnChangeHealth (int currentHealth )
    {
 //   	Debug.Log ("Callback");
//    	anim.SetBool ("take_damage", true);
    	Debug.Log ("onchangehealth take damage true");
        healthBar.sizeDelta = new Vector2(currentHealth , healthBar.sizeDelta.y);
    }



        //health.KnockBack (bulletFacingRight);
	public void KnockBack (float knockBackPwr)
	{
		gettingKnockedback = true;
//		RpcKnockbackCallback(bulletFacingRight);
//		if (bulletFacingRight == true) 
//		{
//			Debug.Log ("Knockback Right");
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockBackPwr, knockbackBumpForce));
			Debug.Log ("Knockback: " + knockBackPwr);
//		} 
//		else 
//		{
//			Debug.Log ("Knockback Left");
//			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockbackHitForce * -1, knockbackBumpForce));
//		}
		gettingKnockedback = false;
	}			

//	[ClientRpc]
//	public void Rpc_GettingHit ()
//	{
//		anim.SetBool ("take_damage", true);
//	}

	[ClientRpc]
	public void RpcKnockback (float knockBackPwr)
	{
		gettingKnockedback = true;
		if (gettingKnockedback == true) 
		{
//			if (bulletFacingRight == true) 
//			{
//				Debug.Log ("Knockback Callback Right");
				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockBackPwr, knockbackBumpForce));
				Debug.Log ("Knockback RpcCallback: " + knockBackPwr);
//			} 
//			else 
//			{
//				Debug.Log ("Knockback Callback Left");
//				GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockbackHitForce * -1, knockbackBumpForce));
//			}
		}
		gettingKnockedback = false;
	}

//	[ClientRpc]
	void Dying (bool dying)
	{
		if (dying) 
			anim.SetBool ("dying", true);
		else
			return;
		
//		Debug.Log ("RPC take_damage false, dying true");
//		anim.SetBool ("take_damage", false);
//		anim.SetBool ("dying", true);	
	}

//	[ClientRpc]
	void Dead (bool dead)
	{
		if (dead) 
		{
			Debug.Log ("killed by : " + lastHitBy);
			var getMasterDerp = GameObject.FindGameObjectWithTag("masterderp");
			var accessDerp = getMasterDerp.GetComponent<MasterDerp> ();
			accessDerp.AwardKill (lastHitBy);
			anim.SetBool ("dying", false);
			anim.SetBool ("dead", true);
		}
		else
			return;

//		Debug.Log ("RPC take_damage false, dying false, dead true");
//		anim.SetBool ("take_damage", false);
	}



	void StopHit (bool gettingHit)
	{
	if (gettingHit == false) 
		{	
			Debug.Log ("callbackhook take_damage false");
			anim.SetBool ("take_damage", false);
		}

	if (gettingHit == true) 
		{
			Debug.Log ("callbackhook take_damage true");
			anim.SetBool ("take_damage", true);
		}
	}

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
        	Debug.Log ("RPC respawn. take_damage false, dead false");
        	anim.SetBool ("dead", false);
//			anim.SetBool ("take_damage", false);
			gettingHitTimer = gettingHitTimerReset;
			GetComponent<SealControl2> ().hasOar = false;
			GetComponent<SealControl2> ().hasAxe = false;
			GetComponent<SealControl2> ().hasTricorn = false;
			GetComponent<SealControl2> ().hasCutlass = false;
			GetComponent<SealControl2> ().hasFrogmouth = false;
			gettingHit = false;
//       	anim.SetBool ("has_oar", false);
			anim.SetLayerWeight (0, 1);
			anim.SetLayerWeight (1, 0);
			anim.SetLayerWeight (2, 0);
			anim.SetLayerWeight (3, 0);
			anim.SetLayerWeight (4, 0);
			anim.SetLayerWeight (5, 0);


            // Set the spawn point to origin as a default value
            Vector3 spawnPoint = Vector3.zero;

            // If there is a spawn point array and the array is not empty, pick one at random
            if (spawnPoints != null && spawnPoints.Length > 0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }

            // Set the player’s position to the chosen spawn point
            transform.position = spawnPoint;
        }
//      anim.SetBool ("take_damage", false);
//        Debug.Log ("end respawn");
    }
}

/*
	public Slider slider;
	public Image Fill;

	[SyncVar]
	public float sealHealth;

	public float maxHealth = 100f;
	public float sealHealthLow = 25f;

	public float enemybootHeadForce = 100f;
	public float eNoseFlipForce = 200f;
	public float eBump = 50f;
	public float regen = 0.01f;

	public float damage = 10f;

	public bool hitEvent = false;


	// Use this for initialization
	void Start () {
		sealHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = sealHealth;
//		slider.value = Mathf.MoveTowards (slider.value, 100.0f, 0.15f);
		if (slider.value <= sealHealthLow) {
			Fill.color = Color.red;
			GetComponentInParent<SealControl2> ().sealDamaged = true;
		}
		else 
		{
			Fill.color = Color.white;
			GetComponentInParent<SealControl2> ().sealDamaged = false;
		}
	}

	public void SetHealth ()
	{
	if (!isServer)
    	return;

		if (hitEvent) 
		{
			if (sealHealth > sealHealthLow) 
			{
				sealHealth -= damage;
				hitEvent = false;
			} 
			else 
			{
				Debug.Log ("overkill triggered");					
				hitEvent = false;
			}
			if (sealHealth < 0) 
			{
			//	sealHealth = 0;	
				hitEvent = false;
				sealHealth = maxHealth;

            // called on the server, will be invoked on the clients
           		 RpcRespawn();
			}
		}
		else if (!hitEvent) 
		{
			sealHealth += regen;
		}
	}
		//enemy vs. player
	void OnTriggerEnter2D (Collider2D col)
	{
//				if (col.gameObject.tag == "Player") 
//				{
//						Debug.Log ("Player v Enemy!!!!!!*************");
//						move = 0;
//						inMelee = true;
//				}
//end propulsion



//getting hit
		if (col.gameObject.tag == "enemytailslap") 
		{
			if (!GameObject.Find ("Enemy").GetComponent<EnemyController1> ().facingRight) 
			{
//				Debug.Log ("tailslap enemy facing right");
				enemybootHeadForce *= -1;
			} 
			else if (GameObject.Find ("Enemy").GetComponent<EnemyController1> ().facingRight) 
		{
//				Debug.Log ("tailslap enemy facing left");
		}
		GetComponentInParent<Rigidbody2D>().AddForce (Vector2.right * enemybootHeadForce, ForceMode2D.Force);
		GetComponentInParent<Rigidbody2D>().AddForce (Vector2.up * eBump, ForceMode2D.Force);
//			Debug.Log ("derp derp derp!");
			hitEvent = true;
			SetHealth();

		if (enemybootHeadForce < 0)
		{
			enemybootHeadForce *= -1;	
//				Debug.Log ("bootHeadForce reset");
		}
		}
		if (col.gameObject.tag == "enose") 
		{
			GetComponentInParent<Rigidbody2D>().AddForce (Vector2.right * eNoseFlipForce, ForceMode2D.Force);
//			Debug.Log ("noseflip triggered.");
			hitEvent = true;
			SetHealth();
		}

		}

		//respawn
[ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
			transform.position = new Vector2(-5, 5);
        }
    }
//end respawn

//end getting hit
//end enemy vs. player
*/

