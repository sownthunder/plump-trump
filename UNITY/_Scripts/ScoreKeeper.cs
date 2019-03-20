using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public int score = 0;
    private Text myText;

    
    void Awake()
    {
        



    }
    

    
    // Use this for initialization
    void Start ()
    {

        myText = GetComponent<Text>();
        Reset();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    

    public void Score (int points)
    {
        score += points;
        myText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        myText.text = score.ToString();
    }

}
