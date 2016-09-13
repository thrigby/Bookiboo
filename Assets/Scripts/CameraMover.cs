using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public float targetY = 0;
	public float normal = 2f;
	public float smooth = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 pos = transform.position;
		pos.y = Mathf.Lerp (transform.position.y, targetY, 1 * Time.deltaTime);
		transform.position = pos;
		smooth = normal + (targetY/4);
		GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize,smooth,Time.deltaTime);
	

//				Debug.Log ("smooth = " + smooth);
//				Debug.Log ("normal = " + normal);
	}
}
