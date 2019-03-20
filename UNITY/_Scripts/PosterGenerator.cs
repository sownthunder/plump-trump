using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterGenerator : MonoBehaviour {

	// float? that will be randomly determined to decide HOW MANY posters spawn meow
	public float numOfPosters;

	// SPRITES THAT HOLD POSTER "IMAGES" AND ASSIGNED THRU INSPECTOR
	public Sprite poster1;
	public Sprite poster2;
	public Sprite poster3;
	public Sprite poster4;
	public Sprite poster5;
	public Sprite poster6;
	public Sprite poster7;
	public Sprite poster8;
	public Sprite poster9;
	public Sprite poster10;

	// Pre-initialization
	void Awake ()
	{

		// RANDOMLY SET NUMBER OF POSTERS
		// 02/28/2018: 1-100
		numOfPosters = Random.Range(1, 101);

	}

	// Use this for initialization
	void Start () 
	{

		// loop thru and spawn dem posters
		for (int x = 0; x <= numOfPosters; x++) 
		{

			// between 1-10 random different kinds of posters
			float posterSpawnNumer = Random.Range (1, 10);

		}

		
	}
	
	// Update is called once per frame
	void Update () 
	{



	}

}
