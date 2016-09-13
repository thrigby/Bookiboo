using UnityEngine;
using System.Collections;

public class GetEaten : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D col)
	{
				if (col.gameObject.tag == "Player" || col.gameObject.tag == "enemy1" || col.gameObject.tag == "walrus" || col.gameObject.tag == "narwhal" ) 
		{
			Debug.Log ("powerup collides w/ game character");
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
