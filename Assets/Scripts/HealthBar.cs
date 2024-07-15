using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer[] hearts; // Array to store heart images
    public AudioLowPassFilter lowPassFilter; // Reference to the Low Pass Filter

    private int currentHealth;

    void Start()
    {
        currentHealth = hearts.Length; // Assuming starting health is the total number of hearts
        UpdateHealthUI(currentHealth);
        UpdateLowPassFilter();
    }

    public void UpdateHealthUI(int newHealth)
    {
        currentHealth = newHealth;

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

        UpdateLowPassFilter();
    }

    void UpdateLowPassFilter()
    {
        switch (currentHealth)
        {
            case 3:
                lowPassFilter.cutoffFrequency = 22000f; // No filter when health is full
                break;
            case 2:
                lowPassFilter.cutoffFrequency = 5000f; // Moderate filter when 2 hearts
                break;
            case 1:
                lowPassFilter.cutoffFrequency = 1000f; // Strong filter when 1 heart
                break;
            case 0:
                lowPassFilter.cutoffFrequency = 0f; // Dead, completely muted
                break;
        }
    }
}
