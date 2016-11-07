using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=7,sendInterval=0.1f)]
public class tailslap_bullet_script : NetworkBehaviour {

	[SyncVar]
	public bool bulletFacingRight;

	[SyncVar]
	public float knockBackPwr = 0f;

	[SyncVar]
	public float snowBumpUpPwr = 50f;

	[SyncVar]
	public NetworkInstanceId bulletOwner;

	public int amount = 30;

	void OnTriggerEnter2D (Collider2D collision)
		{	
		if ((collision.gameObject.tag == "Player") || (collision.gameObject.tag == "enemy1"))
			{ 
			var hit = collision.gameObject;
			var health = hit.GetComponent<SealHealth> ();
				if ((health != null) && (hit.GetComponent<SealControl2> ().owner != bulletOwner)) {
//				Debug.Log ("tailslap_bullet.cs " + bulletOwner);
				health.HitBy (bulletOwner);
//				health.sHitBy (derpBulletOwner);
				health.TakeDamage (amount);
				knockBackPwr = bulletFacingRight ? 300f : -300f;
				health.KnockBack (knockBackPwr);
//								if (isServer) {
//										Debug.Log ("RPC BULLET " + bulletOwner);
//										health.RpcHitBy (bulletOwner);
//										health.RpcKnockback (knockBackPwr);
//								}	
				Destroy (gameObject);
//			Debug.Log ("BULLET: " + bulletFacingRight);
						}

			}
				if (collision.gameObject.tag == "snowballz") {
						var hit = collision.gameObject;
						var snowhit = hit.GetComponent<SnowTailCollider> ();
						if (snowhit != null) {
								knockBackPwr = bulletFacingRight ? 300f : -300f;
								if (isServer) {
									snowhit.BumpSnowLat (knockBackPwr);
									snowhit.BumpSnowUp (snowBumpUpPwr);
								}
						}
						Destroy (gameObject);
				}
	}
}