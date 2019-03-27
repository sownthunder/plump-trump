using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSpawner : MonoBehaviour {

	// set MAX & MIN
	public int maxCountPerLvl = 100;
	public int minCoutPerLvl = 25;

	////////////
	/// 
	/// 
	///
	public int manaDrainPerUse = 50;
	// ^^ NOT UESED MEOW ^^

	// PREFABRICATED GAMEOBJECT OF "MANA POTION"
	// ** WILL BE USED TO SPAWN **
	public GameObject manaPrefab;

	// array of Mana Objects
	public GameObject[] arrayOfMana;


	// Use this for pre-initialization
	void Awake ()
	{

		// GET & SET RANDOM SIZE
		int arraySize = Random.Range(minCoutPerLvl, maxCountPerLvl);


		// sett that size to be length of array
		arrayOfMana = new GameObject[arraySize];

	}

	// Use this for initialization
	void Start () 
	{

		
	}
	
	// Update is called once per frame
	void Update ()
	{


		
	}

	void FixedUpdate ()
	{



	}

}
