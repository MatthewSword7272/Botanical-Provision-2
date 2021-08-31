using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour
{
    public Slider HealthSlider;
    public int maxHealth = 100;
    public int HealthFallRate;

    public Slider HungerSlider;
    public int maxHunger = 100;
    public int HungerFallRate;

    private void Start()
    {
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = maxHealth;

        HungerSlider.maxValue = maxHunger;
        HungerSlider.value = maxHunger;

    }

    private void Update()
    {
        //Health

        if (HungerSlider.value <= 0)
        {
            HealthSlider.value -= Time.deltaTime / HealthFallRate;
            HungerSlider.value = 0;
        }

        if (HealthSlider.value <= 0)
        {
            CharacterDeath();
        }

        if (HungerSlider.value >= 0)
        {
            HungerSlider.value -= Time.deltaTime / HungerFallRate;
        }
        else if (HungerSlider.value >= maxHunger)
        {
            HungerSlider.value = maxHunger;
        }
    }

    void CharacterDeath()
    {
        //Do Somehting!!
    }

}
