using UnityEngine;
using System.Collections;

public class eSwimming : MonoBehaviour {

	Animator anim;

//	private SealControl2 sealControl2;

	public float swimForce = 2f;
	public bool underWater = false; //still need these for animations
	public bool overWater = true;
//	public bool diving = false;
//	public bool ascending = false;
//	public bool hovering = false;
//	public bool vertArrowInUse = false;
//	public bool downArrowInUse = false;
//	public bool keyAlreadyPressed = false;
//	public float keyAlreadyPressedTimer = 2f;
//	public float keyAlreadyPressedTimerReset = 2f;

	public bool newToTheWater = false;
	public float newToTheWaterTimer = 3f;
	public float newToTheWaterTimerReset = 3f;
//	public float dragFiddler = 1f;
//	public Transform playa;

//	public GameObject groundDetector;
//	public bool swimTriggered = false; //for when we toggle swimming off and on

//	void Awake()
//	{
//		sealControl2 = GetComponent<SealControl2> ();
//	}

	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) //nutty water colliders need to be gamgronkled & gamgronkleberried
	{
		if ((col.gameObject.tag == "underwater") && overWater) 
		{
//			Debug.Log ("Swimming.cs water triggered");
//			rigidbody2D.gravityScale = 0f;
			anim.SetBool ("swimbox", true);
			anim.SetBool ("swimfast", false);//GARBAGE
			underWater = true;
			overWater = false;
			newToTheWater = true;
//			hovering = true;
//			rigidbody2D.angularDrag = 1f;
//			transform.rotation = Quaternion.identity;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if ((col.gameObject.tag == "underwater") && underWater)
		 {
//		    Debug.Log ("Swimming.cs exit water triggered");
		    anim.SetBool ("swimbox", false);
			GetComponent<Rigidbody2D>().angularDrag = 0.5f;
			GetComponent<Rigidbody2D>().drag = 0.5f;	
			GetComponent<Rigidbody2D>().gravityScale = 1f;
			underWater = false;
			overWater = true;
			newToTheWater = true;
		}

	}
//		if ((col.gameObject.tag == "overwater") && underWater)
//		{
//			Debug.Log ("anim.swim false");
//			rigidbody2D.gravityScale = 1f;
//			anim.SetBool ("swimbox", false);
//			underWater = false;
//			overWater = true;
//			newToTheWater = true;
//			hovering = false;
//		}
//		if ((col.gameObject.tag == "oceanfloat") && underWater) 
//		{
//			Debug.Log ("ocean float triggered");
//			rigidbody2D.gravityScale = .5f;
//			hovering = true;			
//		}
//	}

//I THINK WE NEED TO MOVE THE JUMP SCRIPT OVER TO HERE?	
	void FixedUpdate ()
		{
				if (underWater == true) {
						GetComponent<EnemyController1> ().grounded = false;

//						float moveHorizontal = Input.GetAxis ("Horizontal");
//						float moveVertical = Input.GetAxis ("Vertical");
						float moveHorizontal = GetComponent<EnemyController1> ().distancex *-1;
//						Debug.Log ("DISTANCEX = " + GetComponent<EnemyController1> ().distancex);
						float moveVertical = GetComponent<EnemyController1> ().distancey *-1;
						Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
//						Debug.Log ("*******" + movement);
						if (newToTheWater == true) {
								newToTheWaterTimer -= Time.deltaTime;
								GetComponent<Rigidbody2D> ().drag += newToTheWaterTimer;
								if (newToTheWaterTimer < 0) {
//										Debug.Log ("new to the water timer expired");
										newToTheWater = false;
										newToTheWaterTimer = newToTheWaterTimerReset;
								}
						} else {
								GetComponent<Rigidbody2D> ().velocity = movement * swimForce;
//								Debug.Log ("VELOCITY = " + GetComponent<Rigidbody2D> ().velocity);
//			GetComponent<Rigidbody2D>().fixedAngle = true;
								transform.rotation = Quaternion.identity;
//								Debug.Log (transform.position.y);

						}

//						if (Input.GetAxis ("Horizontal") != 0) {
//								anim.SetBool ("swimfast", true);//GARBAGE
//								anim.SetBool ("swimbox", true);
//						} else {
//								anim.SetBool ("swimfast", false);
//								anim.SetBool ("swimbox", true);
						}
//			Debug.DrawRay(transform.position, transform.up, RaycastHit hitInfo);
				}
		}
//}
//		else
//			GetComponent<Rigidbody2D>().fixedAngle = false; //if seal is underwater, keep him fixed angle atm for simplicity's sake.
//contemplating swim mode options
//	}
//}
//		sealControl2.GetComponent<Tailslap> ();
/*
 * 
 * public class ExampleClass : MonoBehaviour {
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            float distanceToGround = hit.distance;
        
    }
}
		if ((keyAlreadyPressed == true) && underWater) //put our timer here
		{
			keyAlreadyPressedTimer -= Time.deltaTime;
			if (keyAlreadyPressedTimer <= 0)
			{
				keyAlreadyPressed = false;
				keyAlreadyPressedTimer = keyAlreadyPressedTimerReset;
			}
		}
		if ((underWater == true) && keyAlreadyPressed == false) 
		{
			if ((Input.GetAxis ("Vertical") > 0) && hovering) //if UP is pressed and we're hovering, dive
		{
				rigidbody2D.gravityScale = -swimForce;
				ascending = true;
				hovering = false;
				diving = false;
				keyAlreadyPressed = true;
				Debug.Log ("ascending");
		}
			if ((Input.GetAxis ("Vertical") > 0) && diving)  //if UP is pressed and we're currently diving, stop
			{
				rigidbody2D.gravityScale = 0; //maybe set up a decrement?
				hovering = true;
				diving = false;
				ascending = false;
				keyAlreadyPressed = true;
				Debug.Log ("hovering");
			}
			if ((Input.GetAxis ("Vertical") > 0) && ascending) //if UP is pressed, already ascending
			{ 
				Debug.Log ("already ascending");
			}
			if ((Input.GetAxis ("Vertical") < 0) && hovering)  //if DOWN is pressed, hovering
			{
				rigidbody2D.gravityScale = swimForce;
				diving = true;
				hovering = false;
				ascending = false;
				keyAlreadyPressed = true;
				Debug.Log ("down works");
			}
			if ((Input.GetAxis ("Vertical") < 0) && diving) //if DOWN is pressed, diving
			{
				Debug.Log ("already diving");
			}
			if ((Input.GetAxis ("Vertical") < 0) && ascending) //if DOWN is pressed, ascending
			{ 
				rigidbody2D.gravityScale = 0; //here also possible decrement
				hovering = true;
				ascending = false;
				diving = false;
				keyAlreadyPressed = true;
				Debug.Log ("hovering");
			}
		
		}
	}
}
*/