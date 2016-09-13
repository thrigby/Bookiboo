using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class instructions : MonoBehaviour {

	public Text instruct;
	public Text instructFull;

	public bool instructBool = false;

	public float instructTimer = 0.5f;
	public float instructTimerReset = 0.5f;

//	public bool instructFullBool = false;

	// Use this for initialization
	void Start () {
	
		instruct.text = "Press i for Instructions";
	}
	
	// Update is called once per frame
	void Update () {
/*		if (Input.GetKeyDown (KeyCode.I) && !instructFull.gameObject.active) //key & inactive
		{
			instructBool = true;
			instructFull.gameObject.SetActive (true);
		}
			
		if (instructFull.gameObject.active) 
		{
			instructTimer -= Time.deltaTime;
		}
		
		if (instructTimer < 0)
		{
			instructBool = false;
		}
			
		if (Input.GetKeyDown (KeyCode.I) && !instructBool) 
		{
			instructFull.gameObject.SetActive (false);
			instructTimer = instructTimerReset;
		}
*/

	}
}
