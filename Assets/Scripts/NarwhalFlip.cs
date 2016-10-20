using UnityEngine;
using System.Collections;

public class NarwhalFlip : MonoBehaviour {

	Animator anim;

	public CircleCollider2D narwhalFlipSpace;

	public bool narwhalHeadFlip = false;
	public float narwhalTimer = 2f;
	public float narwhalTimerReset = 2f;
	
	void Start () 
	{
		anim = GetComponentInParent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D col)	
	{
		if ((col.gameObject.tag == "snowball") || (col.gameObject.tag == "iceball") || (col.gameObject.tag == "Player"))
		{
//			if ((gameObject.tag  == "wh"))
//			{
			anim.SetBool ("NarwhalFlip", true);
			narwhalHeadFlip = true;
//			}
		}
	}
	void Update () 
	{
		if (narwhalHeadFlip == true) 
		{
			narwhalTimer -= Time.deltaTime;
			if (narwhalTimer < 0)
			{
				narwhalHeadFlip = false;
				anim.SetBool ("NarwhalFlip", false);
				narwhalTimer = narwhalTimerReset;
			}
		}
	}
}
