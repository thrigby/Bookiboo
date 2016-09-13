using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoseFlip : MonoBehaviour { //this script controls the trigger in the seal's nose

	public bool noseTrigger = false;
	public Slider slider;
	public GameObject noseFlip;
	public float noseFlipTimer = 2f;
	public float noseFlipTimerReset = 2f;
	public float noseFlipVelocity = 1.5f;

	public float noseFlipAnimTimer = 1f;
	public float noseFlipAnimTimerReset = 1f;
	public bool noseFlipFireOnceToggle = false;
	
	public float noseFlipForce = 50f;
	public float noseFlipForceReset = 50f;
	public float shotPower = 50f;
	public float shotPowerReset = 50f;
	public float shotPowerMax = 600f;
	public float powerIncrement = 50f;
//	public float nosePowerTimer = 2f;
//	public float nosePowerTimerReset = 2f;


	void Start(){
//		noseFlip.SetActive (false);
	}
	
	void Update () {

			slider.value = noseFlipForce;

			if (Input.GetButtonDown ("Fire3") && GetComponentInParent<SealControl2>().flipped == false) {
				noseTrigger = true;
			}

			if (Input.GetButtonDown("Fire3"))
			{
				noseFlipForce = noseFlipForceReset;
				shotPower = shotPowerReset;					
			}

				SetShotPower ();

			if (Input.GetButtonUp ("Fire3"))
			{
				Debug.Log ("Shot Power = " + noseFlipForce);
				if (noseFlipForce > shotPowerMax) 
				{
					noseFlipForce = shotPowerMax;
//								Debug.Log ("DERPDERP");
				}
				shotPower = noseFlipForce;
//				noseFlipForce = noseFlipForceReset;
//				nosePowerTimer = nosePowerTimerReset;
			}
	}							
		
	void FixedUpdate () {
		if (noseTrigger == true) {
			noseFlipAnimTimer -= Time.deltaTime;
			noseFlipTimer -= Time.deltaTime;
			if (noseFlipAnimTimer <= 0 && noseFlipFireOnceToggle == false) 
			{
				if (!gameObject.GetComponentInParent<SealControl2>().facingRight)
				{
//					Debug.Log ("nose.facingRight = !true!");
					noseFlipVelocity *= -1;
				}
				noseFlipTimer -= Time.deltaTime;			
//				Debug.Log ("animation timer fired" + Time.deltaTime);
				noseFlip.GetComponent<BoxCollider2D>().enabled = true;
				noseFlip.transform.Translate (Vector2.right * noseFlipVelocity);
				noseFlipFireOnceToggle = true;
			}
		if (noseFlipTimer <= 0) {
			noseFlipTimer = noseFlipTimerReset;
//			Debug.Log ("trigger return fired" + Time.time);
			noseFlip.transform.localPosition = Vector2.zero;
			noseFlip.GetComponent<BoxCollider2D>().enabled = false;
				//			noseFlip.transform.Translate (-Vector2.right * noseFlipVelocity); // * Time.deltaTime);
			noseTrigger = false;
			noseFlipFireOnceToggle = false;
			noseFlipAnimTimer = noseFlipAnimTimerReset;
			if (noseFlipVelocity < 0)
					noseFlipVelocity *= -1;
			}
		}
	}

	public void SetShotPower()
	{
		if (Input.GetButton ("Fire3")) 
		{
			noseFlipForce += powerIncrement;
//			Debug.Log ("SET SHOT");
		}
	}

}
