using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
	[SerializeField] private Text scoreText = null;
	[SerializeField] private Text highScoreText = null;

	private int finalScore;
	private int highScore;

    void Start()
    {
        finalScore = PlayerPrefs.GetInt("playerScore");
    	scoreText.text = finalScore.ToString();

    	if (PlayerPrefs.HasKey("highScore"))
    	{
    		highScore = PlayerPrefs.GetInt("highScore");

    		if (finalScore > highScore)
    		{
    			highScore = finalScore;
    			PlayerPrefs.SetInt("highScore", finalScore);
    		}
    	}
    	else
    	{
    		highScore = finalScore;
    		PlayerPrefs.SetInt("highScore", finalScore);
    	}

    	highScoreText.text = "Highscore: " + highScore;
    }
}
