using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // The character that the health bar belongs to
    public GameObject character;

    // The maximum value of the health bar
    public float maxHealth = 100;

    // The current value of the health bar
    private float currentHealth;

    // The UI image that will display the health bar
    public Image healthBarImage;

    void Start()
    {
        // Set the initial value of the health bar
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Update the health bar UI
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
        // Decrease the health bar by the specified amount
        currentHealth = Mathf.Max(currentHealth - amount, 0);
    }

    public void IncreaseHealth(float amount)
    {
        // Increase the health bar by the specified amount
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
    }
}
