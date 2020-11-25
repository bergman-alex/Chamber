using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText = null; // the score label
    [SerializeField] private int scorePerSecond = 0; // points awarded each second
    [SerializeField] private Image timeImg = null;

    private static int score;
    private int highScore;
    private float timer;
    private float timer2;
	private GameMechanics mechs;

	void Start()
	{
		score = 0;
        timer = 0f;     // 1 second score timer
        timer2 = 0f;    // 10 second room timer

        mechs = GameObject.Find("GameMechanics").GetComponent<GameMechanics>();
	}

    void Update()
    {
    	if (mechs.roomCounter >= 1)
    	{
        	timeImg.fillAmount = timer2 / 10;

        	if (timer2 > 10f)
        	{
            	timer2 = 0f;
        	}

        	if (timer > 1f) // if the timer has surpassed a full second
        	{
        		AddScore(scorePerSecond); // add [scorePerSecond] points to the total score
        		timer = 0f; // reset the timer
        	}

        	timer += Time.deltaTime;			// timer for counting seconds
        	timer2 += Time.deltaTime;
        }
        
        scoreText.text = "Score: " + score;	// update the score label
        PlayerPrefs.SetInt("playerScore", score);
    }

    protected static void AddScore(int addedValue)	// function for adding points to the score
    {
    	score += addedValue;
    }
}
