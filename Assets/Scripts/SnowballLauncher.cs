using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SnowballLauncher : NetworkBehaviour {

	//we need a ready to fire script so that balls can't be conjured while upside down or doing other things
/*	public bool digtrigger = false;

	[SyncVar]
	public GameObject snowball;

	[SyncVar]
	public GameObject snowballx;

	[SyncVar]
	public GameObject snowbally;

	public float fireDelay = 2f;
	public float coolDown = 4f;
	public float fireVelocity = -1f;
	public float ballWeight = 0.5f;

	public int hyperSnowBallChance = 1;
	public int magicSnowBallChance = 11;
	public int normalSnowBallChance = 100;

		// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
		{
		}

		if (Input.GetButtonDown ("Fire1") && GetComponentInParent<SealControl2>().flipped == false && GetComponentInParent<SealControl2>().onSnow == true) 
						//|| GetComponentInParent<EnemyController1>().sealBusyDigging
		{
			digtrigger = true;
			fireDelay -= Time.deltaTime;
//						GetComponentInParent<Noseflip>().SetActive (false);
		}

//				if (GetComponentInParent<EnemyController1> ().sealBusyDigging) 
//				{
//						digtrigger = true;
//						fireDelay -= Time.deltaTime;
//				}
	
		
	if (digtrigger == true) 
	{
		fireDelay -= Time.deltaTime;
			if (Input.GetButtonDown ("Fire1")) 
			{
			}
		if (fireDelay <= 0) 
		{
			int ballNum = Random.Range (0, hyperSnowBallChance + magicSnowBallChance + normalSnowBallChance);
			if (ballNum <= hyperSnowBallChance) 
			{
				CmdMakeSnowBallY ();
			} 
			else if (ballNum > hyperSnowBallChance && ballNum < magicSnowBallChance) 
			{
				CmdMakeSnowBallX ();
			} else if (ballNum > magicSnowBallChance && ballNum <= normalSnowBallChance) 
			{
				CmdMakeSnowBall();
			}
		}

			//spawn new snowball!
//			GameObject snowballGO = (GameObject)Instantiate (snowball, transform.position, transform.rotation);
//			snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
//			snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
//			snowballGO.SetActive(true);
//			fireDelay = coolDown;
//			digtrigger = false;
		}




	}
		[Command]
		void CmdMakeSnowBall(){
				GameObject snowballGO = (GameObject)Instantiate (snowball, transform.position, transform.rotation);
				//				Debug.Log ("***************************************************SNOWBALL CREATED");

				NetworkServer.Spawn(snowball);				
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
//				GetComponentInParent<SealControl2> ().sealBusyDigging = false;
		}
		[Command]
		void CmdMakeSnowBallX(){
				GameObject snowballGO = (GameObject)Instantiate (snowballx, transform.position, transform.rotation);
				NetworkServer.Spawn(snowballx);
								//				Debug.Log ("***************************************************SNOWBALL CREATED");
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
//				GetComponentInParent<SealControl2> ().sealBusyDigging = false;

		}
		[Command]
		void CmdMakeSnowBallY(){
				GameObject snowballGO = (GameObject)Instantiate (snowbally, transform.position, transform.rotation);
				NetworkServer.Spawn(snowbally);
								//				Debug.Log ("***************************************************SNOWBALL CREATED");
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
//				GetComponentInParent<SealControl2> ().sealBusyDigging = false;

		}

}
*/

}