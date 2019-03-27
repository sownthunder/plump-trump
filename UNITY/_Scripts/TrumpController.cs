using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpController : MonoBehaviour {

	// transform attached to this script (to know when TrumpPanel is active)
	Transform theTransform;

	// holds the UI Panel
	public Transform trumpConvo;

	public Animator trumpAnimator;

	// GameController script held in a variable
	GameController theGameController;

	// GameObject variables that hold the animation types of TRUMP
	// ** GET THESE THROUGH CHILD CLASSES **
	public GameObject trumpIdle;
	public GameObject trumpWalk;
	public GameObject trumpTalk;

	// Use this for pre-initialization 
	void Awake ()
	{

		// get and set before level/GAME loads...
		theGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		// get and set?
		trumpAnimator = transform.GetComponent<Animator> ();

	}

	// Use this for initialization
	void Start () 
	{

		// PLAY ANIMATION AT START?
		trumpAnimator.Play("0");
		
	}
	
	// Update is called once per frame
	void Update () 
	{


		
	}

}
