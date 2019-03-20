using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using ChartboostSDK;

public class PlayerController : MonoBehaviour {

	// prefab that holds our FIRST TEST BULLET
	public GameObject theBullet;
	public Bullet bulletPrefab;

    public float bulletSpeed;
    public float firingRate = 0.2f;

	// prefab that holds our FIRST TEST EXPLOSIVE
	public GameObject theExplosive;
	public Explosive explosivePrefab;

	// TESTING ALREADY CREATED "EXPLOSION" CLASS??
	public GameObject theExplosive2;
	//public Explosion expolosionPrefab;

	// prefab that holds our FIRST TEST MELEE
	public GameObject theMelee;
	public Melee meleePrefab;

	// boolean for firing gun
	public bool safetyOn = true;

	public bool isSheathed = true;

	// START WITH A 100 BULLET ARGGH
	public int ammoCount = 100;

	// STAR WITH 100 COVFEFE MAGIC
	public int manaCount = 100;

	// START WITH 100% DURABILITY IF MELEE NOOB
	public int wepDurability = 100;

	// int variable that holds the type of weapon the user has
	// 1 = Bullets
	// 2 = Explosives
	// 3 = Melee
	public int currentStyle = 1;

	// vector3 position of where PLAYER WILL move to (get to shooting range)
	public Vector3 teleportPoint;

	// RIGIDBODY attached to this script
	public Rigidbody rb;

	/// GAME OBJECT FOR CAR/BLIMP???
	/// 
	/// 
	/// 
	/// 

	public GameObject carGameObject;
	public GameObject blimpGameObject;

	// used to measure distance between car & player
	public Vector3 carDistance;

	public bool withinCarDistance = false;
	public bool withinBlimpDistance = false;

	/// <summary>
	/// AUDIO CLIP & LOCATIONS ETC
	/// </summary>

	public AudioClip drawGun;
	public AudioClip reloadGun;

	// GameObject assigned thru insepector that holds position PROJECTILES will fire from
	public GameObject fireLocation;

	// **public vector3 variable to have the most updated location on gun position for spawning bullet***
	public Vector3 fireLocationPosition;

	// **GENERAL** position that ammo/etc will be fire towards (nothing a direct hit)
	private Vector3 targetPos;

	// sets thrust that object(s) will initially be fired/launched at
	public float initialThrust; // dont think used

	// UPWARD THRUST (how much player moves on each jump)
	public float upwardThrust = 15.0F; // dont think used??

	// thrust of the FIRST weapon plump owns
	public float primaryThrust = 750.0f;

	// variable to hold Transform that holds actual TOGGLE BUTTON (UI)
	public Transform toggleObject;

	// variable to hold Transform that holds text UI (inspector aSSIGNED)
	public Transform toggleTextVar;

	// variable used to change string of TOGGLE DESCRIPTIN UI
	public Text toggleText;

    // TEXT UI variable to hold string
    public Text scoreText;

	// TEXT UI variable to hold string?
	public Text ammoText;

	// TEXT UI variable to hold string?
	public Text magicText;

	// ** TESTING???**
	public Canvas InventoryTest;

	// Transform variables that hold the GUI joysticks
	Transform theLeftJoystick;
	Transform theRightJoystick;

	// PlayerGUI script held in a variable
	PlayerGUI thePlayerGUI;

    // BlimpGUI script held in a variable
    BlimpGUI theBlimpGUI;

    // CarGUI script held in a variable
    //CarGUI theCarGUI;

	// the JOYSTICK CONTROLLER script (need to get/set through children)
	PlayerMoveController thePlayerMoveControoler;

	// variable that holds actual player hands (that will be activated/deactivated)
	public GameObject childPlayerModel;

	// used to get the CarControllerScript
	public Transform CarControllerObj;

	// bool to determine when to cut off/change controls to "vehicle"/car controller
	public bool isInGolfCart = false;

	public Transform BlimpControllerObj;

	// bool determine when to cut off/change controls to vehicle/car controller
	public bool isInBlimp = false;

	// variable that will hold the references to the target script (VehicleController)
	//CarController theCarController;

	// GameController script held in a variable
	public GameController theGameController;

	// private bool to determine if we have set GameController (and to stop checking if so)
	bool gameControllerSet = false;

