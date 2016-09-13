using UnityEngine;
using System.Collections;

public class eNoseFlip : MonoBehaviour { //this script controls the trigger in the seal's nose

	public bool noseTrigger = false;
	public GameObject noseFlip;
	public float noseFlipTimer = 2f;
	public float noseFlipTimerReset = 2f;
	public float noseFlipVelocity = 1.5f;

	public float noseFlipAnimTimer = 1f;
	public float noseFlipAnimTimerReset = 1f;
	public bool noseFlipFireOnceToggle = false;
	
	void Start(){
//		noseFlip.SetActive (false);
	}
	
	void Update () {
//		if (Input.GetButtonDown ("Fire3")) {
//			noseTrigger = true;
//			Debug.Log ("BURRITO! NoseFlip.cs working");
//			noseFlipAnimTimer -= Time.deltaTime;
//			if (noseFlipAnimTimer <= 0){
//				noseFlip.transform.Translate (Vector2.right * noseFlipVelocity);// * Time.deltaTime);
			}
//	}							
		
	void FixedUpdate () {
		if (gameObject.GetComponentInParent<EnemyController1> ().sealBusyNoseFlipping) 
		{
			noseTrigger = true;
		}
//						Debug.Log ("***********************NOSE!*******************");
		if (noseTrigger == true) {
			noseFlipAnimTimer -= Time.deltaTime;
			noseFlipTimer -= Time.deltaTime;
			if (noseFlipAnimTimer <= 0 && noseFlipFireOnceToggle == false) 
			{
			if (!gameObject.GetComponentInParent<EnemyController1>().facingRight)
				{
//					Debug.Log ("enemy noseflip facing left");
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
			noseFlip.GetComponent<BoxCollider2D>().enabled = false;
			noseFlip.transform.localPosition = Vector2.zero;
				//			noseFlip.transform.Translate (-Vector2.right * noseFlipVelocity); // * Time.deltaTime);
			noseTrigger = false;
			noseFlipFireOnceToggle = false;
			noseFlipAnimTimer = noseFlipAnimTimerReset;
			if (noseFlipVelocity < 0)
					noseFlipVelocity *= -1;
			}
		}
	}

}
