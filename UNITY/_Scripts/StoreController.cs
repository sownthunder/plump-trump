using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartboostSDK;

public class StoreController : MonoBehaviour {

    /// <summary>
    /// USE ChartBoostSDK to create RewardVideos users have to watch
    /// in order to recieve more ammo etc
    /// </summary>

    // public variable (thru inspector) to hold Transform oBject
    public Transform torePanelTransform;

	// variable for get / set Canvas object
	Canvas theStoreCanvas;

	// bool to determine if this is the first time player has talked to shop owner (TODAY***)
	public bool firstInteraction = false;

	// integer that represents how much SHOP HOLD has in cash (debt)
	public int storeCashFlow = 1000;

	// testing... later
	private float barterMulitiplier;

	// max items shop keeper can hold
	public int inventorySize = 10;

	// is inventory/store panel open??
	public bool panelOpen = false;

	// GameController script held in a variable
	GameController theGameController;

    // Transform to hold variable of canvas of player GUI to deactive when ***store panel is open***
    Transform thePlayerCanvasObj;

	// Pre-initialization
	void Awake ()
	{

		// get /set before player is loaded (THROUGH PARENT)
		theGameController = transform.GetComponentInParent<GameController>();

	}

	// Use this for initialization
	void Start () 
	{

        // set random ints here to determine shit??

        // ** GET PlayerGuiCanvas** 
        thePlayerCanvasObj = GameObject.FindGameObjectWithTag("PlayerGUI").transform;
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// display ad for opening up Store!
		if (panelOpen) 
		{

			// if ** STIL THE FIRST INTERACTION (going on right meow) **
			if (!firstInteraction) 
			{

				// <-- SHOW AD FOR FIRST TIME -->

				// ** SHOW AD TRUMPSTER STYLE!! :) **
				// Show interstitial at location HomeScreen. 
				// See Chartboost.cs for available location options.
				Chartboost.showInterstitial (CBLocation.HomeScreen);

				// set to true so this doesnt happen again
				firstInteraction = true;

			} 
			else 
			{



			}


			// ** SHOW AD TRUMPSTER STYLE!! :) **
			// Show interstitial at location HomeScreen. 
			// See Chartboost.cs for available location options.
			Chartboost.showInterstitial(CBLocation.HomeScreen);

		}
		
	}

    // WHEN THE BUTTON FOR BUYING AN ITEM IN STORE IS PRESSED
    public void StoreButtonPurchase()
    {



    }



}
