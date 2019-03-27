using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfBall : MonoBehaviour {

	public float launchSpeed;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{

		rigidBody = GetComponentInChildren<Rigidbody> ();
		rigidBody.velocity = new Vector3 (0, 0, launchSpeed);

	}
	
	// Update is called once per frame
	void Update () 
	{



	}

}
