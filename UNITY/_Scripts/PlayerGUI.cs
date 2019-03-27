using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartboostSDK;

public class PlayerGUI : MonoBehaviour {
    
	public GUIStyle debugGUIStyle;

	// transform attached to this script (to know when PlayerGUI is active)
	Transform theTransform;

	// UPWARD THRUST (how much player moves on each jump)
	public float upwardThrust = 150.0F;

    // int var that holds how long player must wait before being allowed to jump again
    public float jumpLock = 1.0F;

	// RIGIDBODY attached to this script
	public Rigidbody rb;

	// holds the INVENTORY panel
	// ASSIGNED IN INSPECTOR
	public Transform inventoryPanel;

	// bool to determine if above TRANSFORM is active
	public bool inventoryShowing = false;

	/*
	// holds the TOGGLE button for flipping safety on/off
	// ** ASSIGNED IN INSPECTOR **
	public Transform safetyToggle;

	// GAMEOBJECT HOLDING THE TWO (enabled/disabled) TOGGLE BUTTONS
	// GAMEOBJECT SO WE CAN CHECK IF ACTIVE OR NOT
	GameObject safetyToggleObj;
	*/

    // transform variable that holds the JUMP UI button
    public Transform jumpButtonObj;

    // UI Button variable that holds the UI BUTTON
    public Button theJumpButton;

	public bool isSafetyOn = true;

	// BOOLS
	////////////

	public bool isJumping = false;
    //public bool hasLanded = true;
	//public bool isFiring = false;

	// actual variable that is set/get through transform above
	//Toggle theSafetyToggle;

	// above (test)
	// ** ENABLED BUTTON
	Button theSafetyToggleButton;

	// is the inventory open?
	public bool isOpen;

	// ASSIGNED THROUGH INSPECTOR (displays playScore in new UI
	public Text scoreText;

	// ASSIGNED AS WELL THRU INSPECTOR
	public Text debtText;

	// ASSIGNED THRICELY THRU INSPECTOR
	//public Text ammoText;

	// holds player controller script (should be parent)
	public PlayerController thePlayerController;

	// PRIVATE variable that is set through PLAYER / PARENT
	private int ammoCount;

    // TRANSFORM ***ASSIGNED IN INSPECTOR*** so that the TEXT UI variable can be taken through this 
    //public Transform ammoCountObj;

    // ASSIGNED AS WELL THRU INSPECTION
    public Text ammoText;

    public GameObject projectile;
    public float projectileSpeed;
    public float firingRate = 0.2f;

	///// SOUND BITS SECTION
	/// ** THESE HAVE TO DO WITH ANYTHING REGARDING GUI

	// AUDIO CLIPS
	public AudioClip theEmptyAmmoSound;

	// variables that are sound bit files etc
	AudioSource SFX_Button_Click;
	AudioSource SFX_Inventory_Bringup;
	AudioSource SFX_Weapon_Switch;
	AudioSource SFX_Pickup_Item;
	AudioSource SFX_Pickup_Money;
	AudioSource SFX_Drop_Item;
	AudioSource SFX_Take_Damage;
	AudioSource SFX_Gain_Health;
	AudioSource SFX_Walk_Footsteps;
	AudioSource SFX_Crouch_Footsteps;

	// Use this for pre-initalization
	void Awake ()
	{

		// get & set... ALSO attached to this script
		thePlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        // GET AND SET PROJECT THROUGH PARENT CLASS??
        projectile = thePlayerController.theBullet;

        ///
        // get and set TRANSFORM for UI BUTTON
        ///jumpButtonObj = GameObject.FindWithTag("JumpButton").GetComponent<Transform>();
        ///

        //
		// set ammoCount to Private "in-house" variable
		//////ammoCount = thePlayerController.ammoCount;
        //

        // GET PLAYER SCORE VALUE FROM GAME MANAGER TO DISPLAY

        // GET PLAYER HEALTH (through parent component) TO DISPLAY

        // GET PLAY AMMO (through parent component) TO DSIPLAY

        ///safetyToggle = transform;

        /*
		// get set GAMEOBJECT
		safetyToggleObj = GameObject.Find ("Button_Enabled");

		// get/set safety toggle button UI
		theSafetyToggleButton = safetyToggle.GetComponentInChildren<Button> ();
		*/

        // REMOVE AFTER DONE TESTING
        upwardThrust = 150.0F;
        //hasLanded = true;
        jumpLock = 1;

        /// get & set button variable through transform object
        theJumpButton = jumpButtonObj.transform.GetComponent<Button>();

	}

	// Use this for initialization
	void Start ()
	{

		// get & set RIGIDBODY **thru** the PlayerController
		rb = thePlayerController.gameObject.GetComponent<Rigidbody> ();

		// get set "toggle text" to become TEST scoreText
		///scoreText = thePlayerController.toggleText.transform.GetComponent<Text> ();

		// samesies
		///debtText = thePlayerController.toggleText.transform.GetComponent<Text> ();

		// 02/09/2018 ==> CHANGED IT SO THEY GET COMPONENTS ** 
		// 02/09/2018 ==> CHANGED FROM AWAKE FUNCTION TO START FUNCTION

		
	}
	
