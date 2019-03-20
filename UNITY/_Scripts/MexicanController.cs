using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanController : MonoBehaviour {

    public GameObject projectile;
    public float projectileSpeed = 10f;
    public float health = 150f;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;

    GameController theGameController;

    private ScoreKeeper scoreKeeper;

    // standard health started at 100
    //public int health = 100;

    // assigned in inspector
    public AudioSource dyingSound; 

    // Use this for pre-initialization
    void Awake()
    {

        // get & set
        theGameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        // get / set AUDIO SOURCE
        dyingSound = gameObject.GetComponent<AudioSource>();

    }

    // Use this for initialization
    void Start ()
    {

        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

	}
	
	// Update is called once per frame
	void Update ()
    {

        float prob = shotsPerSecond * Time.deltaTime;
        if (Random.value < prob)
        {
            Fire();
        }

        // if health drops below 0... EVER
        if (health <= 0)
        {

            AudioSource theDyingSound = dyingSound;

            // PLAY DEATH SOUND
            theDyingSound.Play();

            // DESTRYO THIS OBJECT
            Destroy(transform);

        }


	}

    void Fire()
    {
        Vector3 offset = new Vector3(0, -1.0f, 0);
        Vector3 firePos = transform.position + offset;

        GameObject mexicanMud = Instantiate(projectile, firePos, Quaternion.identity) as GameObject;
        // ** SEND MEXICAN MUD IN A DIRECTION!!

    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.ToString());

        //other.gameObject.GetComponent<Projectile>();

		// if the collided object is a bullet (MEXICAN GOT HIT BY BULLET)
		if (other.transform.tag == "Bullet") 
		{

			float bulletDamage = Random.Range (100, 200);

			health = health - bulletDamage;

		}

		/*
        Projectile mudMissile = other.gameObject.GetComponent<Projectile>();
        if (mudMissile)
        {

            // call "GetDamage" function in mudMissile
            health -= mudMissile.GetDamage();

            mudMissile.Hit();

            if (health <= 0)
            {

                Destroy(gameObject);

            }

            Debug.Log("hit by a projectile");

        }
		*/

        /*
        projectile missile = collider.gameObject.GetComponent<Projectile>();
        if (missile)
        {

            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0) 
            {

                Destroy(gameObject);
                scoreKeeper.Score(scoreValue);

            }

        }
        */

          //if (other.transform.gameObject.CompareTag("Bullet"))
        





        
        

    }

}