    // BOOL VALUES TO DETERMINE STATE OF PLAYER
    public bool isFiring = false;
    public bool isJumping = false;

    ///// SOUND BITS SECTION

        // assigned in inspector
    public AudioSource gunCock;

	// variables that are sound bit files etc
	AudioSource dateIvanka;
	AudioSource gbp;
	AudioSource hmm_thats_strange;
	AudioSource mexico;
	AudioSource mexico_pays;
	AudioSource thankyou_darling;
	AudioSource maga;

	//GameObject gameControllerObj;

	// Experience script held in a variable
	//Experience playerExperience;

	/////////////////////////////////////////////////////////////////////////////////////////
	// DONT NEED EXPERIENCE VARIABLE ETC... CAN JUST CALL FUNCTION THRU GAME MANAGER SCRIPT
	/////////////////////////////////////////////////////////////////////////////////////////

	// will get/set and make child of this player controller
	public Transform joystickObject;

	/// <summary>
	///  TESTING FIRING TRANSFORM UI OBJECT
	/// </summary>

	// ASSIGNED IN INESPECTOR*** 
	public Text theTestFiringText;

	// Use this for pre-initialization
	void Awake () 
	{

		// get /set before player is loaded (THROUGH PARENT)
		//theGameController = transform.GetComponentInParent<GameController>();
		//theGameController = GameObject.FindWithTag ("GameController").GetComponent<GameController> ();

		// get/set to attach joystick 
		thePlayerMoveControoler = transform.GetComponent<PlayerMoveController> ();

		// get & set GAMEOBJECT thru CHILD by specifying the GameObject with Animator Component
		childPlayerModel = transform.GetComponentInChildren<Animator> ().gameObject;

		//theGameController = 

		// get/set the PlayerGUI script thu finding GameObject by name (string)
		thePlayerGUI = GameObject.Find ("CanvasPlayerGUI").GetComponent<PlayerGUI> ();

        ////
        // ** WILL COMNE BACK TO THIS... need to creeate objects (getting error meow)

        /*
        theBlimpGUI = GameObject.Find("CanvasBlimpGUI").GetComponent<BlimpGUI>();

        theCarGUI = GameObject.Find("CanvasCarGUI").GetComponent<CarGUI>();
        */

        /////

		// find and get/set GameController GameObject
		//gameControllerObj = GameObject.Find ("GameController");

		// set GameController as parent (OF THIS TRANSFORM)?
		//transform.parent = theGameController.transform;

		// get and set thru parent
		///////currentStyle = theGameController.currentStyle;

		// get and set
		bulletPrefab = theBullet.GetComponent<Bullet> ();


		// get / set variable
		toggleText = toggleTextVar.GetComponent<Text> ();

        // get / set AUDIO SOURCE
        gunCock = transform.GetComponent<AudioSource>();

		// JUST TO MAKE SURE
		primaryThrust = 25.0f;

	}

	// Use this for initialization
	void Start () 
	{

		// get & set rigidbody
		rb = GetComponent<Rigidbody> ();

		// get & set **early on**
		carGameObject = GameObject.FindGameObjectWithTag ("GolfCart");

		// get & set blimpGameObject as well
		blimpGameObject = GameObject.FindGameObjectWithTag ("Blimp");

		// get & set CAR CONTROLLER (standard asset)
		//theCarController = carGameObject.GetComponent<CarController> ();


        //safetyOn = false;
        //isSheathed = false;

        // get/ set Audio Source from GUN COCK and play!
        AudioSource gunCockAudio = gunCock;
        gunCockAudio.Play();



		//

        ///
        // get & set "EnemySpawner" in GameController (parent class)
        ///theGameController.theEnemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        ///

		// try...
		try 
		{

			// *GET* EXP!!!
			//theGameController.playerExperience.GainExp(100);
			//Debug.Log("--> GAINED 100 EXP!");

			/*
			// get and set experience system for PLAYER through parent
			//playerExperience = theGameController.GetComponent<Experience> ();
			playerExperience = theGameController.getPlayerExperience();
			//playerExperience = gameControllerObj.GetComponent<Experience>();

			theGameController.playerExperience.GainExp
			*/

			//thePlayerMoveControoler.leftController = theLeftJoystick;
			//thePlayerMoveControoler.rightController = theRightJoystick;

			
		} 
		catch (Exception ex) 
		{

			// debug shit
			Debug.Log ("error MESSAGE: " + ex.Message.ToString ());
			Debug.Log ("error SOURCE: " + ex.Source.ToString ());
			Debug.Log ("error INNER EXCEPTION: " + ex.InnerException.ToString ());
			Debug.Log ("error INNER HELP-LINK: " + ex.HelpLink.ToString ());
			
		}
		finally 
		{


			Debug.Log ("------>");


		}

		
	}

