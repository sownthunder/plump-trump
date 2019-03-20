using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour {

    // Transform of that attached to this script
    Transform theElevator;

    public Vector3 teleportPoint;
    public Rigidbody rb;

    // determined by STRING name of GameObject attached to this script
    int elevatorNumber;

    // integer that holds the floor this elevator is currently on
    // (to know which direction to go back down in)
    public int currentFloor;

    // bool that determines movement of elevator (ie when player isi inside)
    public bool isMovingUp = false;
    public bool isMovingDown = false;

    // vector3 var that holds distances between player and elevator(s)
    public Vector3 elevator1Distance;
    public Vector3 elevator2Distance;

    // transform obj that holds UI Canvas (to activate / deactivate)
    Transform theElevatorGUI;

    // Pre-initialization
    void Awake ()
    {

        // get & set this transform object
        theElevator = this.transform;

        

        // get & set Rigidbody
        rb = GetComponent<Rigidbody>();

        // if this script is attached to ELEVATOR-1 OBJECT
        if (theElevator.name == "default1")
        {

            elevatorNumber = 1;
            currentFloor = 2;

            // get & set for DOWNWARD MNOVEMENT?
            theElevatorGUI = GameObject.Find("ElevatorDownGUI").transform;

        }
        // else if this script is attached to ELEVATOR-2 OBJECT
        else if (theElevator.name == "default2")
        {

            elevatorNumber = 2;
            currentFloor = 1;

            // get & set for DOWNWARD MNOVEMENT?
            theElevatorGUI = GameObject.Find("ElevatorUpGUI").transform;

        }

    }

	// Use this for initialization
	void Start ()
    {
		


	}
	
	// Update is called once per frame
	void Update ()
    {


		
	}

    // Called once per Unity Physics Engine frame...
    void FixedUpdate ()
    {

        if (isMovingUp)
        {

            // depending on which ELEVATOR NUMBER this is... move UPWARDS **OR** DOWNWARDS... 
            rb.MovePosition(transform.position + transform.up * Time.deltaTime);



            // set so it stops moving UP
            isMovingUp = false;

        }
        else if (isMovingDown)
        {

            // depending on which ELEVATOR NUMBER this is... move UPWARDS **OR** DOWNWARDS... 
            rb.MovePosition(transform.position - transform.up * Time.deltaTime);



            // set so it stops moving DOWN
            isMovingDown = false;


        }

    }

    // CHECK IF A PLAYER ENTERS THIS ELEVATOR
    void OnTriggerEnter(Collider other)
    {
        
        // if the collider that entered trigger is the PLAYER
        if (other.transform.gameObject.CompareTag("Player"))
        {

            // SET ELEVATOR GUI TO ACTIVE
            theElevatorGUI.gameObject.SetActive(false);


            // set move bool to be true to trigger MOVEMENT in FixedUpdate
            //isMoving = true;


        }

    }

    void OnTriggerExit(Collider other)
    {


        if (other.transform.gameObject.CompareTag("Player"))
        {

            // SET ELEVATOR GUI TO INACTIVE
            theElevatorGUI.gameObject.SetActive(true);

        }

    }

    public void ElevatorUpButton()
    {

        isMovingUp = true;

    }

    public void ElevatorDownButton()
    {

        isMovingDown = true;

    }


}
