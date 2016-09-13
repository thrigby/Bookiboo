using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class gotomouse : MonoBehaviour {


//	Animator anim;
	public float speed = 1.5f;
	private Vector3 target;
//		public float move = 0f;
//		public float speed = 0f;

	void Start () {
		target.x = transform.position.x;
	}

	void Update () {
	if (Input.GetMouseButtonDown(0))
	{ 
		if (EventSystem.current.IsPointerOverGameObject ()) {
//			Debug.Log ("left-click over a GUI element!");
		}
		else		
		{
//			Debug.Log("just a left-click!");
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			target.x = transform.position.x;
			speed = 1.5f;
		}
	}
				transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
//				anim.SetFloat ("Speed", Mathf.Abs (move));
//				Debug.Log ("speed: " + speed);
//				Debug.Log ("target: " + target);
//				Debug.Log ("transform.position: " + transform.position);

		if (target.x == transform.position.x) 
		{
			speed = 0f;
//						Debug.Log ("0=0");
		}
//		if (target.z > transform.position.z) 
//		{
//			GetComponent<Rigidbody2D>().AddForce (Vector3.right * speed);
//		}
//		if (target.z < transform.position.z) 
//		{
//			GetComponent<Rigidbody2D>().AddForce (Vector3.left * speed);
//		}

	}

}
/*
void FixedUpdate () 
{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);	

		if (move > 0 && !facingRight)
				Flip ();
		else if (move < 0 && facingRight)
				Flip ();	
}
*/