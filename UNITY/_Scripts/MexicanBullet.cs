using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanBullet : MonoBehaviour {

	// damage that will be inflicted upon COLLIDER
	public float damage = 10f;

	// FLOAT VARIABLE TO DETERMINE HOW LONG BULLET AUTO-DELETES
	public float timeLeft = 1.0f;

	public Rigidbody rb;

	// GameController script held in a variable
	GameController theGameController;

	// PlayerController script held in a variable
	PlayerController thePlayerController;

	public AudioSource gunshotSound;

	void Awake ()
	{

		// get and set player before this bullet is techincally loaded
		// GAME CONTROLLER WILL BE PARENT OF THAT PARENT (thru parent)
		thePlayerController = transform.GetComponentInParent<PlayerController> ();

		// get & set gunshot soound
		gunshotSound = gameObject.GetComponent<AudioSource>();

	}

	// Use this for initialization
	void Start () 
	{

		rb = GetComponent<Rigidbody> ();

		// set to more local variable???
		AudioSource gunShotAudio = gunshotSound;
		gunShotAudio.Play();

	}
	
	// Update is called once per frame
	void Update () 
	{

		// count down and subtract per second
		timeLeft -= Time.deltaTime;

		// if countdown reaches zero.. delete this bullet
		if (timeLeft < 0)
			Destroy (gameObject);
		
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
		else if (collision.collider.transform.gameObject.tag == "Player") 
		{

			/*
			// GET & SET MexicanControllerScript to local variable
			// (prior to applying hit points damage)

			// *(GET  &  SET)* MexcianControllerScript through "collision" object
			MexicanController aMexicanControllerScript = collision.collider.transform.GetComponent<MexicanController>();

			// DO 50 DAMAGE (half health?)
			// (if not set health to 100 so 50 is half)
			aMexicanControllerScript.health -= 50;
			*/

			// destroy this bullet because it has damage & its job
			Destroy(gameObject);



		}
		else if (collision.collider.transform.gameObject.tag == "Poster") 
		{



		}
		else if (collision.collider.transform.gameObject.tag == "Wall") 
		{



		}

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
