using UnityEngine;
using System.Collections;

public class WalrusTailLaunch : MonoBehaviour {

	Animator anim;

	public BoxCollider2D walrusTailSpace;
	
	public bool walrusTailFlip = false;
	public float walrusTailTimer = 2f;
	public float walrusTailTimerReset = 2f;
	
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
	}
	//we're evaluating the snowball when really we want to be evaulating the collider & the snowball

	void OnTriggerEnter2D (Collider2D col)	
	{
		if ((col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball") || (col.gameObject.tag == "Player"))
		{
//			Debug.Log ("WalrusTailLaunch.cs tail animation true");
//			walrusTailSpace = GetComponentInChildren<BoxCollider2D>();
			anim.SetBool ("WalrusHangry", true);
			walrusTailFlip = true;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (walrusTailFlip == true) 
		{
			walrusTailTimer -= Time.deltaTime;
			if (walrusTailTimer < 0)
			{
				walrusTailFlip = false;
				anim.SetBool ("WalrusHangry", false);
				walrusTailTimer = walrusTailTimerReset;
//				Debug.Log ("WALRUS Tail Timer Reset");
			}
		}
	}
}
