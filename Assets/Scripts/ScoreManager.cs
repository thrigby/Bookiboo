﻿using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int score = 0;

	void OnGUI () {
		GUI.Label (new Rect (0, 0, 100, 50), "Score " + score);
	}

}
