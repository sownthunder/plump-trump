using System.Collections;
using UnityEngine;

public class ConstantVelocity : MonoBehaviour {

	public Vector3  direction      = Vector3.forward;

	// the rigid body attachd to this script, to replace deprecation
	Rigidbody theRigidbody;

	// Use this for pre-initialization
	void Awake ()
	{

		// get and set Rigidbody variable
		theRigidbody = transform.GetComponent<Rigidbody> ();

	}

	// Use this for initialization
	void Start () 
	{



	}
	
	// Update is called once per frame
	void Update () 
	{
	
		theRigidbody.velocity =  transform.rotation * direction;

	}

}
