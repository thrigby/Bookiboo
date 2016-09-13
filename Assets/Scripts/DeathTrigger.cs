using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour {

	public bool hasLost = false;


	void FixedUpdate () {
		if (GameObject.FindObjectOfType<DeathTrigger> ().hasLost) {
				return;		
			}
	}

	void OnTriggerEnter2D() {
		hasLost = true;
	}

	void OnGUI () {
		if (hasLost) {
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-25, 200, 100), "Game Over" );
			if(GUI.Button(new Rect(Screen.width/2-50, Screen.height/2-25 + 20, 100, 100), "Restart" )) {
//				Application.LoadLevel( Application.loadedLevel);
			}
		}
	}
}
