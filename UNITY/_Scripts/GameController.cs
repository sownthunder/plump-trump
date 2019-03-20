using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
//using ChartboostSDK;

public class GameController : MonoBehaviour {

	// GUIStyle to debug and test game shit
	public GUIStyle debugGUIStyle;

	// score of the player that will (hopefully) increase while playing the game
	public float playerScore = 0;

	// variable to hold GameObject of player (spawning in through levels?)
	public GameObject thePlayer;

	// script variable that holds the controller to the player character
	public PlayerController playerPrefab;
	//public PlayerController thePlayerController;

	//public Experience playerExperience;

	// scipt variable that holds the controller to the Enemy Generator
	public EnemySpawner theEnemySpawner;

	// script variable that holds the controller to DoorsController
	public DoorsController theDoorsController;

	// determines if player has been place sin the world or not (starts false)
	private bool playerSet = false;

	// SAME AS ABOVE
	private bool enemySpawnerSet = false;

	// bools to determine the "state" player is in 
	public bool isInVehicle = false;
	public bool isInTank = false;
	public bool isInSky = false;

	// int variable that holds the type of weapon the user has
	// 1 = Bullets
	// 2 = Explosives
	// 3 = Melee
	public int currentStyle = 1;

	// GAME TIMER PREFAB OBJECT ( assigned in inspector)
	public GameObject theGameTimer;

	// found in game world, first spawner is for BUILD THAT WALL!
	GameObject thePlayerSpawn1;

	///// SOUND BITS SECTION

	// variables that are sound bit files etc
	AudioSource SFX_Button_Click;
	/*
	AudioSource SFX_Button_Back;
	AudioSource hmm_thats_strange;
	AudioSource mexico;
	AudioSource mexico_pays;
	AudioSource thankyou_darling;
	AudioSource maga;
	*/

	// soundtrack file(s)
	public AudioClip SoundTrack_level1;
	public AudioClip SoundTrack_level2;
	public AudioClip SoundTrack_level3;
	public AudioClip SoundTrack_level4;
	public AudioClip SoundTrack_level5;

	// ASSIGNED IN INSPECTOR
	public AudioSource testMusic1;

	// public transform to hold PERSISTANT-CANVAS for active/deactive
	public Transform persistantCanvasObject;

	// Use this for pre-iniitialization
	void Awake ()
	{

		////////////////////////////////////////////////////
		/// aTTEMPT 2


		// make this object indestructable :)
		DontDestroyOnLoad (transform.gameObject);


		////////////////////////////////////////////////////
		/// aTTEMPT 1

		// debug shit
		Debug.Log ("<--- ATTEMPTING **IF STATEMENT** SOLUTION(S) --->");



		/*
		// contintue while finding GAMECONTROLLER == true?
		if (GameObject.FindWithTag ("GameController")) 
		{

			// ** TEST* create variable that holds newly found object
			GameObject testObject = GameObject.Find("GameCoontroller");

			// debug shit
			Debug.Log ("<--- *IF* === yes *FINDING* GAMECONTROLLER --->");

			Debug.Log ("<--- DESTROY OBJECT (GameController) BEFORE IT SPAWNS --->");

			// delete **THAT** GameObject
			Destroy (testObject);

			// delete this one
			//Destroy (gameObject);

		}
		else 
		{

			// make this object indestructable :)
			DontDestroyOnLoad (transform.gameObject);

		}
		*/

		// get/ set?
		SFX_Button_Click = gameObject.GetComponent<AudioSource> ();

		////////////////////////////////////////////////////
		/// aTTEMPT 2

		/*
		// debug shit
		Debug.Log ("<--- ATTEMPTING TO CHECK FOR OTHER GAME MANAGER(S) --->");

		// FOR loop and check **TWICE**
		for (int i = 0; i < 2; i++) {

			// IF ANOTHER COPY IS FOUND
			if (GameObject.FindWithTag ("GameController") != null) 
			{

				Debug.Log ("<--- DESTROY OBJECT (GameController) BEFORE IT SPAWNS --->");

				// delete this one
				Destroy(gameObject);



			} 
			// nothing else is found (**this is first instance)
			else 
			{

				Debug.Log ("<-!- NO OTHER (GameController) FOUND -!->");
				Debug.Log ("<-!- ^^ set to 'invincible' ^^ -!->");

				// make this object indestructable :)
				DontDestroyOnLoad (transform.gameObject);

			}


		}
		*/

		///DontDestroyOnLoad (transform.gameObject);

		// get and set Experience System
		//playerExperience = transform.GetComponent<Experience> ();
		//playerExperience = gameObject.GetComponent<Experience> ();

		//
		// THE PLAYER GAMEOBJECT WILL HAVE TO BE MOVED OUT OF THE AWAKE FUNCTION
		//

		/*
		 * 
		 * 
		 * 
		 * 
			 GameTimer clone = (GameTimer)Instantiate(gameTimerPrefab,origin, 0 rotation);

			clone.transform.parent = this.transform;


		// originally ended here <---

		// Show interstitial at location HomeScreen. 
		// See Chartboost.cs for available location options.
		Chartboost.showInterstitial(CBLocation.HomeScreen);
		*/

		// FOR PAYMENTS AND SHIT!
		//Chartboost.showRewardedVideo

	}

