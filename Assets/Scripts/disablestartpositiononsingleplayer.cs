using UnityEngine;
using System.Collections;

public class disablestartpositiononsingleplayer : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		GameObject oneSpawnOnly;
		oneSpawnOnly = GameObject.FindGameObjectWithTag ("singleplayermachine");
		Debug.Log (oneSpawnOnly);
		if (oneSpawnOnly.activeSelf == true) 
		{
//			GameObject derp;
//			derp = this.gameObject;
			this.gameObject.SetActive (false);
			Debug.Log ("spawn point disabled");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
