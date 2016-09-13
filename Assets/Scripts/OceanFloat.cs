using UnityEngine;
using System.Collections;

public class OceanFloat : MonoBehaviour {
/*
	public BoxCollider2D oceanFloat;
	public GameObject fnerp;

	public float waterDrag = 5f;
	public float waterAngularDrag = 5f;

	public float airDrag = 0.5f;
	public float airAngularDrag = 0.5f;

	public bool cliffDive = false;
	public float cliffDiveTimer = 3f;
	public float cliffDiveTimerReset = 3f;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball")) 
		{
//			col.rigidbody2D.gravityScale = 0;
//			col.rigidbody2D.angularDrag = waterAngularDrag;
//			col.rigidbody2D.drag = waterDrag;
			cliffDive = true;
			fnerp = col.gameObject;
			Debug.Log("OceanFloat.cs Enter Ocean");
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if ((col.gameObject.tag == "Player") || (col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball")) 
		{
//			col.rigidbody2D.gravityScale = 1;
//			col.rigidbody2D.angularDrag = airAngularDrag;
//			col.rigidbody2D.drag = airDrag;
			Debug.Log("OceanFloat.cs Exit Ocean");
		}
	}

	void FixedUpdate()
	{
		if (cliffDive == true)
		{
			cliffDiveTimer -= Time.deltaTime;
			if (cliffDiveTimer < 0)
			{
				fnerp.rigidbody2D.gravityScale = 0;
				fnerp.rigidbody2D.angularDrag = waterAngularDrag;
				fnerp.rigidbody2D.drag = waterDrag;
				cliffDiveTimer = cliffDiveTimerReset;
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
*/
}
