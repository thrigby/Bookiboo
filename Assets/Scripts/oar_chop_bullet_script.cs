using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[NetworkSettings(channel=7,sendInterval=0.1f)]
public class oar_chop_bullet_script : NetworkBehaviour {

	[SyncVar]
	public bool bulletFacingRight;

	[SyncVar]
	public float knockBackPwr = 0f;

	[SyncVar]
	public float snowBumpUpPwr = 800f;

	[SyncVar]
	public NetworkInstanceId bulletOwner;

	public int amount = 55;

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{ 
			var hit = collision.gameObject;
			var health = hit.GetComponent<SealHealth> ();
//			hit.GetComponent<SealControl2> ().owner

			if ((health != null) && (hit.GetComponent<SealControl2> ().owner != bulletOwner))
			{
				health.HitBy (bulletOwner);
				health.TakeDamage (amount);
				knockBackPwr = bulletFacingRight ? 500f : -500f;
				health.KnockBack (knockBackPwr);
				if (isServer) 
				{
					health.RpcKnockback (knockBackPwr);
				}	
				Destroy (gameObject);
//			Debug.Log ("BULLET: " + bulletFacingRight);
			}

		}
		if (collision.gameObject.tag == "snowballz") {
			var hit = collision.gameObject;
				var snowhit = hit.GetComponent<SnowTailCollider> ();
				if (snowhit != null) {
					knockBackPwr = bulletFacingRight ? 100f : -100;
						if (isServer) {
						snowhit.BumpSnowLat (knockBackPwr);
						snowhit.BumpSnowUp (snowBumpUpPwr);
					}
				}
			Destroy (gameObject);
			}

	}
}