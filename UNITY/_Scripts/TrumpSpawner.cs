using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrumpSpawner : MonoBehaviour {

    // this Transform (attached to script)
    Transform theTransform;

    // array of Animatiions that appear in main menu
    // assigned in inspector**
    // lenth = 10
    public RuntimeAnimatorController[] theAnimationControllerList;

    // Animator component got in the awake function
    public Animator theAnimator;

    // randomly set between 0-10 and will "determine" which trump will
    // appear at spawn
    public int animationDeterminant;

    // GameObject that we will change animation depending on determinant
    public GameObject theTrump;

    // vector3 position that Trump will spawn in
    //Vector3 spawnLocation;

    // use for pre-initialization
	void Awake ()
    {

        // get & set
        //theTransform = transform.GetComponent<Transform>();
        theTransform = transform;

        // get & set Animator Component
        //theAnimator = transform.GetComponent<Animator>();

        

        // get & set TrumpSpawnLocation position **thru** child
        //spawnLocation = theTransform.GetComponentInChildren<Transform>().transform.position;


        // debug log
        //Debug.Log("TRUMP SPAWN POS == " + spawnLocation.ToString());

    }
    
    // Use this for initialization
	void Start ()
    {

        // randomly set the "determinant" so we know which animation to set TRUMP to
        // 03/19/2017 -- SET TO 10
        // 03/19/2017 -- SET TO 12
        animationDeterminant = Random.Range(0, 12);

        // debug log
        Debug.Log("TRUMP DETERMINANT == " + animationDeterminant.ToString());

        // get & set
        theTrump = GameObject.FindGameObjectWithTag("Trump");

        // get & set Animator Component
        theAnimator = theTrump.transform.GetComponent<Animator>();

        //
        // SET ANIMATION BASED ON DETERIMANNT
        //
        theAnimator.runtimeAnimatorController = theAnimationControllerList[animationDeterminant];

        //spawnLocation = theTrump.

	}
	
	// Update is called once per frame
	void Update ()
    {
	

        
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
