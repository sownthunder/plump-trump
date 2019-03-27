using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameTimer : MonoBehaviour {

	// GameTime rotates a directional light to match the appropriate 
	// direction of the sun for the system time of day. 

	// TODO: It doesn't change the length of the day for seasons nor 
	// the angle of the sun. It also doesn't turn off the light at night, as would be accurate. 

	public float gameTimer = 1;

	public DateTime theDate = DateTime.Now;

	GUIText timeDisplay; 

	// Use this for pre-initialization
	void Awake ()
	{



	}

	// Use this for initialization
	void Start () 
	{

		InvokeRepeating ("Increment", 1.0f, 1.0f);

	}
	
	// Update is called once per frame
	void Update () 
	{

		gameTimer = Time.time;

		float seconds = theDate.TimeOfDay.Ticks / 10000000;
		transform.rotation = Quaternion.LookRotation (Vector3.up);
		transform.rotation = Quaternion.AngleAxis (seconds / 86400 * 360, Vector3.down);
		if (timeDisplay)
			timeDisplay.text = theDate.ToString ("f");
		
	}

	void Increment ()
	{

		//theDate = theDate + TimeSpan (0f, 0f, 0f, 1f);

	}

	void FixedUpdate ()
	{



	}

}
