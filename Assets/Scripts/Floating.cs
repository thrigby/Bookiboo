using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	public float floatingForce = 50f;
	public float floatingHeight = 50f;
	private Rigidbody objectRigidbody;
//	public float hitInfo;

	void Awake ()
	{
		objectRigidbody = GetComponent <Rigidbody>();
	}

	void Update () 
	{
	
	}

	void FixedUpdate()
	{
		Ray ray = new Ray (transform.position, -transform.up * 10);
		RaycastHit hit;

		Debug.DrawRay (transform.position, -transform.up * 10, Color.white);

		if (Physics.Raycast (ray, out hit, floatingHeight)) 
		{
			Debug.Log ("DERPDPERDPERPERPD");
			float proportionalHeight = (floatingHeight - hit.distance) / floatingHeight;
			Vector3 appliedFloatingForce = Vector3.up * proportionalHeight * floatingForce;
			objectRigidbody.AddForce (appliedFloatingForce, ForceMode.Acceleration);
//public static void DrawRay(Vector3 start, Vector3 dir, Color color = Color.white, float duration = 0.0f, bool depthTest = true);
		}
	}
}

/*
using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;
    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidbody;


    void Awake () 
    {
        carRigidbody = GetComponent <Rigidbody>();
    }

    void Update () 
    {
        powerInput = Input.GetAxis ("Vertical");
        turnInput = Input.GetAxis ("Horizontal");
    }

    void FixedUpdate()
    {
        Ray ray = new Ray (transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
        carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

    }
}
*/
