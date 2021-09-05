using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item
{
    private PlayerVitals playerVitals;


    public void AddHealth(string furit)
    {
        if (furit == "Berry Bush")
        {
            playerVitals.healthSlider.value += 25;
            playerVitals.hungerSlider.value += 25;
        }
        else if (furit == "Banana Tree")
        {
            playerVitals.healthSlider.value += 50;
            playerVitals.hungerSlider.value += 50;

        }
    }

}