	// Use this for initialization
	void Start () 
	{

		/*
		if (!GameObject.FindWithTag ("GameController")) 
		{

			// make this object indestructable :)
			DontDestroyOnLoad (transform.gameObject);

		}
		*/

		/*
		// if the player GameObject has not yet been set
		if (thePlayer == null) {

			// get and set variable that holds PLAYER class
			thePlayerController = thePlayer.GetComponent<PlayerController> ();

		}
		*/

		// REMOVED 6/11/18
		/*
		// if INTRO GUI
		if (Application.loadedLevel == 0) 
		{

			// detroy this gameObject
			Destroy (gameObject);

		} 
		else 
		{

			// make this object indestructable :)
			DontDestroyOnLoad (transform.gameObject);

			// Show interstitial at location HomeScreen. 
			// See Chartboost.cs for available location options.
			//Chartboost.showInterstitial(CBLocation.HomeScreen);

		}
		*/
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		/*
		// CHECK IF PERSISTANT OBJECT IS OPEN THRU SPECIFIC SCENES
		// (great than or equal to 1)
		if (Application.loadedLevel >= 1)
		{


			// should only be having PERSISTANT "object"
			// active during the *adventure* scenes*

			// GET AND SET PERSISTANT CANVAS OBJECT

			// MAKE SURE IT IS ONLY ACTIVE DURING THE ADVENTURE LEVELS
			// DECATIVE DURING THE FPS LEVELS

		}
		*/

		if (Application.loadedLevel == 0) 
		{

			// force portrait for MENU
			Screen.orientation = ScreenOrientation.LandscapeLeft;

		} 
		else if (Application.loadedLevel == 1) 
		{


		} 
		// (FIRST LEVEL -- SECURITY ROOM)
		else if (Application.loadedLevel == 2) 
		{

			// force landscape left screen setup
			Screen.orientation = ScreenOrientation.LandscapeLeft;

		}
		// if FIRST level (now the second -- MARKET)
		// 6/11/18 --> WAS 1.. now 3
		else if (Application.loadedLevel == 3 || Application.loadedLevel == 9) 
		{

			// force landscape left screen setup
			Screen.orientation = ScreenOrientation.LandscapeLeft;

		}
		// if SECOND level --OR-- 11th lkevel
		// 6/11/18 --> WAS 2.. now 4
		// 7/25/18 --> now LEVEL 1
		// 08/12/2018 WAS 4 NOW JUST 11
		else if (Application.loadedLevel == 11) 
		{

			// get / set AUDIO SOURCE (test lvl 1)
			testMusic1 = gameObject.GetComponent<AudioSource> ();

			// force landscape left screen setup
			Screen.orientation = ScreenOrientation.LandscapeLeft;

			// if player not yet set
			if (!playerSet) {

				/*
				// get/set audio for THIS level 
				AudioSource introAudio = testMusic1;
				introAudio.Play ();
				introAudio.Play (44100);
				*/

				// get/ set player spawn object
				thePlayerSpawn1 = GameObject.FindGameObjectWithTag ("PlayerSpawn");

				// spawn player, AT POSITION OF "PLAYER SPAWN" OBJECT
				//Instantiate (thePlayer, thePlayerSpawn1.transform.position, Quaternion.identity);

				// get and set player (Player) controller script variable
				//thePlayerController = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
				// INSTANTIATE COPY / CLONE // 
				PlayerController playerClone = (PlayerController)Instantiate(playerPrefab, thePlayerSpawn1.transform.position, transform.rotation);

				// set PLAYER prefab to be child of this GameManager
				playerClone.transform.parent = this.transform;

				// get/set audio for THIS level 
				AudioSource introAudio = testMusic1;
				introAudio.Play ();
				introAudio.Play (44100);

				// set to true to stop loop(ing)
				playerSet = true;

			}
				

		} 
		// if **TEST** Mar a Lago Level
		else if (Application.loadedLevel == 3 || Application.loadedLevel == 5 || Application.loadedLevel == 7 || Application.loadedLevel == 8) 
		{

			// force portrait for shits & gigs
			Screen.orientation = ScreenOrientation.Landscape;

		}

		// endy?

	}


	// CALLED SPECIFICALLY WHEN THE TRUMP **ADVENTURE** PLAYER ENTER "EXIT GAMEOBJECT"
	public void ForceSceneChange2Security ()
	{


        // application.load or whatevsr to make sure SECURITY SCENE IS LOADED
		// LEVEL == 
		Application.LoadLevel (2);


	}


	// Called when UnityGameEngine feels like doing so
	void FixedUpdate ()
	{



	}

	// function to QUIT application
	public void QuitButton()
	{

		// quit this bitch
		Application.Quit ();

	}

	/*
	// function call to get/set private variable
	public Experience getPlayerExperience ()
	{

		// return function for public use
		return playerExperience;

	}
	*/

    public void GetChildCount()
    {

        // return number of children currently under GameManager

    }

}
