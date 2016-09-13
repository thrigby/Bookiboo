using UnityEngine;
using System.Collections;

public class UpInAir : MonoBehaviour {
/*
	public BoxCollider2D upInAir;

	public float airDrag = 0.5f;
	public float airAngularDrag = 0.5f;


//	void OnTriggerEnter2D(Collider2D other) {
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball")) 
		{
			col.rigidbody2D.gravityScale = 1;
			col.rigidbody2D.angularDrag = airAngularDrag;
			col.rigidbody2D.drag = airDrag;
			Debug.Log("UpInAir.cs trigger entered");
		}
	}
*/
/*
	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			col.rigidbody2D.gravityScale = 0;
			Debug.Log ("UpInAir.cs trigger left");
		}
	}
*/
//we will need a move to jump out of the water


//		public bool characterInQuicksand;
//		void OnTriggerEnter2D(Collider2D other) {
//			characterInQuicksand = true;
//		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
