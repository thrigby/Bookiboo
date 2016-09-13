using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=7,sendInterval=0.01f)]
public class SnowTailCollider : NetworkBehaviour {


//	public float tailSlapForce = 100;
//	public float snowBallBump = 20f;

	public void BumpSnowLat (float knockBackPwr)
	{
		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * knockBackPwr, ForceMode2D.Force);
	}

	public void BumpSnowUp (float snowBumpUpPwr)
	{
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * snowBumpUpPwr, ForceMode2D.Force);
	}
/*
	[ClientRpc]	
	public void RpcBumpSnowLat (float knockBackPwr)
	{
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * knockBackPwr, ForceMode2D.Force);
	}

	[ClientRpc]	
	public void RpcBumpSnowUp (float snowBumpUpPwr)
	{
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * snowBumpUpPwr, ForceMode2D.Force);
	}
*/

//	[SyncVar(hook = "TailslapCallback")]
//  public bool hitByTail = false;

//	public Collider2D col;
/*
	[ClientCallback]
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "tailslap") 
		{	
			if (col.gameObject.GetComponentInParent<Player_SyncPosition> ().netFacingRight == false) 
			{
				tailSlapForce *= -1;
			}
				Apply_Tailslap_Force ();
//				hitByTail = true;
				tailSlapForce = tailSlapForce < 0 ? tailSlapForce *= -1 : tailSlapForce *= 1;
		}
//			message = health > 0 ? "Player is Alive" : "Player is Dead";
	}

//	[Command]
	void Apply_Tailslap_Force ()
	{
		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * tailSlapForce, ForceMode2D.Force);
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * snowBallBump, ForceMode2D.Force);
	}
*/

//	[Client]
//	void TailslapCallback (bool hitByTail)
//	{
//		GetComponent<Rigidbody2D> ().AddForce (Vector2.right * tailSlapForce, ForceMode2D.Force);
//		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * snowBallBump, ForceMode2D.Force);
//		hitByTail = false;
//	}

		//		Cmd_Apply_Tailslap_Force ();
//		Debug.Log (col.gameObject.tag);
//		Debug.Log (col.gameObject.GetComponentInParent<NetworkIdentity>().assetId);
//		Debug.Log (col.gameObject.GetComponentInParent<SealControl2>().facingRight);
//		if (!GameObject.FindWithTag ("Player").GetComponent<SealControl2>().facingRight)


}
