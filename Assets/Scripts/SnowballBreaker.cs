using UnityEngine;
using System.Collections;

public class SnowballBreaker : MonoBehaviour {

	public GameObject snowballx;
	public GameObject powerUp;
	public int snowBallCollisions = 0;
	public int snowBallLevPoints = 5;
	public int snowBallHitPoints = 10;

	public float snowBallGrav = -0.01f;
	public float snowBallGravRand = 0f;
	public float snowBallGravRandLow = 0f;
	public float snowBallGravRandHigh = 2f;

	public bool snowBallTimerOn = false;
	public float snowBallTimer = 10f;
	public float snowBallTimerLow = 10f;
	public float snowBallTimerHigh = 30f;

	void OnTriggerEnter2D (Collider2D col) //SNOWBALL SCRIPT
	{
		if (col.gameObject.tag == "nose" || col.gameObject.tag == "enose" || col.gameObject.tag == "tailslap" || col.gameObject.tag == "enemytailslap" || col.gameObject.tag == "narwhal" || col.gameObject.tag == "wh" || col.gameObject.tag == "Walrus") 
		{
			UpdateSnowball();
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "snowball") 
		{
			Debug.Log ("snowball v snowball");
			UpdateSnowball();
		}
	}

	public void UpdateSnowball ()
	{
		snowBallCollisions++;
		if (snowBallCollisions >= snowBallLevPoints) {
			snowBallGravRand = Random.Range (snowBallGravRandLow, snowBallGravRandHigh);
			snowballx.gameObject.GetComponent<Rigidbody2D> ().gravityScale = snowBallGrav * snowBallGravRand;
			snowBallTimer = Random.Range (snowBallTimerLow, snowBallTimerHigh);
			snowBallTimerOn = true;
		}
		if (snowBallCollisions >= snowBallHitPoints) {
			Debug.Log ("Collisions = " + snowBallCollisions);
			GameObject powerUpGO = (GameObject)Instantiate (powerUp, transform.position, transform.rotation);
			powerUpGO.SetActive(true);
			Destroy (gameObject);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
		{

		if (snowBallTimerOn) {
			snowBallTimer -= Time.deltaTime;
		}

		if (snowBallTimer < 0) 
		{
			snowBallCollisions = snowBallHitPoints;
			UpdateSnowball ();
		}
	
	}
}
