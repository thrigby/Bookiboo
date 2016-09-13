using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class enablebutton : MonoBehaviour {

	public Button button;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BtnOnClickEnable() 
	{ 
		gameObject.GetComponent<Button>().interactable = true;
	}
}
