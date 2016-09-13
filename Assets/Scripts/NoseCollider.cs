using UnityEngine;
using System.Collections;

public class NoseCollider : MonoBehaviour {
		//this is the snowball's script that detects the nose collider and sends the snowball flying


//	Character character;
	
	public float noseShotPower;
	public float noseBumpForce = 50;

	void OnTriggerEnter2D (Collider2D col) //SNOWBALL SCRIPT
	{
		if (col.gameObject.tag == "nose" || col.gameObject.tag == "enose") 
		{
				noseShotPower = GameObject.FindWithTag ("nose").GetComponent<NoseFlip> ().shotPower;
//				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * GameObject.FindWithTag ("nose").GetComponent<NoseFlip>().shotPower, ForceMode2D.Force);
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * noseShotPower, ForceMode2D.Force);
				Debug.Log ("snowball- noseShotPower = " + noseShotPower);
//				snowballHitBool = false;
				if (!GameObject.FindWithTag ("Player").GetComponent<SealControl2> ().facingRight) 
				{
					noseBumpForce *= -1;
				}

				GetComponent<Rigidbody2D> ().AddForce (Vector2.right * noseBumpForce, ForceMode2D.Force);
				if (noseBumpForce < 0) 
				{
					noseBumpForce *= -1;
				}
		}
	}

	void Start () {
//		noseShotPower = GameObject.FindWithTag ("nose").GetComponent<NoseFlip> ().shotPower;
	}
	
	void FixedUpdate () {
	}
}
