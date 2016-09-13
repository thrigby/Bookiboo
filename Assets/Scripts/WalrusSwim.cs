using UnityEngine;
using System.Collections;

public class WalrusSwim : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "underwater") 
		{
//			Debug.Log ("walrus overboard!");
//			GetComponent<Rigidbody2D>().gravityScale = 0f;
//			GetComponent<Rigidbody2D>().drag = 30f;
//			GetComponent<Rigidbody2D>().angularDrag = 50f;
//			gameObject.tag = "snowpack";
//			anim.SetBool ("Splatted", true);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
