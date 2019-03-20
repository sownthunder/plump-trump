using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour {

    // damage that will be inflicted upon COLLIDER 
    public float damage = 100f;

	// FLOAT VARIABLE TO DETERMINE HOW LONG BEFORE BULLET AUTO-DELETES
	// (so that ghetto shit dont go forever)
	public float timeLeft = 2.0f;

	// set range before bullet goes poof to 100 units??
	public float maxRange = 75f;

	public float thrust = 450f;

	// thrust is how fast and set thru parent when this bullet is spawned
	//public float thrust = 50.0f;
	public Rigidbody rb;

	// GameController script held in a variable
	GameController theGameController;

	// PlayerController script held in a variable
	PlayerController thePlayerController;

    // **<< THIS WORKS **>>
    public AudioSource gunshotSound;

	// AUDIO CLIPS <--->
	public AudioClip theFiringSound;
	public AudioClip theHittingTargetSound;
	public AudioClip theHittingGroundSound;

	// AUDIO CLIPS DEPENDING ON TARGET HIT
	public AudioClip dyingRaccoonSound;

	// the position of the bullet when it is FIRST fired
	Vector3 startingPos;

	// Use this for pre-initialization
	void Awake ()
	{

		// just in caseeee
		maxRange = 75f;

		// **>> JUST IN CASE <<**
		//thrust = 450.0f;

		// GET & SET RIGIDBODY OF BULLET TO VARIABLE
		rb =transform.GetComponent<Rigidbody> ();

        // get /set before player is loaded (THROUGH PARENT)
        //theGameController = transform.GetComponentInParent<GameController>();
        ///theGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        // set GameController to be parent of this Bullet
        ///transform.parent = theGameController.transform;

		// get and set player before this bullet is techincally loaded
		// GAME CONTROLLER WILL BE PARENT OF THAT PARENT (thru parent)
		thePlayerController = transform.GetComponentInParent<PlayerController> ();

        // get and set GAME CONTROLLER thru parent class
        //theGameController = thePlayerController.transform.GetComponent<GameController>();
        //theGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController> ();

        /*
		// set PlayerController as parent (OF THIS TRANSFORM)?
		// and therefore parent of parent is set as well
		transform.parent = thePlayerController.transform;
		*/

		// get & set to OG position
		startingPos = transform.position;

        // get & set gunshot soound
        gunshotSound = gameObject.GetComponent<AudioSource>();

	}

	// Use this for initialization
	void Start () 
	{

		rb = GetComponent<Rigidbody> ();

        // * THRUST SET TO 50 ABOVE * 

        // get and set whatever the thrust was set within PlayerController before spawning this BB
        //thrust = thePlayerController.initialThrust;

        // set to more local variable???
        AudioSource gunShotAudio = gunshotSound;
        gunShotAudio.Play();

	}
	
	// Update is called once per frame
	void Update () 
	{

		// check if the CURRENT bullet position is more than "maxRange" away from OG pos
		if (Vector3.Distance (transform.position, startingPos) >= maxRange) 
		{

			// destory this bullet brah
			Destroy (transform.gameObject);

		}

		// OLD WAY //
		/*
		// count down and subtract per second
		timeLeft -= Time.deltaTime;

		// if countdown reaches zero.. delete this bullet
		if (timeLeft < 0)
			Destroy (gameObject);
		*/

	}

    public float GetDamage()
    {

        return damage;

    }

    public void Hit()
    {

        Destroy(gameObject);

    }

	void FixedUpdate ()
	{

		// BOTH REMOVED 3/29/2018

		//rb.AddForce(0, 0, thrust, ForceMode.Impulse);

		//rb.AddForce (transform.forward * thrust);

		/////////////////////////////////////////////

		// APPLY FORCE TO THAT VARIABLE!!
		// (by using transform attached to GameObject that is assigned in inspector in this script)
		rb.AddForce (thePlayerController.fireLocation.transform.forward * thrust);

	}

	private void OnTriggerEnter (Collider other)
	{


		Debug.Log("YOU HIT SOMETHING HOLY SHIT!");

		// subtract HEALTH FROM other OBJECT here


	}

	private void OnTriggerExit (Collider other)
	{


		Debug.Log("And its DEAD!!!!!!");

		// local var
		Collider testEnemyCollider = other.transform.GetComponent<Collider>();

		// destroy that shit // WAS: collider.transform.gameObject
		Destroy(testEnemyCollider);

	}

	// WHENEVER THIS BULLET COLLIDES WITH ANOTHER RIGIDBODY
	void OnCollisionEnter (Collision collision)
	{

		// do damage, add exp, etc

		// IF THE BULLET HITS A COON
		if (collision.collider.transform.gameObject.tag == "Raccoon") 
		{



		}
		// if collided with enemy1
		else if (collision.collider.transform.gameObject.tag == "Enemy1") 
		{



		}
		else if (collision.collider.transform.gameObject.tag == "Enemy2") 
		{



		}
		// IF BULLET HITS A MEXICAN
		else if (collision.collider.transform.gameObject.tag == "Mexican") 
		{

			// GET & SET MexicanControllerScript to local variable
			// (prior to applying hit points damage)

			// *(GET  &  SET)* MexcianControllerScript through "collision" object
			MexicanController aMexicanControllerScript = collision.collider.transform.GetComponent<MexicanController>();

			// DO 50 DAMAGE (half health?)
			// (if not set health to 100 so 50 is half)
			aMexicanControllerScript.health -= 50;

			// destroy this bullet because it has damage & its job
			Destroy(gameObject);


		}
		else if (collision.collider.transform.gameObject.tag == "Poster") 
		{



		}
		else if (collision.collider.transform.gameObject.tag == "Wall") 
		{



		}
		else if (collision.collider.transform.gameObject.tag == "FemaleNorthKorean")
		{


			// LOCAL VAR
			Collider localColliderVar = collision.collider.transform.GetComponent<Collider>();

			// DESTROY THAT DIRTY LIL KOREAN
			// (**OTHER gameObject)
			Destroy(localColliderVar);
			//Destroy(collision.collider.transform);

			// destroy this bullet because it has damage & its job
			// (gameObject that is attached to THIS script)
			Destroy(gameObject);

		}

		///////////////////////////////////////////////////////////////////////////////////////////////////////////


		////////////////////////////////////////////////////////////////////////////////////////////////////////

		// if Bullet hits the PushableButton
		if (collision.collider.transform.gameObject.tag == "PushableButton") 
		{



		}
        else if (collision.collider.transform.gameObject.tag == "ElevatorButton")
        {

            // check which elevator and then teleport to other

        }



	}
		
}
