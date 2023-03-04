using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    // The character that the stamina bar belongs to
    public GameObject character;

    // The maximum value of the stamina bar
    public float maxStamina = 100;

    // The current value of the stamina bar
    private float currentStamina;

    // The UI image that will display the stamina bar
    public Image staminaBarImage;

    void Start()
    {
        // Set the initial value of the stamina bar
        currentStamina = maxStamina;
    }

    void Update()
    {
        // Update the stamina bar UI
        staminaBarImage.fillAmount = currentStamina / maxStamina;
    }

    public void DecreaseStamina(float amount)
    {
        // Decrease the stamina bar by the specified amount
        currentStamina = Mathf.Max(currentStamina - amount, 0);
    }

    public void IncreaseStamina(float amount)
    {
        // Increase the stamina bar by the specified amount
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }
}
