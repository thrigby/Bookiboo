using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	public Vector2 wind;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Rigidbody2D>().velocity = wind;
	}
}
