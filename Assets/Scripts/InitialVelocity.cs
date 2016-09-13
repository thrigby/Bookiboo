using UnityEngine;
using System.Collections;

public class InitialVelocity : MonoBehaviour {

	public Vector3 initVel;

	void Start () {
		this.GetComponent<Rigidbody2D>().velocity = initVel;
	}
}
