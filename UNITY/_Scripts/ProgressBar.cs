using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

	Renderer theRenderer;

	// Use this for pre-initalization
	void Awake ()
	{

		// get set reneerer variable
		theRenderer = transform.GetComponent<Renderer> ();

	}

	// Use this for initialization
	void Start () 
	{


		
	}
	
	// Update is called once per frame
	void Update () 
	{

		float revealOffset = (float)(Time.timeSinceLevelLoad % 10) / 10.1F; 

		gameObject.GetComponent<Renderer>().material.SetFloat ("_Cutoff", revealOffset);
		
	}

}