    // CALLED THRU ****PLAYERGUI**** SCRIPT
    public void Jump()
    {

		if (manaCount > 0) 
		{

			// USED TO BE EXLUDED FROM IF STATEMENT
			// CHANGED 07/27/2018**

			// add 10 to the Y?
			rb.velocity = new Vector3 (0, 10f, 0);

			// subtract 10???
			manaCount = manaCount - 10;

			// UPDATE TEXT UI VAR
			magicText.text = "COVFEFE: " + manaCount.ToString ();

			// SET TO FALSE SO THAT IT STOPS JUMPING!!
			isJumping = false;

		} 
		else if (manaCount <= 0) 
		{

			// fresh out boi
			manaCount = 0;

		}

        

    }

    // CALLED THRU ****PLAYERGUI***** SCRIPT
	/// <summary>
	/// FIRE FIRE FIRE FIRE 
	/// </summary>
    public void Fire()
    {

		// **** SET THRUST / AMMOBDETAILS DEPENDING ON WESPON

		// ACTIVATE TEST TEXT TO SSHOW WE ARE FIRING!?!?!?
		//theTestFiringText.transform.gameObject.SetActive (true);

		// IF THERE IS STILL AN AMMO COUNT (greater than 0)
		if (ammoCount > 0) 
		{

			// UPDATE FIRE LOCATION TO CURRENT GUN POSITION
			fireLocationPosition = fireLocation.transform.position; // 7/24/2018 --> re included

			// 03/27/2018 --> used to use "fireLocation.transform.position" as position
			GameObject clone = Instantiate (theBullet, fireLocationPosition, Quaternion.identity) as GameObject;

			// setup??
			//Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, otherObject.transform.eulerAngles.y, transform.eulerAngles.z);
			Vector3 eulerRotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, fireLocation.transform.eulerAngles.z);

			// MAKE SURE FACING IN CORRECT DIRECTION
			fireLocation.transform.rotation = Quaternion.Euler(eulerRotation);

			// 03/29/2018 --> USED TO PUSH RIGIDBODY IN BULLET SCRIPT... now here
			// 07/20/2018 --> moving back to bullet script because AddForce function has to be in FixedUpdate FUCKING DUMBASSS!!
			// 07/24/2018 --> moving BACK FOR THE LASG FUCKING TIME


			// GET & SET RIGIDBODY OF BULLET TO VARIABLE
			Rigidbody cloneRB = clone.GetComponent<Rigidbody> ();

			// APPLY FORCE TO THAT VARIABLE!!
			// (by using transform attached to GameObject that is assigned in inspector in this script)
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);

