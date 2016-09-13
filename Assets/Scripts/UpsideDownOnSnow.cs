using UnityEngine;
using System.Collections;

public class UpsideDownOnSnow : MonoBehaviour {

	public bool upSideDown = false;
	public float flipTimer = 0.5f;
	public float flipTimerReset = 0.5f;

	void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.gameObject.tag == "iceberg")
		{
//			Debug.Log ("Iceberg Detected.");
			upSideDown = true;
		}
		if (col.gameObject.tag == "herringsteamer")
		{
//			Debug.Log ("Steamer Detected.");
			upSideDown = true;
		}
	}
	
	void FixedUpdate ()
	{
		if (upSideDown == true) 
		{
			flipTimer -= Time.deltaTime;
			if (flipTimer > 0)
			{
				GetComponentInParent<Rigidbody2D> ().angularVelocity = 500f;
			}
			else if (flipTimer < 0 )
			{
				GetComponentInParent<Rigidbody2D> ().angularVelocity = 0f;
				flipTimer = flipTimerReset;
				upSideDown = false;
			}
		}

			

			
	}




}
