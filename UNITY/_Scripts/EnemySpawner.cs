using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // prefabricated objects for each ENEMY TYPE
    public GameObject mexicanPrefab;
    public GameObject russianPrefab;
    public GameObject northKoreanPrefab;
    public GameObject LoneWolfPrefab;

    // Used for pre-initalization
    void Awake()
    {
        


    }

    // Use this for initialization
    void Start ()
    {

        GameObject testEnemy = Instantiate(mexicanPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        testEnemy.transform.parent = transform;

		// set random integer to spawn MEXIES
		int randomInt = Random.Range (1, 10);

		// spawn based on random integer above
		while (randomInt > 0)
		{

			Instantiate(mexicanPrefab, new Vector3(0, 0, 0), Quaternion.identity);

			// subtract from counter
			randomInt = randomInt - 1;

		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{


		
	}

    void SpawnMxicans()
    {


        // 03/11/18 --> NEED TO FINISh
        /*
        foreach( Transform child in transform) {
        Transform freePosition = NextFreePosition();
        GameObject enemyMexican = Instantiate(mexicanPrefab, freePosition.position, Quaternion.identity);
        enemyMexican.transform.parent = freePosition;
        */

    }

    void SpawnMexicansUntilFull()
    {



    }

}
