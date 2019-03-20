using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChartboostSDK;

public class InventoryController : MonoBehaviour {

    // 

    // 1000 RUPPEES!!!
    public int storeCareFlow = 1000;

    public int inventorySize = 10;
    /////////////////////////////////////

    // GameObject variable used to get UI var
    public Transform inventoryCanvasObj;

    // public variable asssigned in inspector to hold INVENTORY
    public Canvas theInventoryCanvas;

    ////////////// OLD UI BUTTONS AS VARIABLES (TO HIDE WHEN INVENTORY UP)

    // **OLD**
    // Transform variables to get UI scripts from Transform Objects
    public Transform jumpButtonObj;
    public Transform fireButtonObj;
    public Transform moneySpriteObj;
    public Transform inventoryButtonObj;

    // **NEW**
    // Transform yada yada
    public Transform exitButtonObj;
    public Transform inventoryPanelObj;
    // ^^^^^ MIGHT NOT HAVE TO BE USED BECAUSE OF LINE 18 WITH invCanvas

    // UI Variables
    Button exitButton;
    Button selectButton1;
    Button selectButton2;
    Button selectButton3;
    Button selectButton4;
    Button selectButton5;
    Button selectButton6;
    Button selectButton7;
    Button selectButton8;
    Button selectButton9;
    Button selectButton10;
    Button leftButton; // << WISHFUL THINKING
    Button rightButton; // << WISHFUL THINKING

    //////////////////////////////////////

    // PlayerController script held in a variable
    PlayerController thePlayerController;

    // GameController script yada yada
    GameController theGameController;

    // IS THAT SHIT OPEN!?!??!?
    public bool isStoreOpen = false;

    

    // Pre-initialization
    void Awake ()
    {

        // get/set PlayerControllerScript
        thePlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        // SET PARENT OF THIS TO BECOME THE PLAYER
        transform.parent = thePlayerController.transform;

        // GET & SET **after** PlayerController is "established"
        //theGameController = thePlayerController.transform.

        // GET AND SET CANVAS VARIABLE THROUGH TRANSFORM OBJECT ***
        theInventoryCanvas = inventoryCanvasObj.GetComponent<Canvas>();

    }

	// Use this for initialization
	void Start ()
    {
		


	}
	
	// Update is called once per frame
	void Update ()
    {
		
        // if store open...
        if (isStoreOpen)
        {

            // set INVENTORY GameObject to INACTIVE
            inventoryCanvasObj.gameObject.SetActive(true);



        }
        else
        {

            // ELSE IF CLOSED WE SET TO FALSE AGAIN MEOW
            inventoryCanvasObj.gameObject.SetActive(false);

        }

	}

    // SELECT AN INVENTORY ITEM
    public void InventoryButtonSelect()
    {



    }

    // DROP AN INVENTORY ITEM
    public void InventoryButtonDrop()
    {



    }

    // *CRAFT* AN "INVENTORY" ITEM WITHIN MENU**
    public void InventoryButtonCraft()
    {



    }

    // COMPARE TWO INVENTORY ITEMS
    public void InventoryButtonCompare()
    {



    }



}
