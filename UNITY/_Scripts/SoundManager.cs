using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	// soundtrack file(s)
	/*
	public AudioClip SoundTrack_level1;
	public AudioClip SoundTrack_level2;
	public AudioClip SoundTrack_level3;
	public AudioClip SoundTrack_level4;
	public AudioClip SoundTrack_level5;
	*/

	// ** ASSIGNED IN INSPECTOR **
	public AudioSource introMusic;
	public AudioSource levelMusic1;
	public AudioSource levelMusic2;
	public AudioSource levelMusic3;
	public AudioSource levelMusic4;
	public AudioSource levelMusic5;

	// **CURRENT SONG PLAYIN**
	public AudioSource currentSong;

	// pre-initialization
	void Awake ()
	{



	}

	// Use this for initialization
	void Start () 
	{


		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// **IF** INTRO GUI LEVEL
		if (Application.loadedLevel == 0)
		{

			// get/set current song
			currentSong = introMusic.GetComponent<AudioSource> ();

			// get/set audio for correct current lvl
			AudioSource introAudio = currentSong;
			introAudio.Play ();
			introAudio.Play (44100);

		} 
		// **ELSE** any other fucking level
		else if (Application.loadedLevel >= 0) 
		{

			// generate random int LOCAL var
			int randomSongInt = Random.Range(1, 5);

			// DEPENDING ON INT, SET INTRO MUSIC
			/////////////////////////////////////


			if (randomSongInt == 1)
			{

				// get/set current song
				currentSong = levelMusic1.GetComponent<AudioSource> ();

			}
			else if (randomSongInt == 2)
			{

				// get/set current song
				currentSong = levelMusic2.GetComponent<AudioSource> ();

			}
			else if (randomSongInt == 3)
			{

				// get/set current song
				currentSong = levelMusic3.GetComponent<AudioSource> ();

			}
			else if (randomSongInt == 4)
			{

				// get/set current song
				currentSong = levelMusic4.GetComponent<AudioSource> ();

			}
			else if (randomSongInt == 5)
			{

				// get/set current song
				currentSong = levelMusic5.GetComponent<AudioSource> ();

			}

			// PLAY THAT SHIT MEOW~!!!
			AudioSource levelAudio = currentSong;
			levelAudio.Play ();
			levelAudio.Play (44100);

		}
		
	}

}
