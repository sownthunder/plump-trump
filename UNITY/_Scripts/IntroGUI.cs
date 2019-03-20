using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartboostSDK;


[RequireComponent(typeof(AudioSource))]
public class IntroGUI : MonoBehaviour {

	public GUIStyle debugGUIStyle;

	// int variables that hold the width and height of the user's device 
	// (because each device varies)
	public int screenWidth;
	public int screenHeight;

	// public variable (thru inspector) to hold Transform oBject
	public Transform handsTransform;

	// variable to hold UI object
	Slider theSlider;

	public Slider mainSlider;

	// bool variable that detemrines whether the user has pressed a button to 
	// either exit the main menu to another menu or begin a level in game
	// (starts off true because the app starts in main menu when booted up)
	private bool mainMenu = true;

	// GAMEOBJECT ASSIGNED IN INSPECTATOR OF TRUMPSY HANDS
	public GameObject theHands;

	// Gameobject variable to hold statue that will rotate around in background
	public GameObject theStatue;

	//////////////////////////////////////////
	///  MUSIC SHIT/
	/// 

	// AUDIO RENDERER?

	// ASSIGNED IN INSPECTOR
	public AudioSource introMusic;
	//public AudioClip introuMusic2;

	public AudioClip ButtonSelect;

	// GameController script held in a variable
	GameController theGameController;

	// Use this for pre-initialization
	void Awake () 
	{

		// if no GameController (null)
		if (!GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ()) {

			Destroy (gameObject);

		} else {

			// get and set before level/GAME loads...
			theGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		}

		// get / set AUDIO SOURCE
		introMusic = gameObject.GetComponent<AudioSource> ();

		/*
		// TRY BLOCK YO
		try
		{

			// get and set before level/GAME loads...
			theGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();

		}

		catch (Exception) 
		{

			Debug.Log ("**** ERROR! *****");


		}
		finally 
		{



		}
		*/

		// get and set before level/GAME loads...
		//theGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();




	}

	// Use this for initialization
	void Start () 
	{

		//theSlider = mainSlider = 

		// get/ set Audio Source from HELL MUSIC and play!
		//AudioSource introAudio = GetComponent<AudioSource> ();
		AudioSource introAudio = introMusic;
		introAudio.Play ();
		introAudio.Play (44100);

		//Displays the value of the slider in the console.
		Debug.Log(mainSlider.value);

	}
	
	// Update is called once per frame
	void Update () 
	{

		//Displays the value of the slider in the console.
		Debug.Log(mainSlider.value);

		// UPDATE TRUMPS HANDS DEPENDINGO ON WHERE SLIDER IS !!!

		// shorten the object by 0.1
		///theHands.transform.localScale -= new Vector3(0.1F, 0, 0);

		// make the hands "bigger" (LOLZ)
		///theHands.transform.localScale -= new Vector3(0.1F, 0,0);
		// ^^ RE PUT IN WITH SLIDER ADJUSTMENTS

		// rotates 30 degress per second around x axis
		theStatue.transform.Rotate (0, 30 * Time.deltaTime, 0);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	// 07/25/2018 ---. LONE WOLFFF (school**)
	public void LoadBowlingGreen()
	{

		// make that baby shake
		//Handheld.Vibrate();

		// WAS 2

        // 3/6/2018 BOWLING GREEN WAS REPLACED WITH SCHOOL SHOOTING!!! ALTERNATIVE FACTS YALL!

		Application.LoadLevel (10);


	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadBuildThatWall()
	{

		// make that baby shake
		//Handheld.Vibrate();

		// ** PLAY SOUND

		// WAS ORIGINALLY 2 (TWO)
		// THEN 9 (NINE)
		Application.LoadLevel (8);


	}
	// ** OLD WEE BUTTON* (08/03/2018)
	// NOW IS "MARKETPLACE" BUTTON
	public void LoadMarket()
	{

		// 08/03/2018 --> was 4
		Application.LoadLevel (3);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadFakeNews()
	{

        Application.OpenURL("https://twitter.com/realDonaldTrump");


		//Application.LoadLevel (3);


	}

	public void LoadNorthKorea()
	{

		// 07/05/2018 --> was 5
		//Application.LoadLevel (5);
		// 07/25/2018 --> was 8
		Application.LoadLevel (6);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadMaraLago()
	{

		// was 5
		// 07/25/2018 --> was 6
		Application.LoadLevel (11);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadWhiteHouse()
	{

		// was 5
		// 07/25/2018 --> then 2
		Application.LoadLevel (9);

	}

	/*
	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadTestScene1()
	{

		Application.LoadLevel (4);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadTestScene2()
	{

		Application.LoadLevel (8);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadTestScene3()
	{

		// LOAD WHITE HOUSE SCENE YALL!!
		Application.LoadLevel (2);

	}
	*/


	// ** THE NEW WWE BUTTON **
	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadControls()
	{

		// WAS 10 PREVIOUSLY**
		// 07/25/2018 --> was 7
		Application.LoadLevel (4);

	}

	// FUNCTION CALLED WHEN BUTTON IS PRESSED
	public void LoadTutorial()
	{

		// LOAD TUTORIAL "ISLAND" (the secutriy 3rd person room meow)
		// 07/25/2018 --> was 1
		Application.LoadLevel (7);

	}

	/*
	// FUNCTION CALLED WHEN BUTTON IS PRSSED
	public void LoadTestSceneRandom()
	{

		// set random integer to *ANY* above the previous buttons
		int random = Random.Range (4, 11);

		Application.LoadLevel (random);

	}
	*/

}
