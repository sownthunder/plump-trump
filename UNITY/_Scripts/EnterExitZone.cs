using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitZone : MonoBehaviour {

    // transform (get of parent so we know if BLIM OR CAR this script is attached to)
    Transform parentTransform;

    // use for pre initalization
    void Awake()
    {

        parentTransform = gameObject.GetComponentInParent<Transform>();

        // if parent object is GOLF CART
        if (parentTransform.gameObject.CompareTag("GolfCart"))
        {



        }
        // ELSE IF PARENT OBJECT IS BLIMP
        else if (parentTransform.gameObject.CompareTag("Blimp"))
        {




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

    void OnTriggerEnter(Collider other)
    {

        // if the collider that entered trigger is the PLAYER
        if (other.transform.gameObject.CompareTag("Player"))
        {

            // *
            // CHECK WHATTYPE (CAR OR BLIMP) AND THEN DISABLE RESPECTIVE GUI THROUGH "PlayerController"
            // *

        }


    }
}
