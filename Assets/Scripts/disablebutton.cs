﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class disablebutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BtnOnClickDisable() 
	{ 
		gameObject.GetComponent<Button>().interactable = false;
	}
}
