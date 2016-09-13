using UnityEngine;
using System.Collections;

public class SealLauncher : MonoBehaviour {

	public Rigidbody2D sealRig;
	public BoxCollider2D sealLaunchBoxCollider;
	//walrus head launch variables
	public bool sealWhLaunch = false;
	public float sealWhLaunchTimer = 0.5f;
	public float sealWhLaunchTimerReset = 0.5f;
	public float sealWhLaunchForce = 200f;
	//walrus tail launch variables
	public bool sealWalrusTailLaunch = false;
	public float sealWalrusTailLaunchTimer = 0.5f;
	public float sealWalrusTailLaunchTimerReset = 0.5f;
	public float sealWalrusTailLaunchForce = 300f;

	void Start () {
		sealRig = GetComponentInParent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "wh") 
		{
//			Debug.Log ("SealLauncher.cs wh tag detected");
			sealWhLaunch = true;
		}
		if (col.gameObject.tag == "walrustail") 
		{
//			Debug.Log ("SealLauncher.cs walrustail tag detected");
			sealWhLaunch = true;
		}		
	}

	void Update () 
	{
		if (sealWhLaunch == true)
		{
			sealWhLaunchTimer -= Time.deltaTime;
			if (sealWhLaunchTimer < 0)
			{
				sealRig.AddForce (Vector2.up * sealWhLaunchForce, ForceMode2D.Force);
//				Debug.Log ("SealLauncher.cs walrus WH tag seal launch");
				sealWhLaunch = false;
				sealWhLaunchTimer = sealWhLaunchTimerReset;
			}
		}
		if (sealWalrusTailLaunch == true)
		{
			sealWalrusTailLaunchTimer -= Time.deltaTime;
			if (sealWalrusTailLaunchTimer < 0)
			{
				sealRig.AddForce (Vector2.up * sealWalrusTailLaunchForce, ForceMode2D.Force);
				Debug.Log ("SealLauncher.cs walrus TAIL tag seal launch");
				sealWalrusTailLaunch = false;
				sealWalrusTailLaunchTimer = sealWalrusTailLaunchTimerReset;
			}
		}
	}
}
