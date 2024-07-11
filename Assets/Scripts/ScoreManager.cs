using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private int highScore = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("Score", 0);
        AddScore(0);
    }

    public void AddScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = "Score: " + score.ToString("D4");

        if (score > highScore)
        {
            PlayerPrefs.SetInt("Score", score);
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Score", score);
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
