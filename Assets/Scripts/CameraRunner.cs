using UnityEngine;
using System.Collections;

public class CameraRunner : MonoBehaviour {

	public Transform target; //what to follow
	public float smoothing = 5f; //camera speed

	public Vector3 offset;

	void Start()
	{
//    	offset = transform.position - target.position;
//    	Debug.Log ("transform.position: " + transform.position);
//  	Debug.Log ("-target.position: " + target.position);	
	}

	void FixedUpdate ()
		{
		if (target != null) 
		{
			Vector3 targetCamPos = target.position + offset;
    		transform.position = Vector3.Lerp (transform.position,  targetCamPos,smoothing * Time.deltaTime);
		}
		else
			return;
	}	
}


/*
	//write stratosphere script
	public Transform player;

	public float targetY = 0;
	public float normal = 20f;
	public float smooth = 1f;
	
	public float normalUpper = 24f;
	public float normalMiddle = 16f;
	public float normalLower = 8f;

	public float lowerStrato = 32f;
	public float middleStrato = 40f;
	public float upperStrato = 48f;

	public float panningLimit = 205f;
*/



/*	void Update () 
	{

		transform.position = new Vector3 (player.position.x, player.position.y, -10);

		if (transform.position.y > upperStrato)
		{
			normal = upperStrato;
			Debug.Log ("upperStrato");
//			transform.position.y = panningLimit;

			Vector3 temp = transform.position; // copy to an auxiliary variable...
			temp.y = 130f; // modify the component you want in the variable...
			transform.position = temp; // and save the modified value 
		}
		else if ((transform.position.y > middleStrato) && (transform.position.y < upperStrato))
		{
			normal = middleStrato;
			Debug.Log ("middleStrato");
		}
		else if ((transform.position.y > lowerStrato) && (transform.position.y < middleStrato))
		{
			normal = lowerStrato;
			Debug.Log ("lowerStrato");
		}
		else if ((transform.position.y > normalUpper) && (transform.position.y < lowerStrato))
		{
			normal = normalUpper;
		} 
		else if ((transform.position.y > normalMiddle) && (transform.position.y < normalUpper)) 
		{
			normal = normalMiddle;
		} 
		else if ((transform.position.y > normalLower) && (transform.position.y < normalMiddle))
		{
			normal = normalLower;
		} 
		else if ((transform.position.y > -normalMiddle) && (transform.position.y < -normalLower))
		{
			normal = normalMiddle;		
		} 
		else if (transform.position.y < -normalUpper) 
		{
			normal = normalUpper;
		}
						
		smooth = normal + (targetY / 25);
		GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize,smooth,Time.deltaTime);
	}
}
*/

