using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyScore : MonoBehaviour {

	public int sealScore;
	public Text sealScoreText;
	public Text loseText;
	public Button restart;

	public int loseNumber = 10;


	// Use this for initialization
	void Start () {
		sealScore = 0;
		SetSealScoreText ();
		loseText.text = "";
//		restart.enabled = false;
		restart.gameObject.SetActive (false);
//		restart.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {

//		if (sealScore >= 10)

//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

//		if (Input.GetKeyDown(KeyCode.R))
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	
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
		if (sealScore >= loseNumber) 
		{
			loseText.text = "You Lose!";
//			restart.enabled = true;
			restart.gameObject.SetActive (true);

//			restart.interactable = true;
		}
	}

	public void ReLoadScene()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}

}
