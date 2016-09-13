using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class altimeter : MonoBehaviour {

//	public static int altitude; //altitude
//  if goes above screen have an arrow?
// 	falling achievement a' a wow
//	Text text; //reference to the text component
	public Text text;
	public int altitude;
	public GameObject player;
//	public GameObject[] booky;

	void Start ()
	{
//		GameObject player = GameObject.FindWithTag("Player");
//		booky = GameObject.FindGameObjectsWithTag("Player");
	}

	void Awake () 
	{
		text = GetComponent<Text>(); // set up the reference

//		altitude = 0; //reset the elevation
	}
	
	// Update is called once per frame
	void Update () 
	{

		altitude = Mathf.RoundToInt(player.transform.position.y);
//		Debug.Log("int val: " +iValue);
		text.text = "Elevation " + (altitude + 4);

	}
}
