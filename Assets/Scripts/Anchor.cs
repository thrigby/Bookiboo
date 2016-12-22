using UnityEngine;
using System.Collections;

public class Anchor : MonoBehaviour {

	public Transform origin;
	public Transform finish;
	public LineRenderer lineRenderer;

	public Color c1 = Color.black;
	public Color c2 = Color.black;


//	public float speed = 4f;

	void Start()
	{
		lineRenderer = GetComponentInChildren<LineRenderer> ();
//		lineRenderer.SetColors (c1, c2);
		lineRenderer.startColor = c1;
		lineRenderer.endColor = c2;
	}

	void Update () 
	{
		lineRenderer.SetPosition (0, origin.position);
		lineRenderer.SetPosition (1, finish.position);
	}
}