	// Update is called once per frame
	void Update ()
	{

		// constantly update BULLET COUNTS !!
		ammoText.text = "Bullets: " + ammoCount.ToString();

        // if 'isJumping" is TRUE then deactive button WHILE it is..


        /*
        // ** TESTING JUMP COOLDOWN **
        if (isJumping)
        {

            /*
            jumpLock -= Time.deltaTime;
            if (jumpLock < 0 )
            {

                // ok they "have landed", and can jump again...
                //hasLanded = true;

            }


        }
        */

     

		/*
		// IF THE INVENTORY PANEL IS ACTIVE
		if (inventoryPanel.gameObject.active) 
		{


			// >> DECACTIVATE MOST OF GUI <<
			// ** test text for display **
			///scoreText.text = "INVENTORY == active";


		} 
		else 
		{

			// >> ACTIVATE MOST OF GUI <<
			// ** test text for display **
			///scoreText.text = "INVENTORY == inactive";

		}
		*/


		/*
		// if ENABLED obj button is *active*, then safety bool = true
		// was: safetyToggleObj
		if (theSafetyToggleButton.transform.gameObject.active) 
		{

			isSafetyOn = true;


		}
		// else set to false because the safety is off
		else 
		{

			isSafetyOn = false;

		}
		*/

	}

	void FixedUpdate ()
	{

		// if bool has just been set to true
		if (isJumping) 
		{

            // UPWARD THRUST!!
            //rb.AddForce(transform.up * upwardThrust);

            rb.velocity = new Vector3(0, 10, 0);

			// SET BOOL TO FALSE BECAUSE ACT IS **OVER**
			isJumping = false;

		}

        /*
		// if bool has just been set to true
		if (isFiring) 
		{

			// debug log
			Debug.Log ("FIRING IS FIRING LT DAN!");

            // instantiate "projectile" which is BULLET OBTIANED THRU PARENT
            GameObject clone = Instantiate(projectile, thePlayerController.fireLocation.transform.position, Quaternion.identity) as GameObject;

            
            Rigidbody cloneRB = clone.GetComponent<Rigidbody>();

            cloneRB.velocity = new Vector3
            

            
            Bullet clone = (Bullet)Instantiate(thePlayerController.bulletPrefab, thePlayerController.fireLocation.transform.position, thePlayerController.fireLocation.transform.rotation);

            // AUTOMATICALLY ENSLAVE AND MAKE CHILD PARENT OF BULLET
            clone.transform.parent = this.transform;
            

            // **** SUBTRACT 1 BULLET ****
            thePlayerController.ammoCount = thePlayerController.ammoCount - 1;

            // SET THIS SCRITPS VARIABNLE TO MATCH THE PLAYER CONTROLLER COUNT OF VARIABLE
            ammoCount = thePlayerController.ammoCount;

            // update UI text to display correct # of bullets CHA
            ammoText.text = "Bullets: " + ammoCount.ToString();

            // SET BOOL TO FALSE BECAUSE ACT IS ALSO **OVER**
            isFiring = false;

		}
        */

	}

	// jump boys
	public void JumpButton()
	{

        // set to true, well then again be turned false soon...
        //isJumping = true;

        // ** IF NOT JUMPING, SET TO JUMP **
        if (!thePlayerController.isJumping)
            thePlayerController.isJumping = true;

	}

    /*
    void Fire()
    {

        // call other function through Parent class
        //thePlayerController.Fire();

        // set bool in PlayerController to TRUE so it starts "firing" in THAT Update function
        thePlayerController.isFiring = true;

    }
    */
    

	// FIREEEEEE BUTTON
	public void FireButton()
	{

		// call fire function in PLAYERCONTROLLER
		//thePlayerController.Fire();

		// ** IF NOT FIRING, SET TO FIRE **
		if (!thePlayerController.isFiring)
			thePlayerController.isFiring = true;

	}
	
	// INVENTORY BUTTON
	public void InventoryButton()
	{

		if (!inventoryShowing) 
		{

			// set bool to true
			inventoryShowing = true;

			inventoryPanel.gameObject.SetActive (true);


		} 
		else 
		{

			// set bool to false
			inventoryShowing = false;

			
			inventoryPanel.gameObject.SetActive(false);

		}
				
	}
	// STORE MENU BUTTON
	public void StoreMenuButton()
	{

		// WHEN WITHIN RANGE OF "STORE MANAGER", button appears
		// this is what happens when that buttoln is sleected

	}

	// THIS BUTTON IS TO EXAMINE ITEM (IN VIEW) OR INTERACT WITH ITEM IE DOOR OPEN/CLOSE
	public void ExamineInteractButton()
	{




	}
	
		// (*test*) skateboard enter button
	public void SkateboardButton()
	{

	}

	// TESTING WHAT HAPPENS WHEN "SimpleTouch" Joystick is interacted with
	public void testJoyStick()
	{

		Debug.Log ("HEYYYYYYYY");

	}

	// function to QUIT application
	public void QuitButton()
	{

		// quit this bitch
		Application.Quit ();

	}

	// functoin to return to MAIN MENU
	public void MainMenuButton()
	{

		// load level zero
		Application.LoadLevel(0);

	}

}
