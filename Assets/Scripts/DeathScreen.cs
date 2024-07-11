using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    public Text currentScoreText;
    public Text highScoreText;
    public ScoreManager scoreManager;
    
    void OnEnable()
    {
        currentScoreText.text = "Your Score: " + scoreManager.GetCurrentScore().ToString("D4");
        highScoreText.text = "High Score: " + scoreManager.GetHighScore().ToString("D4");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
