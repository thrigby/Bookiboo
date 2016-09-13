using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class EnemyHealth : MonoBehaviour {

	public Slider slider;
	public Image Fill;
	public float sealHealth = 100f;
	public float sealHealthLow = 25f;

	public float enemybootHeadForce = 100f;
	public float eNoseFlipForce = 200f;
	public float bump = 50f;
	public float regen = 0.01f;

	public float damage = 10f;

	public bool hitEvent = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = sealHealth;
//		slider.value = Mathf.MoveTowards (slider.value, 100.0f, 0.15f);
				if (slider.value <= sealHealthLow) {
						Fill.color = Color.red;
						GetComponentInParent<EnemyController1> ().sealDamaged = true;
				} else 
				{
						Fill.color = Color.white;
						GetComponentInParent<EnemyController1> ().sealDamaged = false;
				}
	}

	public void SetHealth ()
	{
		if (hitEvent) 
		{
			if (sealHealth > sealHealthLow) 
				{
					sealHealth -= damage;
					hitEvent = false;
				} 
				else 
				{
					Debug.Log ("overkill triggered");					
					hitEvent = false;
				}
			if (sealHealth < 0) 
			{
				sealHealth = 0;	
				hitEvent = false;
			}
		}
		else if (!hitEvent) 
		{
			sealHealth += regen;
		}

	}
		//enemy vs. player
	void OnTriggerEnter2D (Collider2D col)
	{
//				if (col.gameObject.tag == "Player") 
//				{
//						Debug.Log ("Player v Enemy!!!!!!*************");
//						move = 0;
//						inMelee = true;
//				}
//end propulsion
//getting hit
		if (col.gameObject.tag == "tailslap") 
		{
			if (!GameObject.Find ("Character").GetComponent<SealControl2> ().facingRight) 
			{
//				Debug.Log ("tailslap enemy facing right");
				enemybootHeadForce *= -1;
			} 
			else if (GameObject.Find ("Character").GetComponent<SealControl2> ().facingRight) 
		{
//				Debug.Log ("tailslap enemy facing left");
		}

		GetComponentInParent<Rigidbody2D>().AddForce (Vector2.right * enemybootHeadForce, ForceMode2D.Force);
		GetComponentInParent<Rigidbody2D>().AddForce (Vector2.up * bump, ForceMode2D.Force);
//			Debug.Log ("derp derp derp!");
			hitEvent = true;
			SetHealth();

		if (enemybootHeadForce < 0)
		{
			enemybootHeadForce *= -1;	
//				Debug.Log ("bootHeadForce reset");
		}
		}
		if (col.gameObject.tag == "nose") 
		{
			GetComponentInParent<Rigidbody2D>().AddForce (Vector2.up * eNoseFlipForce, ForceMode2D.Force);
//			Debug.Log ("noseflip triggered.");
			hitEvent = true;
			SetHealth();
		}

	}
//end getting hit
//end enemy vs. player
}
