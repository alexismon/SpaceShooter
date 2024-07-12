using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public SpriteRenderer[] hearts; // Array to store heart images
    public AK.Wwise.State damagedState; // Wwise state for "Damaged"
    public AK.Wwise.State veryDamagedState; // Wwise state for "VeryDamaged"
    public AK.Wwise.State deathState; // Wwise state for "Death"
    public AK.Wwise.State fullHealthState; // Wwise state for "FullHealth"

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

        // Set Wwise state based on current health
        if (currentHealth == hearts.Length)
        {
            fullHealthState.SetValue();
        }
        else if (currentHealth == hearts.Length - 1)
        {
            damagedState.SetValue();
        }
        else if (currentHealth == hearts.Length - 2)
        {
            veryDamagedState.SetValue();
        }
        else if (currentHealth == 0)
        {
            deathState.SetValue();
        }
    }
}
