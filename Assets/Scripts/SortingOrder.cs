using UnityEngine;
using System.Collections;

public class SortingOrder : MonoBehaviour {

	public bool leavingEngine = false;
	private SpriteRenderer sprite;
	public float engineLaunchPower = 2000f;

	public float leavingEngineTimer = 2f;
	public float leavingEngineTimerReset = 2f;

	void Start () //derp! start!
	{
		sprite = GetComponent<SpriteRenderer>();
	}

	void OnTriggerEnter2D (Collider2D col) //event!
	{
		if (col.gameObject.tag == "smokestack")
		{
			Debug.Log ("smokestack detected");
			sprite.sortingLayerName = "engine";
			sprite.sortingOrder = -3;
		}
		if (col.gameObject.tag == "smokestackleaver") 
		{
			Debug.Log ("leaving engine");
			GetComponentInParent<Rigidbody2D>().AddForce (Vector2.up * engineLaunchPower, ForceMode2D.Force);
			leavingEngine = true;
		}
	}

	void Update() //once per frame!
	{
		if (leavingEngine == true) 
		{
			leavingEngineTimer -= Time.deltaTime;
			if (leavingEngineTimer < 0)
			{
				Debug.Log ("sorting layers reset");
				sprite.sortingLayerName = "character";
				sprite.sortingOrder = 0;
				leavingEngine = false;
				leavingEngineTimer = leavingEngineTimerReset;
			}

		}
	}
}
//	void OnTriggerEnter2D (Collider2D col)
//	{
//		if (col.gameObject.tag == "smokestackleaver") 
//		{
//			Debug.Log ("leaving engine");
//			leavingEngine = true;
//			sprite.sortingLayerName = "character";
//			sprite.sortingOrder = 0;	
//		}			
//	}

//	void Update () {
//		if (sprite)
//	{
//		sprite.sortingOrder = sortingOrder;
//	}
//	}
//}
