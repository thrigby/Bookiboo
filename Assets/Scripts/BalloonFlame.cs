using UnityEngine;
using System.Collections;

public class BalloonFlame : MonoBehaviour {

//	Animator anim;

	public GameObject balloon;
	public bool insidecage = false;
	public GameObject flames;
	public bool flamesOn = false;
	public bool sealUp = true;
//	public Animator flameController;

	public bool flameTimerOn = false;
	public float flameTimer = 0.5f;
	public float flameTimerReset = 0.5f;
	
//	public bool warming = false;
	public float warmLift = 0.1f;
	public float coldSink = 0.4f;

	public bool offTimerOn = true;
	public float offTimer = 0.5f;
	public float offTimerReset = 0.5f;

	public float flameDuration = 0f;
	public float flameDurationReset = 0f;
	
//	void Start () 
//	{
//		StartCoroutine (Countdown ()); //new coroutine
//	}

//	IEnumerator Countdown ()
//	{
//		for (float timer = 3; timer >= 0; timer -= Time.deltaTime)
//						yield return 0;
//		Debug.Log ("Fix BalloonFlame.cs character falls out of the basket");
//	}

	void OnTriggerEnter2D (Collider2D col) //basket event
	{

		if (col.gameObject.tag == "insidebasket") 
		{
//			Debug.Log ("BalloonFlame.cs InsideBasket Triggered");
			insidecage = true;
			GetComponent<ConstantForce2D>().enabled = true;
//if (!GameObject.Find ("Character").GetComponent<SealControl2>().facingRight)
//either parent or change the drag?

		}
	}

	void OnTriggerExit2D (Collider2D col) //leave basket
	{
		if (col.gameObject.tag == "insidebasket")	
		{
//			Debug.Log ("BalloonFlame.cs Player has left the basket");
			insidecage = false;
			GetComponent<ConstantForce2D>().enabled = false;
		}
	}

	void Update()
	{
		if (Input.GetButtonDown ("Rollover")) 
		{
//			flameTimer -= Time.deltaTime;
			flameTimerOn = !flameTimerOn;
			offTimerOn = !offTimerOn;
//			Debug.Log ("flameTimer  " + flameTimerOn);
//			Debug.Log ("offTimer    " + offTimerOn);
		}

		if (flameTimerOn)
		{
			flameTimer -= Time.deltaTime;
//			Debug.Log (flameTimer);
		}

		if (offTimerOn) 
		{
			offTimer -= Time.deltaTime;		
		}

		if (flameTimer < 0) 
		{		
			if (insidecage == true) 
			{
				if (flamesOn == false) 
				{
					flames.SetActive (true);
					flamesOn = true;
//					sealUp = false;
					Debug.Log ("FLAME ON");
					flameTimerOn = false;
					flameTimer = flameTimerReset;
				}
			}
		}

		if (offTimer < 0)
		{
			if (flamesOn == true)
			{
				if (flameDuration > 100)
				{
				flames.SetActive (false);
				flamesOn = false;
//				sealUp = true;
				flameDuration = flameDurationReset;
				Debug.Log ("FLAME OFF");
				offTimer = offTimerReset;
				}
			}
		}

//		}
		

		if (flamesOn) 
		{
			balloon.GetComponent<Rigidbody2D>().gravityScale -= Time.deltaTime * warmLift;		
			flameDuration += 1;
//			Debug.Log (flameDuration);
		}

		if ((!flamesOn) && (balloon.GetComponent<Rigidbody2D>().gravityScale < 2)) 
		{
			balloon.GetComponent<Rigidbody2D>().gravityScale += Time.deltaTime * coldSink;		
		} 
		else if (!flamesOn) 
		{
			balloon.GetComponent<Rigidbody2D>().gravityScale = 2;
		}
		
	}
}

/*
 * void Update(){
 * 		StealthMode ();
	}
 * 
	public void Flamethrower ()
	{
		if (Input.GetButtonDown ("Rollover"))
		{
			if (flameOn == false)
			{
				stealth = true;
				rigidbody2D.drag = 50f;
				timeStamp = Time.time + rollOverLag;
			}
			else if (stealth == true)
			{
				anim.SetBool ("busyFlippingBack", true);
				timeStamp = Time.time + rollBackLag;
				stealth = false;
//				rigidbody2D.drag = 0.5f;
				Debug.Log ("FLIPPING BACK");
			}
		}
	}
*/
