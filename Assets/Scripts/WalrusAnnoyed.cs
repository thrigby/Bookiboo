using UnityEngine;
using System.Collections;

public class WalrusAnnoyed : MonoBehaviour {

	Animator anim;

	public CircleCollider2D walrusPersonalSpace;

	public bool walrusHeadFlip = false;
	public float walrusTimer = 2f;
	public float walrusTimerReset = 2f;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInParent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D col)	
	{
//		if (gameObject.tag  == "walrustail") 
//		if (col.gameObject.tag == "snowball")
		if ((col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball") || (col.gameObject.tag == "Player"))
		{
//			if (col.gameObject.tag == "snowball") 
			if ((gameObject.tag  == "wh"))
			{
//			Debug.Log ("WALRUS IS ANNOYED BY SNOWBALL");
			anim.SetBool ("WalrusAnnoyed", true);
			walrusHeadFlip = true;
			}
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (walrusHeadFlip == true) 
		{
			walrusTimer -= Time.deltaTime;
			if (walrusTimer < 0)
			{
				walrusHeadFlip = false;
				anim.SetBool ("WalrusAnnoyed", false);
				walrusTimer = walrusTimerReset;
//				Debug.Log ("WalrusAnnoyed.cs walrus timer reset, anim false");
			}
		}
	}
}
