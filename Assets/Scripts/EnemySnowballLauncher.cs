using UnityEngine;
using System.Collections;

public class EnemySnowballLauncher : MonoBehaviour {

	//we need a ready to fire script so that balls can't be conjured while upside down or doing other things
	public bool digtrigger = false;
	public GameObject snowball;
	public GameObject snowballx;
	public GameObject snowbally;
	public float fireDelay = 1.95f;
	public float coolDown = 1.95f;
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
				if (GetComponentInParent<EnemyController1> ().sealBusyDigging && GetComponentInParent<EnemyController1> ().onSnow) 
				{
						digtrigger = true;
				} 
	
				if (digtrigger) {
						fireDelay -= Time.deltaTime;
//			Debug.Log ("fireDelay = " + fireDelay);
//			Debug.Log ("digtrigger = " + digtrigger);
//			Debug.Log ("Game Time = " + Time.time);
				if (fireDelay <= 0) 
				{
			
					int ballNum = Random.Range (0, hyperSnowBallChance + magicSnowBallChance + normalSnowBallChance);
					if (ballNum <= hyperSnowBallChance) 
					{
						MakeSnowBallY ();
					} 
					else if (ballNum > hyperSnowBallChance && ballNum < magicSnowBallChance) 
					{
						MakeSnowBallX ();
					} else if (ballNum > magicSnowBallChance && ballNum <= normalSnowBallChance) 
					{
						MakeSnowBall();
					}

				}

//				GameObject snowballGO = (GameObject)Instantiate (snowball, transform.position, transform.rotation);
//				Debug.Log ("***************************************************SNOWBALL CREATED");
//				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
//				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
//				snowballGO.SetActive(true);
//				fireDelay = coolDown;
//				digtrigger = false;
//				GetComponentInParent<EnemyController1> ().sealBusyDigging = false;
			}
		}
	
		void MakeSnowBall(){
				GameObject snowballGO = (GameObject)Instantiate (snowball, transform.position, transform.rotation);
				//				Debug.Log ("***************************************************SNOWBALL CREATED");
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
				GetComponentInParent<EnemyController1> ().sealBusyDigging = false;
		}
		void MakeSnowBallX(){
				GameObject snowballGO = (GameObject)Instantiate (snowballx, transform.position, transform.rotation);
				//				Debug.Log ("***************************************************SNOWBALL CREATED");
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
				GetComponentInParent<EnemyController1> ().sealBusyDigging = false;
		}
		void MakeSnowBallY(){
				GameObject snowballGO = (GameObject)Instantiate (snowbally, transform.position, transform.rotation);
				//				Debug.Log ("***************************************************SNOWBALL CREATED");
				snowballGO.GetComponent<Rigidbody2D>().mass = 0.5f;
				snowballGO.GetComponent<Rigidbody2D>().velocity = transform.rotation * new Vector2 (0, fireVelocity);
				snowballGO.SetActive(true);
				fireDelay = coolDown;
				digtrigger = false;
				GetComponentInParent<EnemyController1> ().sealBusyDigging = false;
		}
}