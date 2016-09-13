using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SealScore1 : MonoBehaviour {

	public int sealScore;
	public Text sealScoreText;
	public Text winText;
	public Button nextLevel;

	public int nextLevelInt = 1;

//	public SealScore1 Instance;
//	public int level = 1;

	public int winNumber = 10;

	// Use this for initialization
	void Start () {
		sealScore = 0;
		SetSealScoreText ();
		winText.text = "";
		nextLevel.gameObject.SetActive (false);
//		nextLevelInt = Application.loadedLevel +1;
//		if (Instance != null) 
//		{
//			GameObject.Destroy (gameObject);
//		} else 
//		{
//			GameObject.DontDestroyOnLoad (gameObject);
//			Instance = this;
//		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.gameObject.tag == "snowball") 
		{
//			Debug.Log ("GOAL!!!!!!");
			sealScore = sealScore + 1;
			SetSealScoreText ();
		}
	}

	void SetSealScoreText ()
	{
		sealScoreText.text = sealScore.ToString ();
		if (sealScore >= winNumber) 
		{
			winText.text = "You Win!";
			nextLevel.gameObject.SetActive (true);
//			nextLevelInt = GameObject.FindWithTag ("levelmanager").GetComponent<levelmanagement> ().level + 1;
//			nextLevelInt = Application.loadedLevel +1;
//			Debug.Log (Application.loadedLevel);
//			Debug.Log (nextLevelInt);
		}
	}

	public void loadNextLevel()
	{
		SceneManager.LoadScene (nextLevelInt, LoadSceneMode.Single);
	}

		//GameObject.FindWithTag ("levelmanager").GetComponent<levelmanagement> ().level + 1;
}
