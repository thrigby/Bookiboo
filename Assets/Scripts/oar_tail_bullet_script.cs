using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=7,sendInterval=0.1f)]
public class oar_tail_bullet_script : NetworkBehaviour {

	[SyncVar]
	public bool bulletFacingRight;

	[SyncVar]
	public float knockBackPwr = 0f;

	[SyncVar]
	public float snowBumpUpPwr = 350f;

	[SyncVar]
	public NetworkInstanceId bulletOwner;


	public int amount = 40;

	void OnTriggerEnter2D (Collider2D collision)
	{
		if ((collision.gameObject.tag == "Player")  || (collision.gameObject.tag == "enemy1"))
		{ 
			var hit = collision.gameObject;
			var health = hit.GetComponent<SealHealth> ();
			if ((health != null) && (hit.GetComponent<SealControl2> ().owner != bulletOwner))
			{
				health.HitBy (bulletOwner);
				health.TakeDamage (amount);
				knockBackPwr = bulletFacingRight ? 350f : -350f;
				health.KnockBack (knockBackPwr);
				if (isServer) 
				{
					health.RpcKnockback (knockBackPwr);
				}	
				Destroy (gameObject);
//				Debug.Log ("BULLET: " + bulletFacingRight);
			}
		}
		if (collision.gameObject.tag == "snowballz") {
			var hit = collision.gameObject;
				var snowhit = hit.GetComponent<SnowTailCollider> ();
				if (snowhit != null) {
					knockBackPwr = bulletFacingRight ? 350f : -350f;
						if (isServer) {
						snowhit.BumpSnowLat (knockBackPwr);
						snowhit.BumpSnowUp (snowBumpUpPwr);
					}
				}
				Destroy (gameObject);
			}

	}
}