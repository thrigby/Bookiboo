using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelmanagement : MonoBehaviour {

//	public Button nextLevel;
	public levelmanagement Instance;

	public int level = 1;

	// Use this for initialization
	void Start () {
//	nextLevel.gameObject.SetActive (false);

		if (Instance != null) 
		{
			levelmanagement.Destroy (gameObject);
		} 
		else 
		{
			levelmanagement.DontDestroyOnLoad (gameObject);
			Instance = this;
		}	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
