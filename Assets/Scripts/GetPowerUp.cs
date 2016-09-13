using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPowerUp : MonoBehaviour {

	public Text powerUpMssg;

	public int lotteryNum;
	public int lotteryMin = 0;
	public int lotteryMax = 14;

	void OnCollisionEnter2D (Collision2D col)
	{
	if (col.gameObject.tag == "powerup") 
		{
			Debug.Log ("Player Eats Powerup!");
			ChoosePowerUp();
		}
	}

	public void ChoosePowerUp ()
	{
		lotteryNum = Random.Range (lotteryMin, lotteryMax); // 0 - 14

			if (lotteryNum >= 0 && lotteryNum <= 2) 
			{
				Grow ();
			}
			else if (lotteryNum >= 3 && lotteryNum <= 5) 
			{
				Fast ();
			}
			else if (lotteryNum >= 6 && lotteryNum <= 8) 
			{
				Shrink ();
			}
			else if (lotteryNum >= 9 && lotteryNum <= 11) 
			{
				Jump ();
			}
			else if (lotteryNum >= 12 && lotteryNum <= 14) 
			{
				ZeroGrav ();
			}

	}

	public void Grow ()
	{
		Debug.Log ("GROW!");
		float scale = 1.5f;
		transform.localScale = Vector2.one * scale;
	}

	public void Fast ()
	{
		Debug.Log ("FAST!");	//original = 1.5f
		GetComponentInParent<SealControl2> ().speed = 3f;
		powerUpMssg.text = "FAST!";
	}

	public void Shrink ()
	{
		Debug.Log ("SHRINK!");
		float scale = 0.5f;
		transform.localScale = Vector2.one * scale;
		powerUpMssg.text = "SHRINK!";
	}

	public void Jump ()
	{
		Debug.Log ("JUMP!");	//original = 250f
		GetComponentInParent<SealControl2> ().jumpForce = 500f;
		powerUpMssg.text = "JUMP!";
	}
		public void ZeroGrav ()
	{
		Debug.Log ("ZERO G!");
		GetComponent<Rigidbody2D> ().gravityScale = 0;
		powerUpMssg.text = "ZERO G!";
	}

	// Use this for initialization
	void Start () {
		powerUpMssg.text = "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
/*
*POWER UPS*
	tail slap snowball to free power up?

	tail flip (boot head force + snowball) x 200
	nose flip force x 200
	jumping x 200
	zero g
	multishot snowball x3?
x	speed
	heath regen
	damage
	dominance
x	x2 size
	balloon
	mutagen, akira seal
	make a snowball, clone another seal
	atomic baby gun
	hailstorm!
	double jump
	dive kick
	hamsterball
	turn into Walrus
	see invisible
	grow (and not stop)
x	shrink
	cute overload
*/

