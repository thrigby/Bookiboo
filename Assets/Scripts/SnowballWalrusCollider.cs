using UnityEngine;
using System.Collections;

public class SnowballWalrusCollider : MonoBehaviour {
	
	Animator anim;

	public CircleCollider2D snowBallCircleCollider;
	public BoxCollider2D snowBallBoxCollider;
//	public SpringJoint2D snowBallSpringGrabber;
	public DistanceJoint2D snowBallDistanceGrabber;

	public bool snowballMeetsOcean = false;
	public bool walrusMeetsSnow = false;
	public float walrusCollisionTimer = 3f;
	public float walrusCollisionTimerReset = 3f;
	public float walrusTimeStamp = 3f;

	public float walrusPunch = 500;
	public bool walrusLaunchingSnow = false;
	public float walrusLaunchTimer = 2f;
	public float walrusLaunchTimerReset = 2f;

	public float walrusTailForce = 100;
	public bool walrusTailLaunch = false;
	public float walrusTailLaunchTimer = 2f;
	public float walrusTailLaunchReset = 2f;

	public bool grabbed = false;

	void Start(){
		anim = GetComponent<Animator> ();
	}
//walter the walrus?
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "walrustail") 
		{
//			Debug.Log ("snowballwalruscollider.cs col.gameObject.tag = walrustail triggered");
			walrusTailLaunch = true;
		}

		if (col.gameObject.tag == "wh") 
		{
//			Debug.Log ("snowballwalruscollider.cs col.gameObject.tag = wh triggered");
//			rigidbody2D.gravityScale = .5f;
//			rigidbody2D.AddForce (Vector2.up * walrusPunch, ForceMode2D.Force);
			walrusLaunchingSnow = true;
		}

		if (col.gameObject.tag == "nosegrabber") 
		{
//			Debug.Log ("snowball detected nosegrabber and was picked up");
//			snowBallSpringGrabber = GetComponent<SpringJoint2D>();
//			snowBallSpringGrabber.enabled = true;
			snowBallDistanceGrabber = GetComponent<DistanceJoint2D>();
			snowBallDistanceGrabber.enabled = true;
			snowBallBoxCollider.isTrigger = false;
			snowBallCircleCollider.enabled = false;
			GetComponent<Rigidbody2D>().gravityScale = 0f;
			GetComponent<Rigidbody2D>().drag = 0;
			GetComponent<Rigidbody2D>().angularDrag = 0f;
			GetComponent<Rigidbody2D>().mass = 0f;
			grabbed = true;
		}
