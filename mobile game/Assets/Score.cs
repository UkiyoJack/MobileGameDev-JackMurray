using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreLabel;             //define text labels - NOT USING TMPRO
    public Text highScoreLabel;

    int score = 0;      //define default scores
    int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);         
        scoreLabel.text = "Score: " + score.ToString(); 
        highScoreLabel.text = "High Score: " + highScore.ToString();     //display high score
    }

    // Update is called once per frame
    public void scoreCalculator()
    {
        score += 1; //increment score
        scoreLabel.text = "Score: " + score.ToString();
        if(highScore < score)   //if highscore is less than current score, set the current score as the new high score
            PlayerPrefs.SetInt("highScore", score);
        
    }
}
