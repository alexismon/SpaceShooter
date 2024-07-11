using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer[] hearts; // Array to store heart images

    public void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; // Show heart
            }
            else
            {
                hearts[i].enabled = false; // Hide heart
            }
        }
    }
}