/*						
		if (col.gameObject.tag == "walrus") {
			Debug.Log ("snowball vs walrus triggered!");
			walrusMeetsSnow = true;
			snowBallCircleCollider = GetComponent<CircleCollider2D>();
			snowBallBoxCollider = GetComponent<BoxCollider2D>();
			snowBallCircleCollider.isTrigger = true;
			snowBallBoxCollider.isTrigger = false;
			transform.rotation = Quaternion.identity;
//			rigidbody2D.gravityScale = 0.2f;
			rigidbody2D.drag = 30f;
			rigidbody2D.angularDrag = 50f;
			gameObject.tag = "snowpack";
			anim.SetBool ("Splatted", true);
		}
		if (col.gameObject.tag == "snowpack") 
		{
			Debug.Log ("snowball vs snowpack triggered!");
			walrusMeetsSnow = true;
			snowBallCircleCollider = GetComponent<CircleCollider2D>();
			snowBallBoxCollider = GetComponent<BoxCollider2D>();
			snowBallCircleCollider.isTrigger = true;
			snowBallCircleCollider.radius = 0.3f;
			snowBallBoxCollider.isTrigger = false;
			transform.rotation = Quaternion.identity;
//			rigidbody2D.gravityScale = 0.2f;
			rigidbody2D.drag = 30f;
			rigidbody2D.angularDrag = 50f;
			gameObject.tag = "snowpack";
			anim.SetBool ("Snowpacked", true);
		}
*/
		if (col.gameObject.tag == "underwater") 
		{
//			Debug.Log ("snowball + water!");
			walrusMeetsSnow = true;
			snowBallCircleCollider = GetComponent<CircleCollider2D>();
			snowBallBoxCollider = GetComponent<BoxCollider2D>();
//			snowBallCircleCollider.isTrigger = false;
			snowBallBoxCollider.enabled = false;
//			snowBallBoxCollider.size = 0.2f;
			transform.rotation = Quaternion.identity;
//			rigidbody2D.gravityScale = 0.2f;
			GetComponent<Rigidbody2D>().gravityScale = .01f;
			GetComponent<Rigidbody2D>().angularDrag = 50f;
			GetComponent<Rigidbody2D>().drag = 50f;
//			rigidbody2D.isKinematic = true;
			gameObject.tag = "iceball";
			anim.SetBool ("Snowballice", true);
			snowballMeetsOcean = true;
//			rigidbody2D.isKinematic = false;
		}
		if (col.gameObject.tag == "overwater" && gameObject.tag == "iceball") 
		{
			Debug.Log ("iceball + air!");
			GetComponent<Rigidbody2D>().gravityScale = .5f;
		}
	}
	void Update () 
	{
		if (walrusTailLaunch == true)
		{
			walrusTailLaunchTimer -= Time.deltaTime;
			if (walrusTailLaunchTimer < 0)
			{
				GetComponent<Rigidbody2D>().AddForce (Vector2.up * walrusTailForce, ForceMode2D.Force);
//				Debug.Log ("SnowballWalrusCollider.cs walrus tailflip snowball");
				walrusTailLaunch = false;
				walrusTailLaunchTimer = walrusTailLaunchReset;
			}
		}

		if (walrusLaunchingSnow == true) 
		{
			walrusLaunchTimer -= Time.deltaTime;
			if (walrusLaunchTimer < 0)
			{
				GetComponent<Rigidbody2D>().AddForce (Vector2.up * walrusPunch, ForceMode2D.Force);
//				Debug.Log ("SnowballWalrusCollider.cs walrus launching snowball");
				walrusLaunchingSnow = false;
				walrusLaunchTimer = walrusLaunchTimerReset;
			}
		}

		if ((Input.GetButtonDown ("Fire2")) && grabbed == true) 
		{
//			Debug.Log ("snowball says, nose cable detached!");
//			snowBallSpringGrabber = GetComponent<SpringJoint2D>();
//			snowBallSpringGrabber.enabled = false;
			snowBallDistanceGrabber = GetComponent<DistanceJoint2D>();
			snowBallDistanceGrabber.enabled = false;
			GetComponent<Rigidbody2D>().gravityScale = 1f;
			GetComponent<Rigidbody2D>().drag = 0.7f;
			GetComponent<Rigidbody2D>().angularDrag = 0.7f;
			GetComponent<Rigidbody2D>().mass = 1f;
			grabbed = false;
		} 

		if (walrusMeetsSnow == true) 	
		{
			walrusCollisionTimer -= Time.deltaTime;
			if (walrusCollisionTimer <= 0)
			{
//				rigidbody2D.isKinematic = true;
//				rigidbody2D.gravityScale = 1f;
				walrusCollisionTimer = walrusCollisionTimerReset;
				walrusMeetsSnow = false;
			}
		}
//		if (snowballMeetsOcean == true) 
//		{
//			transform.localScale -= Vector3(0.001,0.001,0.001); // Reduce object size over time
//			Debug.Log ("ice cube!");
//		}
	}

/*
I SHOULD create a second box collider, set it up as a trigger and then iterate through GetComponents... 
or create a new gameobject tag like, snowpack? maybe easier snowpack... let's try snowpack!!!
public Sprite[] projectileAttackSprite;

int i = Random.Range(0, projectileAttackSprite.Length);
Clone.GetComponent<SpriteRenderer>().sprite = projectileAttackSprite[i];
*/ 
}
