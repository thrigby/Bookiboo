using UnityEngine;
using System.Collections;

public class AnimationRigTest : MonoBehaviour {

	Animator anim;

	public float derpTimer = 15f;
	public float derpTimerReset = 15f;

	// Use this for initialization
	void Start () {


		anim = GetComponent<Animator> ();
//gotomouse	

	}
	
	// Update is called once per frame
	void Update ()
		{

				if (Input.GetButtonDown ("Fire3")) 
				{
					anim.SetBool ("chop", true);
				}
				else
					anim.SetBool ("chop", false);

				derpTimer -= Time.deltaTime;
				if ((derpTimer < 15) && (derpTimer > 10)) {
						Debug.Log ("IDLE");
						anim.SetLayerWeight (0, 1);
						anim.SetLayerWeight (1, 0);
						anim.SetLayerWeight (2, 0);
				}
				if ((derpTimer < 10) && (derpTimer > 5)) {
						Debug.Log ("AXE");
						anim.SetLayerWeight (0, 0);
						anim.SetLayerWeight (1, 1);
						anim.SetLayerWeight (2, 0);
				}
				if ((derpTimer < 5) && (derpTimer > 0)) {
						Debug.Log ("OAR");
						anim.SetLayerWeight (0, 0);
						anim.SetLayerWeight (1, 0);
						anim.SetLayerWeight (2, 1);
				}	
				if (derpTimer < 0) {
					derpTimer = derpTimerReset;
				}
		
	}
}
