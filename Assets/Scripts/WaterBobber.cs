using UnityEngine;
using System.Collections;

public class WaterBobber : MonoBehaviour 
{
	public float seaLevel = 0f;
	public float liftForce = 10f;
	public float damping = 2f;

	public float range = 10f;
	public float debugRange = 10f;

	public int layerMask = 4;
	public bool derp = false;

	public float depth;
	public float depthReset = 0f;

// on key press, we figure out how deep the baby seal is and that calculates an upward force so there's a dramatic breach.
// maybe a reverse gravity thing? increasing in momentum? fiddle w/ gravityscale instead of doing ridigbody vectors?
// holy crap. if under water and tailslap, reverse gravity?
// still need raycasting for "bobbing" on the water? or use a temporary spring joint?

	void Update () 
	{
		Tailslap ();
	}


	void FixedUpdate()
	{
		if (derp == true) 
		{
			RaycastHit2D hit = Physics2D.Raycast (transform.parent.localPosition, Vector2.up);
			if (hit.collider != null) 
			{
//				float depth = Mathf.Abs (hit.point.y - transform.position.y);
//				float pressure = seaLevel - depth;
//				float force = liftForce * pressure;// - (rigidbody2D.velocity.y * damping); //original rigidbody2D.velocity.y
//				Debug.Log (hit.distance + "DEPTH:  " + depth + "liftForce:   " + liftForce + "* pressure :  " + pressure + "- rigidbody2D.velocity.y:  " + rigidbody2D.position.y + "*damping:  " + damping + "= force:  " + force);
//				depth = Vector2.Distance( hit.point, transform.position );
				depth = hit.point.y - transform.position.y;
				GetComponent<Rigidbody2D>().AddForce (Vector2.up * depth * liftForce);
				Debug.DrawRay (transform.parent.localPosition, Vector2.up * debugRange);
				Debug.Log ("collider   " + hit.collider);
				Debug.Log ("depth   " + depth);
				Debug.Log ("point      " + hit.point);
				Debug.Log ("fraction   " + hit.fraction);
				derp = false;

			}
		}
	}

	public void Tailslap ()
	{
		if (Input.GetButtonDown ("Tailslap")) 
		{
//			derp = true;
//			anim.SetBool ("Tailslap", true);
//			timeStamp = Time.time + tailSlapLag;
			Debug.Log ("tailslap pinged");
		}
	}

}
