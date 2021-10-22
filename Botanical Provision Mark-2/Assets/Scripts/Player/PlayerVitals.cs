using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerVitals : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    private readonly int healthFallRate = 3;

    public Slider hungerSlider;
    public int maxHunger;
    private readonly int hungerFallRate = 3;
    public static string PreviousSence;

    private void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        hungerSlider.maxValue = maxHunger;
        hungerSlider.value = maxHunger;

    }

    private void Update()
    {
        //Health Controller
        if (hungerSlider.value <= 0)
        {
            healthSlider.value -= Time.deltaTime / healthFallRate;

        }
        if (healthSlider.value >= maxHealth)
        {
            healthSlider.value = maxHealth;
        }
        if (healthSlider.value <= 0)
        {
            CharacterDeath();
        }

        //Hunger Controller
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }


}
