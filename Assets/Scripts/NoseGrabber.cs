using UnityEngine;
using System.Collections;

public class NoseGrabber : MonoBehaviour {
	
	public bool sendingNoseGrab = false;
	public GameObject noseGrab;
	public float noseGrabTimer = 3f;
	public float noseGrabTimerReset = 3f;

	public BoxCollider2D snowBallDetector;
	public bool snowBallGrabbed = false;

	public float noseGrabMove = 1f;


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "snowball") 
		{
			Debug.Log ("nosegrabber detected snowball.");
			snowBallDetector = GetComponent<BoxCollider2D>();
			snowBallGrabbed = true;
		} 
	}

	void Update () 
	{
		if (Input.GetButtonDown ("Fire2")) 
		{
			if (!gameObject.GetComponentInParent<SealControl2>().facingRight)
			{
				Debug.Log ("nosegrab.facingRight = !true!");
				noseGrabMove *= -1;
			}

			sendingNoseGrab = true;
			Debug.Log ("key pressed at " + Time.time + "         sendingNoseGrab = " + sendingNoseGrab);
			noseGrab.transform.Translate (noseGrabMove, 0, 0);
		}

		if (sendingNoseGrab == true) 
		{
			noseGrabTimer -= Time.deltaTime;
			Debug.Log (noseGrabTimer);
			if (noseGrabTimer < 0) 
			{
				noseGrab.transform.Translate (-noseGrabMove, 0, 0);
				sendingNoseGrab = false;
				Debug.Log ("Timer expired and collider returned at " + Time.time + "         sendingNoseGrab = " + sendingNoseGrab);
				noseGrabTimer = noseGrabTimerReset;
				if (noseGrabMove < 0)
					noseGrabMove *= -1;
			}
		}

	}
}











//	noseGrab.transform.Translate(-1,0,0);
//	snowBallDetector.isTrigger = false;
//	snowBallDetector.enabled = false;

//	snowBallDetector = GetComponent<BoxCollider2D>();
//	snowBallSpringGrabber.enabled = true;

//	public float noseGrabVelocity = 0.8f;
//	public float noseGrabVelocityReset = .8f;

//	public float noseGrabAnimTimer = 1.5f;
//	public float noseGrabAnimTimerReset = 1.5f;
//	public bool noseGrabFireOnce = true;

//	public float slowReactivateTrigger = 3f;
//	public float slowReactivateTriggerReset = 3f;
//	public float timeStampy = 1000f;

/*		if ((noseGrabber == true) && (noseGrabFireOnce == true))
//		{
//			if (snowBallGrabbed == false)
//			{		
//				noseGrabAnimTimer -= Time.deltaTime;
				noseGrabTimer -= Time.deltaTime;
				if (noseGrabTimer < 0)
				{
					noseGrab.transform.Translate(1,0,0);//nose collider send
					Debug.Log ("nosegrabber.cs collider sent    :" + Time.time);
					noseGrabFireOnce = false;
					noseGrabTimer -= Time.deltaTime;
				}
				if (noseGrabTimer <= 0) 
				{
					Debug.Log ("nosegraber.cs collider retracted     :" + Time.time);
					noseGrabVelocity = .4f;
					noseGrab.transform.Translate(-1,0,0);
					noseGrabAnimTimer = noseGrabAnimTimerReset;
					noseGrabTimer = noseGrabTimerReset;
					noseGrabber = false;
					noseGrabFireOnce = true;
					noseGrabVelocity = noseGrabVelocityReset;
				}			
//			}
//		}
		if ((Input.GetButtonDown ("Fire2")) && (snowBallGrabbed == true)) 
		{
			slowReactivateTrigger -= Time.deltaTime;
			Debug.Log ("timer is working I think?");
			snowBallGrabbed = true;
			if (slowReactivateTrigger <= 0) 
			{
				snowBallGrabbed = false;
				snowBallDetector = GetComponent<BoxCollider2D>();
				snowBallDetector.isTrigger = true;
				snowBallDetector.enabled = true;
				slowReactivateTrigger = slowReactivateTriggerReset;
				Debug.Log ("Trigger Reactivated.");		
			}
		}
		//		if ((Input.GetButtonDown ("Fire2")) && (snowBallGrabbed == true)) 
		//		{
		//			timeStampy = Time.time + slowReactivateTrigger;
		//			Debug.Log ("timer is working I think?");
		//			Debug.Log (Time.time);
		//		}
		//		if (timeStampy <= Time.time)
		//		{
		//			snowBallDetector = GetComponent<BoxCollider2D>();
		//			snowBallDetector.isTrigger = true;
		//			snowBallDetector.enabled = true;
		//			slowReactivateTrigger = slowReactivateTriggerReset;
		//			Debug.Log ("Trigger Reactivated.");
		//		}
		//	}
		
		//	void FixedUpdate () 
		//if snowballGrabbed = true, snowBallDetector.isTrigger = false
		//	{




//		if ((noseGrabber == true) && (snowBallGrabbed == true)) 
//		{
//			Debug.Log ("noseGrabber true, SnowBallGrabbed true");
//		}
*/
	


