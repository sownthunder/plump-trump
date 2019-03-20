using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : MonoBehaviour {

	// public gameObject to hold door variable
	public GameObject theDoor1;

	public Animation anim;

	// Pre-initialization 
	void Awake ()
	{


	}

	// Use this for initialization
	void Start () 
	{

		// GET & SET DOOR(S)...
		theDoor1 = GameObject.FindWithTag("SciFiDoor");

		// GET & SET ANIMATION
		anim = theDoor1.gameObject.GetComponent<Animation>();

		// loop through all AnimationStates??? (the door opening & cloisng?)
		foreach (AnimationState state in anim) {

			state.speed = 0.5F;

		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate ()
	{



	}

}
