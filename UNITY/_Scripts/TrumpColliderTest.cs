using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TrumpColliderTest : MonoBehaviour {

	//In this example, the name of the GameObject that collides with your GameObject is output to the console. Then this checks the name of the Collider and if it matches with the one you specify, it outputs another message.

	//Create a GameObject and make sure it has a Collider component. Attach this script to it.
	//Create a second GameObject with a Collider and place it on top of the other GameObject to output that there was a collision. You can add movement to the GameObject to test more.

    public GameController theGameControllerScript;
    
	public Collider theBoxCollider;

	// variable to hold TRANSFORM OF CANVAS
	// ** ASSIGNED IN INSPECTOR ***
	//public Transform CanvasButtonGUI;

	// GAMEOBEJCT HELD TO CHECK DISTANCE OF PLAYER (assigned in inspector)
	public GameObject theSecurityDoor;

	// GAMEOBJECT HELD TO CHECK DISTANCE BETWEEN PLAYER (assigned in inspecector)
	public GameObject theTrumpPlayer;

    // THIZ IS GOING TO BE ATTACHED TO TRUMP PLAYER GAME OBJEVT

    // WHEN THIS SCRIPT DETECTS THR GAMEOBJECT FOR "EXIT", 
    // **** IT WILL FORCE SCENE CHANGE THRU FUNCTION IN GAMECONTROLLER SCRIPT  
    // ^^ (which is called in this script)

	// ** ASSIGNED IN INSPECTOR **
	public Canvas theCanvasButtonGUI;

	// BUTTON TYPE (UI) GOT THRU ABOVE
	Button theCanvasButton;

	void Awake ()
	{

		theBoxCollider = transform.GetComponent<Collider> ();

		// get & set
		theGameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();



	}

	// Use this for initialization
	void Start ()
	{

         // SET CANVAS BUTTON GUI TO FALSE SO IT HAS TO BE ACTIVATED
		//CanvasButtonGUI.gameObject.SetActive(false);

		/*
		// SET CANVAS OBJECT TO FALSE AT START
		theCanvasButtonGUI.transform.gameObject.SetActive (false);
		*/

		// get & set ** AFTER ** the scene has started (and variable is assigned thru inspector)
		theCanvasButton = theCanvasButtonGUI.GetComponentInChildren<Button> ();



		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// debug log
		//Debug.Log(Vector3.Distance (theSecurityDoor.transform.position, transform.position).ToString);

		/*
		// if game controller not yet set
		if (theGameControllerScript == null) 
		{

			theGameControllerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

		}
		*/

		// DISTANCE FROM DOOR AND THIS PLAYER IS LESS THAN OR EQUAL TO 2 
		/////////////////////////////////////
		// WAS TRUMP PLAYER
		if (Vector3.Distance (theTrumpPlayer.transform.position, transform.position) <= 15)
		{


			theCanvasButtonGUI.transform.gameObject.SetActive (true);


		} 
		else 
		{



		}

	}


	void OnTriggerEnter(Collider other) 
	{

		Collider theCollider = other;

		Debug.Log (other.ToString());

		if (theCollider.transform.CompareTag("Player")) // was security door
		{

			// CALL FUNCTION IN THIS SCRIPT
			theGameControllerScript.ForceSceneChange2Security();

		}

	}

	/*
	void OnTriggerStay(Collider other)
	{

		Debug.Log (other.ToString());

		if (other.transform.CompareTag ("Player")) // was security door
		{


			// CALL FUNCTION IN THIS SRIPT
			theGameControllerScript.ForceSceneChange2Security();

		}

	}
	*/

	//If your GameObject starts to collide with another GameObject with a Collider
	void OnCollisionEnter(Collision collision)
	{
		//Output the Collider's GameObject's name
		Debug.Log(collision.collider.name);
	}

	//If your GameObject keeps colliding with another GameObject with a Collider, do something
	void OnCollisionStay(Collision collision)
	{
		//Check to see if the Collider's name is "Chest"
		if (collision.collider.name == "Trump")
		{
			//Output the message
			Debug.Log("Chest is here!");
		}
	}

	/*
	// CALLED SPECIFICALLY WHEN THE TRUMP **ADVENTURE** PLAYER ENTER "EXIT GAMEOBJECT"
	public void ForceSceneChange2Security ()
	{


		// application.load or whatevsr to make sure SECURITY SCENE IS LOADED
		// LEVEL == 
		Application.LoadLevel (2);


	}
	*/

	/*
	// CALLED SPECIFICALLY WHEN THE TRUMP **ADVENTURE** PLAYER ENTER "EXIT GAMEOBJECT"
	public void ForceSceneChange2Security ()
	{


		// application.load or whatevsr to make sure SECURITY SCENE IS LOADED
		// LEVEL == 
		Application.LoadLevel (2);


	}
	*/

}