			// x2 to make that shit STRONGAH
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);

			// 08/12/2018 --> ADDED MOAR POWAH!!!
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);

			// 08/12/2018 --> ADDED 2 MORE YALL
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);

			// 08/15/2018
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);
			cloneRB.AddForce (fireLocation.transform.forward * primaryThrust);


			//////////////////////////////////////////////////////

			// subtract ammo from count
			ammoCount--;

			// make that babh shake!!
			Handheld.Vibrate();

			// UPDATE TEXT UI VAR
			ammoText.text = "Bullets: " + ammoCount.ToString ();

			// set to FALSE so that it stops firing?? 03/12/18
			isFiring = false;

			// ** REMOVED ** 07/25/2018
			// RE-ACTIVATE TEST TEXT TO SSHOW WE ARE FIRING!?!?!?
			//theTestFiringText.transform.gameObject.SetActive (true);

		} 
		// ELSE IF THE AMMO COUNT ACCIDENTLY SLIPPED NEGATIVE (below zero)
		else if (ammoCount <= 0) 
		{

			// reset to zero
			ammoCount = 0;

			// UPDATE TEXT UI VAR
			ammoText.text = "Bullets: " + ammoCount.ToString ();

			isFiring = false;

			// ** REMOVED ** 07/25/2018
			// DE-ACTIVATE TEST TEXT TO SSHOW WE ARE NOW NOT FIRING!?!?!?
			//theTestFiringText.transform.gameObject.SetActive (false);

		}
        else
        {

            Debug.Log("NOT EVEN AMMO NOOOOB!");

			isFiring = false;

			// DE-ACTIVATE TEST TEXT TO SSHOW WE ARE NOW NOT FIRING!?!?!?
			theTestFiringText.transform.gameObject.SetActive (false);

        }


    }

	public void CastSpell()
	{



		// old shit wuz here

	}
	
	// Update is called once per frame
	void Update () 
	{

		// constantly check distance to nearest CAR & BLIMP
		//carDistance = Vector3.Distance(carGameObject, gameObject);

		// CONSTANTLY update distances between player & vehicles
		float carDist = Vector3.Distance (carGameObject.transform.position, gameObject.transform.position);
		float blimpDist = Vector3.Distance (blimpGameObject.transform.position, gameObject.transform.position);

		// IF WITHIN DISTANCE OF CAR
		if (carDist <= 10.0f) 
		{

			// change bool
			withinCarDistance = true;

			// SET UI TO ACTIVE!!!

			// set p[layer controller to inactive & the car cnotroller to ACTIVE

			///theCarController.gameObject.SetActive (true);


			// DISABLE THIS GAMEOBEJCT / TRANSFORM / SCRIPT (FOR MEOW)
			// ^^^ DISABLE PLAYER GAMEOBJECT BUT NOT SCRIPT

			// *** TEST ***
			Destroy (gameObject);

		} 
		// ELSE IF... within distance of BLIMP
		else if (blimpDist <= 10.0f) 
		{

			// set to false
			withinBlimpDistance = true;

			// SET UI TO ACTIVE!!!

			// set p[layer controller to inactive & the blimp cnotroller to ACTIVE

		} 
		// ELSE...
		else 
		{

			withinCarDistance = false;
			withinBlimpDistance = false;

		}



		//////////////////////////////////////////////////////////////////
		// make sure fireLocationPosition is up to date!!
		fireLocationPosition = fireLocation.transform.position;

		// THE BELOW CODE HAS BEEN MOVED/COPIED TO THE FixedUpdate() FUNCTION! 
		/*
        if (isFiring)
        {

            // **** INVOKE FIRE FUNCTION ONLY AT SPECIFIC (DESIRED) FIRE RATE
            InvokeRepeating("Fire", 0.000001f, firingRate);

        }
        else
        {

            // CANCEL INVOKE ie make sure CALLED ONCE**
            CancelInvoke("Fire");

        }
		*/

		// if GAMECONTROLLER **NOT SET** YET...
		if (!gameControllerSet) 
		{

			// ALSO **IF** GameController EXISTS meow
			if (GameObject.FindGameObjectWithTag ("GameController")) 
			{

				// get & set...
				theGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();

				gameControllerSet = true;

			}

		}

		// constantly update bool IS SAFETY ON!?!?!??!?!?
		safetyOn = thePlayerGUI.isSafetyOn;

		// whenever TEST USER HITS THE "F KEY"
		if (Input.GetKeyUp(KeyCode.F))
		{

			// if he has ammo left (more than none)
			if (ammoCount > 0) 
			{

				// subtract from ammo count
				ammoCount--;

				//targetPos = GetComponent<Collider>().transform.position;
				initialThrust = 5.0f; // test thurst?

				// create temp POS before spawning "clone" in
				Vector3 clonePos = new Vector3(fireLocation.transform.position.x, fireLocation.transform.position.y + 50, fireLocation.transform.position.z + 50);

				// USED TO USE "fireLocation.transform.position" for POS
				Bullet clone = (Bullet)Instantiate (bulletPrefab, clonePos, fireLocation.transform.rotation);

				// AUTOMATICALLY ENSLAVE AND MAKE CHILD PARENT OF BULLET
				clone.transform.parent = this.transform;

			}


		}



		// UPDATE TOGGLE TEXT UI STRING
		toggleText.text = "TOGGLE: " + toggleTextVar.transform.gameObject.active.ToString();

		// CHANGED 02/10/2017
		/*
		// if SAFETY NOT ON **or** melee weapon NOT SHEARTHED (has to be one or other)
		if (!safetyOn || !isSheathed) 
		{

			Debug.Log ("FIRING AWAY!?!?!???");

			// create local variable to hold the touch of one finger (one finger that hit the Floor, etc)
			Touch touch = Input.GetTouch(0);

			// raycast hit STRUCT
			RaycastHit hit;

			// construct a ray from the current touch / gun coordinates?
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

			if (Physics.Raycast (ray, out hit, 100)) 
			{

				// the bad touch
				Collider coll = hit.collider;

				///////////////////////////////////////////////
				// if current weapon is GUN/BULLETS (int of 1)
				///////////////////////////////////////////////
				if (currentStyle == 1 && ammoCount > 0) 
				{

					//////////////////////////////////
					// INSTANTIATE FIRE SOUND ??? 
					/////////////////////////////////

					// if the raycast collided 
					if (coll.name == "Mexican" || coll.name == "ISIS" || coll.name == "Enemy1")
					{

						// subtract bullet from count
						ammoCount--;

						// MUST ASSIGN "TARGET" POS BEFORE BULLET IS INSTANTIATED
						targetPos = coll.transform.position;
						initialThrust = 5.0f; // test thrust?

						Bullet clone = (Bullet)Instantiate (bulletPrefab, fireLocation.transform.position, fireLocation.transform.rotation);

						// AUTOMATICALLY ENSLAVE AND MAKE CHILD PARENT OF BULLET
						clone.transform.parent = this.transform;

					} 
					// was comparing coll.name *NOW* comparing .tag
					else if (coll.tag == "Weapon1" || coll.tag == "Hands" || coll.tag == "Scope")
					{

						// SWITCH WEAPON!>?!?!


					}
					else if (coll.tag == "GolfCart") 
					{

						// create local variable that is distance between THIS GAMEOBJECT and the GOLF CART
						float dist = Vector3.Distance(coll.transform.position, transform.position);

						if (dist <= 5f) 
						{

							// set IS IN VEHICLE to *TRUE*
							theGameController.isInVehicle = true;

						} 
						else
						{

							/// ELSE... set to false
							theGameController.isInVehicle = false;

						}


					}


				} 
				///////////////////////////////////////////////
				// if current weapon is BOMBS/EXPLOSIVES (int of 2)
				///////////////////////////////////////////////
				else if (currentStyle == 2 && ammoCount > 0) 
				{

					//////////////////////////////////
					// INSTANTIATE BOMB SOUND ??? 
					/////////////////////////////////

					// subtract the ammoucount 

				} 
				///////////////////////////////////////////////
				// if current weapon is FISTS/MELEE (int of 3)
				///////////////////////////////////////////////
				else if (currentStyle == 3 && isSheathed) 
				{

					//////////////////////////////////
					// INSTANTIATE PUNCH/GRUNT SOUND ??? 
					/////////////////////////////////

				}

			}

		}
		*/

		// WHENEVER YOU NEED EXP
		//playerExperience.GainExp(100);

		
	}

	// CALLED IN "FIXED" TIME INCREMENETS SPECIFIC TO UNITY'S GAME ENGINE!
	// JUMPING: CHECK
	// FIRING: FAIL
	//
	void FixedUpdate ()
	{

        if (isJumping)
        {

            // **** INVOKE JUMP FUNCTION ONLY AT SPECIFIC (DESIRED) FIRE RATE
            InvokeRepeating("Jump", 0.000001f, firingRate);

        }
        else
        {

            // CANCEL INVOKE ie make sure CALLED ONCE**
            CancelInvoke("Jump");

        }


		// IS FIRING!?!?!?
		///////////////////
		if (isFiring)
		{

			// **** INVOKE FIRE FUNCTION ONLY AT SPECIFIC (DESIRED) FIRE RATE
			InvokeRepeating("Fire", 0.000001f, firingRate);

		}
		else
		{

			// CANCEL INVOKE ie make sure CALLED ONCE**
			CancelInvoke("Fire");

		}

	}

}
