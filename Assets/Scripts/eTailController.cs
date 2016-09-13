using UnityEngine;
using System.Collections;

public class eTailController : MonoBehaviour {

		public bool tailTrigger = false;
		public GameObject myTail;
		public float tailSlapTimer = 3f; //the time we return the collider
		public float tailSlapTimerReset = 3f;
		public float tailSlapVelocity = 0.8f;

		public float tailSlapAnimTimer = 1.5f; //time while anim whips tail around, sends collider
		public float tailSlapAnimTimerReset = 1.5f;
		public bool tailSlapFireOnce = true;

		void Start () {
		}

		// Update is called once per frame
		void Update () {
//				if (Input.GetButtonDown ("Tailslap")) 
//				{
//						tailTrigger = true;
//				}
//				if (gameObject.GetComponentInParent<EnemyController1> ().eSealBusyTailslapping) 
//				{
//						tailTrigger = true;
//				}
//				if (gameObject.GetComponentInParent<EnemyController1> ().sealBusyTailslapping == false)
//				{
//						tailTrigger = false;
//				}
		}


		//	if (gameObject.GetComponent<name of the script holding the bool>().IsLightOn)//will check if true

		//	if (!gameObject.GetComponent<name of the script holding the bool>().IsLightOn)//will check if false

		void FixedUpdate () {
				if (gameObject.GetComponentInParent<EnemyController1> ().eSealBusyTailslapping) 
				{
						tailTrigger = true;
				}

				if (tailTrigger == true) {
						//			if (gameObject.GetComponentInParent<SealControl2>().facingRight)
						//			{
						//				Debug.Log ("TailTriggerController.facingRight = true!");
						//			}
						tailSlapAnimTimer -= Time.deltaTime;
						tailSlapTimer -= Time.deltaTime;
						if (tailSlapAnimTimer <= 0 && tailSlapFireOnce == true)
						{
								if (!gameObject.GetComponentInParent<EnemyController1>().facingRight)
								{
//										Debug.Log ("TailTriggerController.facingRight = !true!");
										tailSlapVelocity *= -1;
								}
								myTail.GetComponent<BoxCollider2D>().enabled = true;
								myTail.transform.Translate (Vector2.right * tailSlapVelocity);//tailslap collider send
								//				Debug.Log ("TAILSLAP!");
								tailSlapFireOnce = false;
								//				tailTrigger = false;
								tailSlapTimer -= Time.deltaTime;
						}
						if (tailSlapTimer <= 0) {
								//				Debug.Log ("TAILSLAP DONE!!");
								myTail.GetComponent<BoxCollider2D>().enabled = false;
								myTail.transform.localPosition = Vector2.zero; //tailslap return
								tailSlapAnimTimer = tailSlapAnimTimerReset;
								tailSlapTimer = tailSlapTimerReset;
								tailTrigger = false;
								tailSlapFireOnce = true;
								if (tailSlapVelocity < 0)
										tailSlapVelocity *= -1;
						}

				}
		}
}
