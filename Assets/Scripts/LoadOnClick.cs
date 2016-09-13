using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
	
	public int level = 1;

	void Awake()
	{
	}

	public void LoadCurrentLevel()
	{
		SceneManager.LoadScene (level);
		level++;
	}
	

}
