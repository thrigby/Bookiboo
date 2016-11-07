using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=7,sendInterval=0.1f)]
public class noseflip_bullet_script : NetworkBehaviour {

	[SyncVar]
	public bool bulletFacingRight;

	[SyncVar]
	public float knockBackPwr;

	[SyncVar]
	public float snowBumpUpPwr = 600f;

	[SyncVar]
	public NetworkInstanceId bulletOwner;

	public int amount = 20;

	void OnTriggerEnter2D (Collider2D collision)
	{
		if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "enemy1")) 
		{ 
			var hit = collision.gameObject;
			var health = hit.GetComponent<SealHealth> ();
			if ((health != null) && (hit.GetComponent<SealControl2> ().owner != bulletOwner)) 
			{
				health.HitBy (bulletOwner);
				health.TakeDamage (amount);
				knockBackPwr = bulletFacingRight ? 200f : -200f;
				health.KnockBack (knockBackPwr);
//				if (isServer) 
//				{
//					health.RpcKnockback (knockBackPwr);
//
//				}	
				Destroy (gameObject);
//			Debug.Log ("BULLET: " + bulletFacingRight);
			}
		}
		if (collision.gameObject.tag == "snowballz") {
			var hit = collision.gameObject;
				var snowhit = hit.GetComponent<SnowTailCollider> ();
				if (snowhit != null) {
					knockBackPwr = bulletFacingRight ? 100f : -100f;
						if (isServer) {
						snowhit.BumpSnowLat (knockBackPwr);
						snowhit.BumpSnowUp (snowBumpUpPwr);
					}
				}
				Destroy (gameObject);
			}

	}
}