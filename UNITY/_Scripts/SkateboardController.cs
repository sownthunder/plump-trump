using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkateboardController : MonoBehaviour {

	// get and set ANIMATOR component attached to rigidbody and set the runtimeanimator with variables below
	public Animator theAnimtor;

	// ASSIGNED THRU INSPECTOR
	public RuntimeAnimatorController skateDuckUnder;
	public RuntimeAnimatorController skateGoForward;
	public RuntimeAnimatorController skateLeanTurnRight;
	public RuntimeAnimatorController skatePumpJump;
	public RuntimeAnimatorController skatePushTurnLeft1;
	public RuntimeAnimatorController skatePushTurnLeft2;
	public RuntimeAnimatorController skatePushTurnRight1;
	public RuntimeAnimatorController skatePushTurnRight2;
	public RuntimeAnimatorController skateStart;
	public RuntimeAnimatorController skateStop1;
	public RuntimeAnimatorController skateStop2;
	public RuntimeAnimatorController skateStop3;
	public RuntimeAnimatorController skateLeanTurnLeft;

	// get RIGIDBODY of SKATEBOARD

	// Use this for initialization
	void Start () 
	{

		// get and set ANIAMTOR component
		theAnimtor = transform.GetComponent<Animator> ();


		
	}
	
	// Update is called once per frame
	void Update () 
	{




	}

	public void StartButton()
	{

		// play "start skating" animation"
		theAnimtor.runtimeAnimatorController = skateStart;

	}

	public void LeanTurnLeft()
	{

		// play lean left animation
		theAnimtor.runtimeAnimatorController = skateLeanTurnLeft;

	}


}
