using UnityEngine;
using System.Collections;

public class MoveTracker : MonoBehaviour {

	public Camera camOne;

	void Awake ()
	{
		camOne.enabled = true;;
	}

	void OnCollisionEnter2D () {
//		Vector3 camPos = Camera.main.transform.position;
//		if (camPos.y < transform.position.y) {
		if (camOne.enabled == true) {
			camOne.GetComponent<CameraMover> ().targetY = transform.position.y;
		}
//			Camera.current.GetComponent<CameraMover>().targetY = transform.position.y;

		//		}
	}
}
