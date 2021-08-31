using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    private int healthFallRate = 5;

    public Slider hungerSlider;
    public int maxHunger;
    private int hungerFallRate = 5;


    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;
    }

    private void Update()
    {
        if (hungerSlider.value <= 0)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;

        }
        if (healthSlider.value <= 0)
        {
            CharacterDeath();
        }

        if (hungerSlider.value >= 0)
        {
            hungerSlider.value -= Time.deltaTime / hungerFallRate;
        }
        else if (hungerSlider.value <= 0)
        {
            hungerSlider.value = 0;
        }

        else if (hungerSlider.value >= maxHunger)
        {
            hungerSlider.value = maxHunger;
        }

    }

    void CharacterDeath()
    {
        
    }


}
