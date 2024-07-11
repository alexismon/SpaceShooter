using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : MonoBehaviour
{
    public PauseScreen pauseScreen;
    public DeathScreen deathScreen;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            pauseScreen.gameObject.SetActive(true);
        }
    }
    
    public void OnPlayerDeath()
    {
        deathScreen.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
