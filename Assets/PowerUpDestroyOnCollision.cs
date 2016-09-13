using UnityEngine;
using System.Collections;

public class PowerUpDestroyOnCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Object.Destroy(this.gameObject, 0);
		}	
	}
}
