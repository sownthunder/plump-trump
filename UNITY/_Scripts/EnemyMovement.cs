using UnityEngine;
using UnityEngine.AI; // HAVE TO INCLUDE AI
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	PlayerHealth playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	NavMeshAgent nav;               // Reference to the nav mesh agent.

	public bool withinRange = false;

	// Adjust the speed for the application
	public float speed = 1.0f;

	// The target (human player) position.
	//private Transform target; *PLAYER VARIABLE*

	// SET TIMER TO CHECK DISTANCE BETWEEN THIS AN PLAYER EVERY X SECONDS???

	// SET A RANDOM RANGE AT SPAWN TO SET DIFFERENT RANGES BETWEEN ENEMIES??


	void Awake ()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		nav = GetComponent<NavMeshAgent>();
	}


	void Update ()
	{
		
		// PUBLIC FLOAT TO hold distane between this object and player
		float dist = Vector3.Distance(player.position, transform.position);
		// ^ constantly updated 

		Debug.Log("DISTANCE TO :" + player.gameObject.name + " == " + dist + " from " + transform.name);

		// If the enemy and the player have health left...
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{

			// ... set the destination of the nav mesh agent to the player.
			nav.SetDestination (player.position);

		}
		// Otherwise...
		else 
		{

			// ... disable the nav mesh agent.
			nav.enabled = false;

		}

		// check if player is WITHIN RANGE on this object
		if (dist <= 3.5f)
		{


			// Move our enemy position a step closer to the target. 
			float step = speed * Time.deltaTime; // calculate distance to move
			transform.position = Vector3.MoveTowards(transform.position, player.position, step);

			// Check if the position of the cube and sphere are approximatelly equal. 
			if (Vector3.Distance(transform.position, player.position) < 0.001f)
			{

				// Swap the position of the cyliner.
				player.position *= -1.0f;


			}


		}


	} 

	void OnTriggerEnter(Collider other)
	{

		// IF MEXI HIT BY A BULLET
		if (other.transform.tag == "Bullet")
		{



		}

	}

}